using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainApp : MonoBehaviour
{
    ElementManager EM = new ElementManager();

    private int selectedHeading = 0;
    private int selectedSubheading = 0;
    private int selectedPhoto = 0;

    public SpriteRenderer headingSpriteR, subheadingSpriteR, photoSpriteR;

    public List<GameObject> headingSprites, subheadingSprites, photoSprites = new List<GameObject>();

    private Label popularity_value_label;
    private Label instability_value_label;
    private Label credibility_value_label;
    // Start is called before the first frame update
    void Start()
    {
        var uiDocument = GameObject.Find("UIDocument").GetComponent<UIDocument>().rootVisualElement;

        uiDocument.Q<Button>("PublishButton").clicked += delegate { Publish(); };

        popularity_value_label = uiDocument.Q<Label>("popularity_value_label");
        instability_value_label = uiDocument.Q<Label>("instability_value_label");
        credibility_value_label = uiDocument.Q<Label>("credibility_value_label"); 

        UpdateCredibilityScore(EM.newspaper.credibility);
        UpdatePopularityScore(EM.newspaper.popularity);
        UpdateInstabilityScore(EM.newspaper.instability);
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
        renderer.sprite = list[selectedElement].GetComponent<SpriteRenderer>().sprite;
        return selectedElement;
    }

    public void NextHeading()
    {
        NextElement(headingSprites, headingSpriteR, ref selectedHeading);
    }

    public void NextSubheading()
    {
        NextElement(subheadingSprites, subheadingSpriteR, ref selectedSubheading);
    }

    public void NextPhoto()
    {
        NextElement(photoSprites, photoSpriteR, ref selectedPhoto);
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
