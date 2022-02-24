using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ElementManager
{

    //private static int NUM_ELEMENTOS = 1;

    public Newspaper newspaper = new Newspaper(DIFICULTY_LEVELS.MEDIUM);

    private List<Element> photos = new List<Element>();
    private List<Element> subheadings = new List<Element>();
    private List<Element> headings = new List<Element>();


    private int selectedHeading = 0;
    private int selectedSubheading = 0;
    private int selectedPhoto = 0;

    public ElementManager()
    {

    }

    public void CheckCredibility()
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

    public int CalculatePopularity()
    {
        int popularityBaseValue = headings[selectedHeading].popularity + subheadings[selectedSubheading].popularity + photos[selectedPhoto].popularity;
        double popularityMultipliedValue = popularityBaseValue * (1.0 + headings[selectedHeading].multiplier + subheadings[selectedSubheading].multiplier + photos[selectedPhoto].multiplier);
        return (int)popularityMultipliedValue;
    }

    public int CalculateInstability()
    {
        int instabilityBaseValue = headings[selectedHeading].instability + subheadings[selectedSubheading].instability + photos[selectedPhoto].instability;
        double instabilityMultipliedValue = instabilityBaseValue * (1.0 + headings[selectedHeading].multiplier + subheadings[selectedSubheading].multiplier + photos[selectedPhoto].multiplier);
        return (int)instabilityMultipliedValue;
    }

    private void SetElements(List<Element> headings, List<Element> subheadings, List<Element> photos)
    {
        this.headings.AddRange(headings);
        this.subheadings.AddRange(subheadings);
        this.photos.AddRange(photos);
    }


}
