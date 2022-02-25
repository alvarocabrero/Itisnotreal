using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ElementManager
{

    //private static int NUM_ELEMENTOS = 1;

    public Newspaper newspaper = new Newspaper(DIFICULTY_LEVELS.MEDIUM);


    private List<Subheading> subheadings = new List<Subheading>();
    private List<Heading> headings = new List<Heading>();
    private List<Photo> photos = new List<Photo>();


    public Heading selectedHeading;
    public Subheading selectedSubheading;
    public Photo selectedPhoto;

    public ElementManager(List<Heading> headings, List<Subheading> subheadings, List<Photo> photos)
    {
        this.headings = headings;
        this.subheadings = subheadings;
        this.photos = photos;
        selectedHeading = headings[0];
        selectedSubheading = subheadings[0];
        selectedPhoto = photos[0];
    }

    public void CheckCredibility()
    {
        float totalDetectionRisk = 0f;
        foreach (var e in GetAllIElements())
        {
            totalDetectionRisk += e.GetDetectionRisk();
        }
        if (UnityEngine.Random.Range(0f, 1f) < totalDetectionRisk)
        {
            newspaper.DecrementCredibility();
        }
    }

    private List<IElement> GetAllIElements()
    {
        List<IElement> elements = new List<IElement>();
        elements.Add(selectedHeading);
        elements.Add(selectedSubheading);
        elements.Add(selectedPhoto);
        return elements;
    }

    public int CalculatePopularity()
    {
        int popularityBaseValue = selectedHeading.GetCategory().GetPopularity() + selectedSubheading.GetCategory().GetPopularity() + selectedPhoto.GetCategory().GetPopularity();
        double popularityMultipliedValue = popularityBaseValue * (1.0 + selectedHeading.GetCategory().GetPopularity() + selectedSubheading.GetCategory().GetPopularity() + selectedPhoto.GetCategory().GetPopularity());
        return (int)popularityMultipliedValue;
    }

    public int CalculateInstability()
    {
        int instabilityBaseValue = selectedHeading.GetCategory().GetInstability() + selectedSubheading.GetCategory().GetInstability() + selectedPhoto.GetCategory().GetInstability();
        double instabilityMultipliedValue = instabilityBaseValue * (1.0 + selectedHeading.GetCategory().GetInstability() + selectedSubheading.GetCategory().GetInstability() + selectedPhoto.GetCategory().GetInstability());
        return (int)instabilityMultipliedValue;
    }

    public Heading NextHeading()
    {
        selectedHeading = headings[headings.IndexOf(selectedHeading) + 1];
        return selectedHeading;
    }

    public Subheading NextSubheading()
    {
        return selectedSubheading = subheadings[subheadings.IndexOf(selectedSubheading) + 1];
    }

    public Photo NextPhoto()
    {
        return selectedPhoto = photos[photos.IndexOf(selectedPhoto) + 1];
    }
}
