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

    public List<Sprite> headingSprites, subheadingSprites, photoSprites = new List<Sprite>();

    public ElementStorage elementStorage;

    private Label popularity_value_label;
    private Label instability_value_label;
    private Label credibility_value_label;
    private readonly bool FAKE = true;

    // Start is called before the first frame update
    void Start()
    {
        InitElementManager();

        InitUI();



        UpdateScores(EM.newspaper.popularity, EM.newspaper.instability, EM.newspaper.credibility);
    }


    private void InitElementManager()
    {
        List<Heading> headings = new List<Heading>();
        List<Subheading> subheadings = new List<Subheading>();
        List<Photo> photos = new List<Photo>();

        headings.Add(new Heading(new Boring(), headingSprites[0]));
        headings.Add(new Heading(new Conservative(), headingSprites[1]));
        headings.Add(new Heading(new Neutral(), headingSprites[2]));
        headings.Add(new Heading(new Stirrer(), headingSprites[3]));
        headings.Add(new Heading(new Incendiary(), headingSprites[4], FAKE));

        subheadings.Add(new Subheading(new Boring(), subheadingSprites[0]));
        subheadings.Add(new Subheading(new Conservative(), subheadingSprites[1]));
        subheadings.Add(new Subheading(new Neutral(), subheadingSprites[2]));
        subheadings.Add(new Subheading(new Stirrer(), subheadingSprites[3]));
        subheadings.Add(new Subheading(new Incendiary(), subheadingSprites[4]));

        photos.Add(new Photo(new Boring(), photoSprites[0]));
        photos.Add(new Photo(new Conservative(), photoSprites[1], FAKE));
        photos.Add(new Photo(new Neutral(), photoSprites[2]));
        photos.Add(new Photo(new Stirrer(), photoSprites[3]));
        photos.Add(new Photo(new Incendiary(), photoSprites[4]));

        EM = new ElementManager(headings, subheadings, photos);
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
