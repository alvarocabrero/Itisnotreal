using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ElementManager : MonoBehaviour
{

    //private static int NUM_ELEMENTOS = 1;

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

        uiDocument.Q<Button>("SendButton").clicked += delegate { SendPoints(); };

        popularity_value = uiDocument.Q<Label>("popularity_value");
        instability_value = uiDocument.Q<Label>("instability_value");
    }

    public void SendPoints()
    {
        int popularityBaseValue = headings[selectedHeading].popularity + subheadings[selectedSubheading].popularity + photos[selectedPhoto].popularity;
        double popularityMultipliedValue = popularityBaseValue * (1.0 + headings[selectedHeading].multiplier + subheadings[selectedSubheading].multiplier + photos[selectedPhoto].multiplier);
        int popularityFinalValue = (int)popularityMultipliedValue;


        if (int.Parse(popularity_value.text) + popularityFinalValue <= 0)
            popularity_value.text = "0";
        popularity_value.text = (int.Parse(popularity_value.text) + popularityFinalValue).ToString();

        int instabilityBaseValue = headings[selectedHeading].instability + subheadings[selectedSubheading].instability + photos[selectedPhoto].instability;
        double instabilityMultipliedValue = instabilityBaseValue * (1.0 + headings[selectedHeading].multiplier + subheadings[selectedSubheading].multiplier + photos[selectedPhoto].multiplier);
        int instabilityFinalValue = (int)instabilityMultipliedValue;

        Debug.Log(instabilityFinalValue);

        if (int.Parse(instability_value.text) + instabilityFinalValue <= 0)
            instability_value.text = "0";
        else if (int.Parse(instability_value.text) + instabilityFinalValue >= 100)
            instability_value.text = "100";
        else
            instability_value.text = (int.Parse(instability_value.text) + instabilityFinalValue).ToString();

    }

    private void InitElements()
    {
        //headings
        headings.Add(new Element(TITLE_VALUES.BORING_POPULARITY, TITLE_VALUES.BORING_INSTABILITY, CATEGORY_MULTIPLIERS.BORING_HEADING));
        headings.Add(new Element(TITLE_VALUES.CONSERVATIVE_POPULARITY, TITLE_VALUES.CONSERVATIVE_INSTABILITY, CATEGORY_MULTIPLIERS.CONSERVATIVE_HEADING));
        headings.Add(new Element(TITLE_VALUES.NEUTRAL_POPULARITY, TITLE_VALUES.NEUTRAL_INSTABILITY_LIMIT_A, CATEGORY_MULTIPLIERS.NEUTRAL_HEADING));
        headings.Add(new Element(TITLE_VALUES.INCENDIARY_POPULARITY, TITLE_VALUES.INCENDIARY_INSTABILITY, CATEGORY_MULTIPLIERS.INCENDIARY_HEADING));
        headings.Add(new Element(TITLE_VALUES.STIRRER_POPULARITY, TITLE_VALUES.STIRRER_INSTABILITY, CATEGORY_MULTIPLIERS.STIRRER_HEADING));

        subheadings.Add(new Element(SUBHEADINGS_VALUES.BORING_POPULARITY, SUBHEADINGS_VALUES.BORING_INSTABILITY, CATEGORY_MULTIPLIERS.BORING_SUBHEADING));
        subheadings.Add(new Element(SUBHEADINGS_VALUES.CONSERVATIVE_POPULARITY, SUBHEADINGS_VALUES.CONSERVATIVE_INSTABILITY, CATEGORY_MULTIPLIERS.CONSERVATIVE_SUBHEADING));
        subheadings.Add(new Element(SUBHEADINGS_VALUES.NEUTRAL_POPULARITY, SUBHEADINGS_VALUES.NEUTRAL_INSTABILITY_LIMIT_A, CATEGORY_MULTIPLIERS.NEUTRAL_SUBHEADING));
        subheadings.Add(new Element(SUBHEADINGS_VALUES.INCENDIARY_POPULARITY, SUBHEADINGS_VALUES.INCENDIARY_INSTABILITY, CATEGORY_MULTIPLIERS.INCENDIARY_SUBHEADING));
        subheadings.Add(new Element(SUBHEADINGS_VALUES.STIRRER_POPULARITY, SUBHEADINGS_VALUES.STIRRER_INSTABILITY, CATEGORY_MULTIPLIERS.STIRRER_SUBHEADING));

        photos.Add(new Element(PHOTO_VALUES.BORING_POPULARITY, PHOTO_VALUES.BORING_INSTABILITY, CATEGORY_MULTIPLIERS.BORING_PHOTO));
        photos.Add(new Element(PHOTO_VALUES.CONSERVATIVE_POPULARITY, PHOTO_VALUES.CONSERVATIVE_INSTABILITY, CATEGORY_MULTIPLIERS.CONSERVATIVE_PHOTO));
        photos.Add(new Element(PHOTO_VALUES.NEUTRAL_POPULARITY, PHOTO_VALUES.NEUTRAL_INSTABILITY_LIMIT_A, CATEGORY_MULTIPLIERS.NEUTRAL_PHOTO));
        photos.Add(new Element(PHOTO_VALUES.INCENDIARY_POPULARITY, PHOTO_VALUES.INCENDIARY_INSTABILITY, CATEGORY_MULTIPLIERS.INCENDIARY_HEADING));
        photos.Add(new Element(PHOTO_VALUES.STIRRER_POPULARITY, PHOTO_VALUES.STIRRER_INSTABILITY, CATEGORY_MULTIPLIERS.STIRRER_PHOTO));
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
