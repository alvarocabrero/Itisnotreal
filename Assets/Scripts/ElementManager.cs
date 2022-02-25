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
        double popularityMultipliedValue = popularityBaseValue * (1.0 + selectedHeading.GetMultiplier() + selectedSubheading.GetMultiplier() + selectedPhoto.GetMultiplier());
        return (int)popularityMultipliedValue;
    }

    public int CalculateInstability()
    {
        int instabilityBaseValue = selectedHeading.GetCategory().GetInstability() + selectedSubheading.GetCategory().GetInstability() + selectedPhoto.GetCategory().GetInstability();
        double instabilityMultipliedValue = instabilityBaseValue * (1.0 + selectedHeading.GetMultiplier() + selectedSubheading.GetMultiplier() + selectedPhoto.GetMultiplier());
        return (int)instabilityMultipliedValue;
    }

    public Heading NextHeading()
    {
        if (headings.IndexOf(selectedHeading) + 1 <= headings.Count - 1)
            selectedHeading = headings[headings.IndexOf(selectedHeading) + 1];
        else
            selectedHeading = headings[0];
        return selectedHeading;
    }

    public Subheading NextSubheading()
    {
        if (subheadings.IndexOf(selectedSubheading) + 1 <= subheadings.Count - 1)
            selectedSubheading = subheadings[subheadings.IndexOf(selectedSubheading) + 1];
        else
            selectedSubheading = subheadings[0];
        return selectedSubheading;
    }

    public Photo NextPhoto()
    {
        if (photos.IndexOf(selectedPhoto) + 1 <= photos.Count - 1)
            selectedPhoto = photos[photos.IndexOf(selectedPhoto) + 1];
        else
            selectedPhoto = photos[0];
        return selectedPhoto;
    }
}
