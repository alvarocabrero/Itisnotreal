using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainApp : MonoBehaviour
{
    ElementManager EM;

    private int selectedHeading = 0;
    private int selectedSubheading = 0;
    private int selectedPhoto = 0;

    public static SpriteRenderer headingSpriteUI, subheadingSpriteUI, photoSpriteUI;

    public List<Sprite> headingSprites, subheadingSprites, photoSprites = new List<Sprite>();

    public ElementStorage elementStorage;

    private Label popularity_value_label;
    private Label instability_value_label;
    private Label credibility_value_label;
    // Start is called before the first frame update
    void Start()
    {
        InitElementManager();

        var uiDocument = GameObject.Find("UIDocument").GetComponent<UIDocument>().rootVisualElement;

        uiDocument.Q<Button>("PublishButton").clicked += delegate { Publish(); };

        popularity_value_label = uiDocument.Q<Label>("popularity_value_label");
        instability_value_label = uiDocument.Q<Label>("instability_value_label");
        credibility_value_label = uiDocument.Q<Label>("credibility_value_label");

        UpdateCredibilityScore(EM.newspaper.credibility);
        UpdatePopularityScore(EM.newspaper.popularity);
        UpdateInstabilityScore(EM.newspaper.instability);
    }

    private void InitElementManager()
    {
        List<Heading> headings = new List<Heading>();
        List<Subheading> subheadings = new List<Subheading>();
        List<Photo> photos = new List<Photo>();

        headings.Add(new Heading(new Boring(), Resources.Load<Sprite>("Photos/war_boring_heading")));
        headings.Add(new Heading(new Conservative(), Resources.Load<Sprite>("Photos/war_conservative_heading")));
        headings.Add(new Heading(new Neutral(), Resources.Load<Sprite>("Photos/war_neutral_heading")));
        headings.Add(new Heading(new Stirrer(), Resources.Load<Sprite>("Photos/war_stirrer_heading")));
        headings.Add(new Heading(new Incendiary(), Resources.Load<Sprite>("Photos/war_incendiary_heading")));

        subheadings.Add(new Subheading(new Boring(), subheadingSprites[0]));
        subheadings.Add(new Subheading(new Conservative(), subheadingSprites[1]));
        subheadings.Add(new Subheading(new Neutral(), subheadingSprites[2]));
        subheadings.Add(new Subheading(new Stirrer(), subheadingSprites[3]));
        subheadings.Add(new Subheading(new Incendiary(), subheadingSprites[4]));

        photos.Add(new Photo(new Boring(), photoSprites[0]));
        photos.Add(new Photo(new Conservative(), photoSprites[1]));
        photos.Add(new Photo(new Neutral(), photoSprites[2]));
        photos.Add(new Photo(new Stirrer(), photoSprites[3]));
        photos.Add(new Photo(new Incendiary(), photoSprites[4]));

        Debug.Log(headings);

        EM = new ElementManager(headings, subheadings, photos);
    }

    public void Publish()
    {
        EM.CheckCredibility();
        UpdateScores();
        ShowReport();
    }

    private void ShowReport()
    {

    }

    private void UpdateScores()
    {
        UpdatePopularityScore(EM.CalculatePopularity());
        UpdateInstabilityScore(EM.CalculateInstability());
        UpdateCredibilityScore(EM.newspaper.credibility);
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

    public int NextElement(List<GameObject> list, SpriteRenderer renderer, ref int selectedElement)
    {
        if (selectedElement + 1 < list.Count)
        {
            selectedElement += 1;
        }
        else
            selectedElement = 0;
        return selectedElement;
    }

    public void NextHeading()
    {
        headingSpriteUI.sprite = EM.NextHeading().GetSprite();
    }

    public void NextSubheading()
    {
        subheadingSpriteUI.sprite = EM.NextSubheading().GetSprite();
    }

    public void NextPhoto()
    {
        photoSpriteUI.sprite = EM.NextPhoto().GetSprite();
    }

    // Update is called once per frame
    void Update()
    {
    }
}

public static class DIFICULTY_LEVELS
{
    public static int EASY = 0;
    public static int MEDIUM = 1;
    public static int HARD = 2;
}
