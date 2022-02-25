using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UIElements;

public class MainApp : MonoBehaviour
{
    ElementManager EM;

    public static SpriteRenderer headingSpriteUI, subheadingSpriteUI, photoSpriteUI;

    public List<GameObject> headingSprites, subheadingSprites, photoSprites = new List<GameObject>();

    public ElementStorage elementStorage;

    private Label popularity_value_label;
    private Label instability_value_label;
    private Label credibility_value_label;
    //private readonly bool FAKE = true;

    // Start is called before the first frame update
    void Start()
    {
        InitUI();

        //Init element storage
        elementStorage = new ElementStorage(headingSprites, subheadingSprites, photoSprites);
        //Init Element Manager
        InitElementManager();


        UpdateScores(EM.newspaper.popularity, EM.newspaper.instability, EM.newspaper.credibility);
    }


    private void InitElementManager()
    {
        string firsChosenTheme = THEME.THEME_LIST[2];

        List<Heading> headings = elementStorage.GetHeadings(firsChosenTheme);
        List<Subheading> subheadings = elementStorage.GetSubheadings(firsChosenTheme);
        List<Photo> photos = elementStorage.GetPhotos(firsChosenTheme);

        EM = new ElementManager(headings, subheadings, photos);
        headingSpriteUI.sprite = EM.selectedHeading.GetSprite().sprite;
        subheadingSpriteUI.sprite = EM.selectedSubheading.GetSprite().sprite;
        photoSpriteUI.sprite = EM.selectedPhoto.GetSprite().sprite;

    }


    private void InitUI()
    {
        headingSpriteUI = GameObject.Find("Heading").GetComponent<SpriteRenderer>();
        subheadingSpriteUI = GameObject.Find("Subheading").GetComponent<SpriteRenderer>();
        photoSpriteUI = GameObject.Find("Photo").GetComponent<SpriteRenderer>();

        var uiDocument = GameObject.Find("UIDocument").GetComponent<UIDocument>().rootVisualElement;

        uiDocument.Q<Button>("PublishButton").clicked += delegate { Publish(); };

        popularity_value_label = uiDocument.Q<Label>("popularity_value_label");
        instability_value_label = uiDocument.Q<Label>("instability_value_label");
        credibility_value_label = uiDocument.Q<Label>("credibility_value_label");
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
        EM.CheckCredibility();
        UpdateScores(EM.CalculatePopularity(), EM.CalculateInstability(), EM.newspaper.credibility);
        ShowReport();
    }

    private void ShowReport()
    {

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

    // Update is called once per frame
    void Update()
    {
    }
}


