

using System;
using System.Collections.Generic;
using UnityEngine;

public class ElementStorage
{
    private List<GameObject> headingSprites;
    private List<GameObject> subheadingSprites;
    private List<GameObject> photoSprites;


    //public Dictionary<string, Dictionary<string, IElement>> diccionarioSprites = new Dictionary<string, Dictionary<string, Element>>();


    public ElementStorage(List<GameObject> headingSprites, List<GameObject> subheadingSprites, List<GameObject> photoSprites)
    {
        this.headingSprites = headingSprites;
        this.subheadingSprites = subheadingSprites;
        this.photoSprites = photoSprites;
        //SortSprites();

    }
    /**
        private void SortSprites()
        {
            foreach (GameObject spriteHeading in headingSprites)
            {
                SpriteRenderer sprite = spriteHeading.GetComponent<SpriteRenderer>();

                string theme = THEME.GetTheme(spriteHeading.name);
                string category = CATEGORIES.GetCategory(spriteHeading.name);
                Dictionary<string, Element> categorias = new Dictionary<string, Element>();

                if (!diccionarioSprites.TryGetValue(theme, out categorias))
                {
                    diccionarioSprites.Add(theme, new Dictionary<string, Element>());
                }

                Element categoria;
                if (categorias.TryGetValue(category, out categoria))
                {
                    categoria.sprite = spriteHeading.GetComponent<SpriteRenderer>();
                }
                else
                {
                    categorias.Add(category, new Element(TITLE_VALUES.GetPopularity(category), TITLE_VALUES.GetInstability(category), TITLE_VALUES.GetMultipliers(category), sprite));
                }

            }

            foreach (GameObject spritesubHeading in subheadingSprites)
            {
                SpriteRenderer sprite = spritesubHeading.GetComponent<SpriteRenderer>();

                string theme = THEME.GetTheme(spritesubHeading.name);
                string category = CATEGORIES.GetCategory(spritesubHeading.name);
                Dictionary<string, Element> categorias = new Dictionary<string, Element>();

                if (!diccionarioSprites.TryGetValue(theme, out categorias))
                {
                    diccionarioSprites.Add(theme, new Dictionary<string, Element>());
                }

                Element categoria;
                if (categorias.TryGetValue(category, out categoria))
                {
                    categoria.sprite = spritesubHeading.GetComponent<SpriteRenderer>();
                }
                else
                {
                    categorias.Add(category, new Element(SUBHEADINGS_VALUES.GetPopularity(category), SUBHEADINGS_VALUES.GetInstability(category), SUBHEADINGS_VALUES.GetMultipliers(category), sprite));
                }

            }

            foreach (GameObject spritePhotos in photoSprites)
            {
                SpriteRenderer sprite = spritePhotos.GetComponent<SpriteRenderer>();

                string theme = THEME.GetTheme(spritePhotos.name);
                string category = CATEGORIES.GetCategory(spritePhotos.name);
                Dictionary<string, Element> categorias = new Dictionary<string, Element>();

                if (!diccionarioSprites.TryGetValue(theme, out categorias))
                {
                    diccionarioSprites.Add(theme, new Dictionary<string, Element>());
                }

                Element categoria;
                if (categorias.TryGetValue(category, out categoria))
                {
                    categoria.sprite = spritePhotos.GetComponent<SpriteRenderer>();
                }
                else
                {
                    categorias.Add(category, new Element(PHOTO_VALUES.GetPopularity(category), PHOTO_VALUES.GetInstability(category), PHOTO_VALUES.GetMultipliers(category), sprite));
                }

            }
        }
    **/

}

public static class THEME
{
    private static string WAR = "war";
    private static string SALSEO = "salseo";
    private static string HEALTH = "health";

    public static string[] THEME_LIST = { WAR, SALSEO, HEALTH };


    public static string GetTheme(string theme)
    {
        foreach (string t in THEME.THEME_LIST)
        {
            if (theme.Contains(t))
                return t;
        }
        return "";
    }
}
