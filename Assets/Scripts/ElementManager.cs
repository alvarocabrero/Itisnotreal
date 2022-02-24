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
        InitElements();
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
}
