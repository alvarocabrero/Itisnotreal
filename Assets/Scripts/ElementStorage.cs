

using System;
using System.Collections.Generic;
using UnityEngine;

public class ElementStorage
{
    public const string HEADING = "heading";
    public const string SUBHEADING = "subheading";
    public const string PHOTO = "photo";

    public List<IElement> all_elements = new List<IElement>();
    public ElementStorage(List<GameObject> headingSprites, List<GameObject> subheadingSprites, List<GameObject> photoSprites)
    {
        AddElements(headingSprites, HEADING);
        AddElements(subheadingSprites, SUBHEADING);
        AddElements(photoSprites, PHOTO);
    }

    internal List<Photo> GetPhotos(string theme)
    {
        List<Photo> photos = new List<Photo>();
        foreach (IElement element in all_elements)
        {
            if (element is Photo)
                if (element.GetTheme().Equals(theme))
                {
                    Photo photo = (Photo)element;
                    photos.Add(photo);
                }

        }

        if (photos.Count == 0)
            Debug.LogError("theme not found");
        return photos;
    }

    internal List<Heading> GetHeadings(string theme)
    {
        List<Heading> hedings = new List<Heading>();
        foreach (IElement element in all_elements)
        {
            if (element is Heading)
                if (element.GetTheme().Equals(theme))
                {
                    Heading heding = (Heading)element;
                    hedings.Add(heding);
                }

        }

        if (hedings.Count == 0)
            Debug.LogError("theme not found");
        return hedings;
    }

    internal List<Subheading> GetSubheadings(string theme)
    {
        List<Subheading> subhedings = new List<Subheading>();
        foreach (IElement element in all_elements)
        {
            if (element is Subheading)
                if (element.GetTheme().Equals(theme))
                {
                    Subheading subheding = (Subheading)element;
                    subhedings.Add(subheding);
                }

        }

        if (subhedings.Count == 0)
            Debug.LogError("theme not found");
        return subhedings;
    }
    public Heading GetHeading(string theme, ICategory category)
    {
        foreach (IElement element in all_elements)
        {
            if (element is Heading)
                if (element.GetTheme().Equals(theme))
                    if (element.GetCategory().Equals(category.GetCategory()))
                    {
                        Heading title = (Heading)element;

                        return title;
                    }
        }
        Debug.LogError("element not found");
        return null;
    }
    public Subheading GetSubHeading(string theme, ICategory category)
    {
        foreach (IElement element in all_elements)
        {
            if (element is Subheading)
                if (element.GetTheme().Equals(theme))
                    if (element.GetCategory().Equals(category.GetCategory()))
                    {
                        Subheading title = (Subheading)element;

                        return title;
                    }
        }
        Debug.LogError("element not found");
        return null;
    }
    public Photo GetPhoto(string theme, ICategory category)
    {
        foreach (IElement element in all_elements)
        {
            if (element is Photo)
                if (element.GetTheme().Equals(theme))
                    if (element.GetCategory().Equals(category.GetCategory()))
                    {
                        Photo title = (Photo)element;

                        return title;
                    }
        }
        Debug.LogError("element not found");
        return null;
    }
    private void AddElements(List<GameObject> sprites, string type)
    {
        foreach (GameObject sprite in sprites)
        {
            SpriteRenderer spriterenderer = sprite.GetComponent<SpriteRenderer>();

            string category = CATEGORIES.GetCategory(sprite.name);

            //Category to add
            ICategory category_value = null;
            switch (category)
            {
                case CATEGORIES.BORING:
                    category_value = new Boring();
                    break;
                case CATEGORIES.CONSERVATIVE:
                    category_value = new Conservative();
                    break;
                case CATEGORIES.NEUTRAL:
                    category_value = new Neutral();
                    break;
                case CATEGORIES.STIRRER:
                    category_value = new Stirrer();
                    break;
                case CATEGORIES.INCENDIARY:
                    category_value = new Incendiary();
                    break;
            }
            if (category_value == null)
            {
                Debug.LogError("Categoria inexistente");
            }

            string theme = THEME.GetTheme(sprite.name);
            bool fake = false;
            if (sprite.name.Contains("fake"))
                fake = true;
            switch (type)
            {
                case HEADING:
                    {

                        all_elements.Add(new Heading(category_value, spriterenderer, theme, 0.5f, 0.1f, fake));
                        break;
                    }
                case SUBHEADING:
                    {
                        all_elements.Add(new Subheading(category_value, spriterenderer, theme, 0.1f, 0.025f, fake));
                        break;
                    }
                case PHOTO:
                    {
                        all_elements.Add(new Photo(category_value, spriterenderer, theme, 0.1f, 0.05f, fake));
                        break;
                    }
                default:
                    {
                        Debug.LogError("El tipo no existe heading, subheading o photo");
                        break;
                    }
            }

        }


    }


}

