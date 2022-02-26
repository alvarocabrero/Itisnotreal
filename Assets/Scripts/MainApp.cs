using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MainApp : MonoBehaviour
{
    ElementManager EM;

    public static SpriteRenderer headingSpriteUI, subheadingSpriteUI, photoSpriteUI;



    private VisualElement uiDocument_root;
    public List<GameObject> headingSprites, subheadingSprites, photoSprites = new List<GameObject>();

    public ElementStorage elementStorage;

    public Animator Button_Publish_Animator { get; private set; }

    private Label popularity_value_label;
    private Label instability_value_label;
    private Label credibility_value_label;
    private Label clock_label;

    //private readonly bool FAKE = true;
    private List<string> used_themes = new List<string>();


    //Report Canvas
    private Canvas reportCanvas;
    private Text instability_report_value, credibility_report_value, popularity_report_value;

    private int NEWSPERWEEK = 2;



    float timer = 0.0f;
    float timer_Limit = 30f;
    private bool playing;


    // Start is called before the first frame update
    void Start()
    {

        InitUI();

        //Init element storage
        elementStorage = new ElementStorage(headingSprites, subheadingSprites, photoSprites);
        //Init Element Manager
        InitElementManager();

        UpdateScores(EM.newspaper.popularity, EM.newspaper.instability, EM.newspaper.credibility);
        playing = true;

    }


    private void InitElementManager()
    {
        ChangeTheme();
    }

    private void EstablishTheme(string theme)
    {
        used_themes.Add(theme);

        List<Heading> headings = elementStorage.GetHeadings(theme);
        List<Subheading> subheadings = elementStorage.GetSubheadings(theme);
        List<Photo> photos = elementStorage.GetPhotos(theme);

        EM = new ElementManager(headings, subheadings, photos);

        headingSpriteUI.sprite = EM.selectedHeading.GetSprite().sprite;
        subheadingSpriteUI.sprite = EM.selectedSubheading.GetSprite().sprite;
        photoSpriteUI.sprite = EM.selectedPhoto.GetSprite().sprite;
        //EM.newspaper.newMatch();

    }

    private void ChangeTheme()
    {
        Debug.Log("ChangeTheme");
        foreach (string theme in THEME.THEME_LIST)
            if (!used_themes.Contains(theme))
            {
                EstablishTheme(theme);
                return;
            }
        //Fin de partida
        Debug.Log("No hay mas temas");
    }

    private void InitUI()
    {

        reportCanvas = GameObject.Find("ReportCanvas").GetComponent<Canvas>();

        instability_report_value = GameObject.Find("instability_report_value").GetComponent<Text>();
        credibility_report_value = GameObject.Find("credibility_report_value").GetComponent<Text>();
        popularity_report_value = GameObject.Find("popularity_report_value").GetComponent<Text>();


        reportCanvas.enabled = false;

        headingSpriteUI = GameObject.Find("Heading").GetComponent<SpriteRenderer>();
        subheadingSpriteUI = GameObject.Find("Subheading").GetComponent<SpriteRenderer>();
        photoSpriteUI = GameObject.Find("Photo").GetComponent<SpriteRenderer>();

        GameObject UIDocument_object = GameObject.Find("UIDocument");
        uiDocument_root = UIDocument_object.GetComponent<UIDocument>().rootVisualElement;


        Button_Publish_Animator = GameObject.Find("Button_Publish").GetComponent<Animator>();

        popularity_value_label = uiDocument_root.Q<Label>("popularity_value_label");
        instability_value_label = uiDocument_root.Q<Label>("instability_value_label");
        credibility_value_label = uiDocument_root.Q<Label>("credibility_value_label");

        clock_label = uiDocument_root.Q<Label>("clock_label");
        clock_label.text = timer_Limit.ToString();

    }

    private void UpdateScores(int popularity, int instability, int credibility)
    {
        UpdatePopularityScore(popularity);
        UpdateInstabilityScore(instability);
        UpdateCredibilityScore(credibility);
    }

    private void UpdateCredibilityScore(int credibility)
    {
        credibility_value_label.text = credibility.ToString();
    }

    private void UpdateInstabilityScore(int instabilityFinalValue)
    {
        if (int.Parse(instability_value_label.text) + instabilityFinalValue <= 0)
        {
            instability_value_label.text = "0";
        }
        else if (int.Parse(instability_value_label.text) + instabilityFinalValue >= 100)
        {
            instability_value_label.text = "100";
        }
        else
            instability_value_label.text = (int.Parse(instability_value_label.text) + instabilityFinalValue).ToString();
    }

    private void UpdatePopularityScore(int popularityFinalValue)
    {
        if (int.Parse(popularity_value_label.text) + popularityFinalValue <= 0)
            popularity_value_label.text = "0";
        else
            popularity_value_label.text = (int.Parse(popularity_value_label.text) + popularityFinalValue).ToString();
    }

    public void Publish()
    {
        timer = 0;
        EM.CheckCredibility();
        UpdateScores(EM.CalculatePopularity(), EM.CalculateInstability(), EM.newspaper.credibility);
        //@TODO sumar directamente en los contadores rollo efecto visual 
        //@TODO si han pasado 2 o tres noticias o fin del juego mostrar report
        for (int i = 1; i <= THEME.THEME_LIST.Length; i++)
            if (used_themes.Count.Equals(NEWSPERWEEK * i))
            {
                ShowReport();
                return;
            }

        ChangeTheme();
        clock_label.text = timer_Limit.ToString();
    }

    public void NextWeek()
    {

        reportCanvas.enabled = false;
        uiDocument_root.SetEnabled(true);
        ChangeTheme();
        playing = true;

    }

    private void ShowReport()
    {
        playing = false;

        uiDocument_root.SetEnabled(false);
        //@TODO mostrar valores report values
        popularity_report_value.text = "+ " + EM.newspaper.popularity.ToString();
        instability_report_value.text = "+ " + EM.newspaper.instability.ToString();
        credibility_report_value.text = "+ " + EM.newspaper.credibility.ToString();


        reportCanvas.enabled = true;
        ChangeTheme();
    }

    public void NextHeading()
    {
        headingSpriteUI.sprite = EM.NextHeading().GetSprite().sprite;
    }

    public void NextSubheading()
    {
        subheadingSpriteUI.sprite = EM.NextSubheading().GetSprite().sprite;
    }

    public void NextPhoto()
    {
        photoSpriteUI.sprite = EM.NextPhoto().GetSprite().sprite;
    }

    public void OnButtonDown()
    {
        Button_Publish_Animator.SetBool("ButtonDown", true);
    }
    public void OnButtonUP()
    {
        Button_Publish_Animator.SetBool("ButtonDown", false);
        Publish();

    }

    void Update()
    {
        if (playing)
        {

            timer += Time.deltaTime;
            int seconds = (int)(timer % 60);
            clock_label.text = (timer_Limit - seconds).ToString();
            if (timer_Limit - seconds == 0)
            {
                Publish();
                ShowReport();
                timer = 0;
            }
        }

    }
}


