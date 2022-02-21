using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ElementManager : MonoBehaviour
{

    private static int NUM_ELEMENTOS = 1;

    private List<ImageElement> imagenes = new List<ImageElement>();
    private List<TextElement> subtitulos = new List<TextElement>();
    private List<TextElement> titulos = new List<TextElement>();

    private int selectedTitle = 0;

    private SpriteRenderer sprite;

    public List<GameObject> sprites = new List<GameObject>();

    private Label popularity_value;
    private Label inestability_value;
    // Start is called before the first frame update
    void Start()
    {
        InitElements();
        sprite = GetComponent<SpriteRenderer>();

        var uiDocument = GameObject.Find("UIDocument").GetComponent<UIDocument>().rootVisualElement;

        uiDocument.Q<Button>("NextTitle").clicked += delegate { NextTitle(); };
        uiDocument.Q<Button>("SendButton").clicked += delegate { SendPoints(); };

        popularity_value = uiDocument.Q<Label>("popularity_value");
        inestability_value = uiDocument.Q<Label>("inestability_value");
    }

    public void SendPoints()
    {
        popularity_value.text = (int.Parse(popularity_value.text) + titulos[selectedTitle].popularity).ToString();
        inestability_value.text = (int.Parse(inestability_value.text) + titulos[selectedTitle].inestability).ToString();
    }

    private void InitElements()
    {
        //TITULOS
        titulos.Add(new TextElement(TITLE_VALUES.BORING_POPULARITY, TITLE_VALUES.BORING_INESTABILITY, CATEGORIAS.BORING));
        titulos.Add(new TextElement(TITLE_VALUES.CONSERVATIVE_POPULARITY, TITLE_VALUES.CONSERVATIVE_INESTABILITY, CATEGORIAS.CONSERVATIVE));
        titulos.Add(new TextElement(TITLE_VALUES.NEUTRAL_POPULARITY, 244, CATEGORIAS.NEUTRAL));
        titulos.Add(new TextElement(TITLE_VALUES.INCENDIARY_POPULARITY, TITLE_VALUES.INCENDIARY_INESTABILITY, CATEGORIAS.INCENDIARY));
        titulos.Add(new TextElement(TITLE_VALUES.STIRRER_POPULARITY, TITLE_VALUES.STIRRER_INESTABILITY, CATEGORIAS.STIRRER));

    }

    public void NextTitle()
    {
        Debug.Log(sprites.Count);
        Debug.Log(selectedTitle);
        if (selectedTitle + 1 < sprites.Count)
        {
            selectedTitle += 1;
        }
        else
            selectedTitle = 0;
        sprite.sprite = sprites[selectedTitle].GetComponent<SpriteRenderer>().sprite;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
