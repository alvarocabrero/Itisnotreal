using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ElementManager : MonoBehaviour
{

    //private static int NUM_ELEMENTOS = 1;

    private Newspaper newspaper = new Newspaper();

    private List<Element> photos = new List<Element>();
    private List<Element> subheadings = new List<Element>();
    private List<Element> headings = new List<Element>();

    private int selectedHeading = 0;
    private int selectedSubheading = 0;
    private int selectedPhoto = 0;

    public SpriteRenderer headingSpriteR, subheadingSpriteR, photoSpriteR;

    public List<GameObject> headingSprites, subheadingSprites, photoSprites = new List<GameObject>();

    private Label popularity_value;
    private Label instability_value;
    // Start is called before the first frame update
    void Start()
    {
        InitElements();

        var uiDocument = GameObject.Find("UIDocument").GetComponent<UIDocument>().rootVisualElement;

        uiDocument.Q<Button>("PublishButton").clicked += delegate { Publish(); };

        popularity_value = uiDocument.Q<Label>("popularity_value");
        instability_value = uiDocument.Q<Label>("instability_value");
    }

    public void Publish()
    {
        UpdateScores();
        CheckCredibility();
    }

    private void CheckCredibility()
    {
        float totalDetectionRisk = 0f;
        foreach (var e in GetAllElements())
        {
            totalDetectionRisk += e.detectionRisk;
        }
        if (UnityEngine.Random.Range(0f, 1f) < totalDetectionRisk)
        {
            newspaper.DecrementCredibility();
        }
    }

    private List<Element> GetAllElements()
    {
        List<Element> elements = new List<Element>();
        elements.Add(headings[selectedHeading]);
        elements.Add(subheadings[selectedSubheading]);
        elements.Add(photos[selectedPhoto]);
        return elements;
    }

    private void UpdateScores()
    {
        UpdatePopularityScore(CalculatePopularity());
        UpdateInstabilityScore(CalculateInstability());
    }

    private void UpdateInstabilityScore(int instabilityFinalValue)
    {
        if (int.Parse(instability_value.text) + instabilityFinalValue <= 0)
        {
            //@TODO A�ADIR FINAL DE JUEGO
            instability_value.text = "0";
        }
        else if (int.Parse(instability_value.text) + instabilityFinalValue >= 100)
        {
            //@TODO A�ADIR FINAL DE JUEGO
            instability_value.text = "100";
        }
        else
            instability_value.text = (int.Parse(instability_value.text) + instabilityFinalValue).ToString();
    }

    private void UpdatePopularityScore(int popularityFinalValue)
    {
        if (int.Parse(popularity_value.text) + popularityFinalValue <= 0)
            popularity_value.text = "0";
        else
            popularity_value.text = (int.Parse(popularity_value.text) + popularityFinalValue).ToString();
    }

    private int CalculatePopularity()
    {
        int popularityBaseValue = headings[selectedHeading].popularity + subheadings[selectedSubheading].popularity + photos[selectedPhoto].popularity;
        double popularityMultipliedValue = popularityBaseValue * (1.0 + headings[selectedHeading].multiplier + subheadings[selectedSubheading].multiplier + photos[selectedPhoto].multiplier);
        return (int)popularityMultipliedValue;
    }

    private int CalculateInstability()
    {
        int instabilityBaseValue = headings[selectedHeading].instability + subheadings[selectedSubheading].instability + photos[selectedPhoto].instability;
        double instabilityMultipliedValue = instabilityBaseValue * (1.0 + headings[selectedHeading].multiplier + subheadings[selectedSubheading].multiplier + photos[selectedPhoto].multiplier);
        return (int)instabilityMultipliedValue;
    }



    private void InitElements()
    {
        //headings
        for (int i = 0; i < TITLE_VALUES.POPULARITIES.Length; i++)
        {
            //Hay que meterlos siempre en orden en elementos y siempre tener el mismo numero pero bueno es una solucion a no tener pila adds
            //headings
            headings.Add(new Element(TITLE_VALUES.POPULARITIES[i], TITLE_VALUES.INSTABILITY[i], TITLE_VALUES.MULTIPLIERS[i]));
            //subheadings
            subheadings.Add(new Element(SUBHEADINGS_VALUES.POPULARITIES[i], SUBHEADINGS_VALUES.INSTABILITY[i], SUBHEADINGS_VALUES.MULTIPLIERS[i]));
            //photos
            photos.Add(new Element(PHOTO_VALUES.POPULARITIES[i], PHOTO_VALUES.INSTABILITY[i], PHOTO_VALUES.MULTIPLIERS[i]));
        }
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
