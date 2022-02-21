using UnityEngine;

public class Element
{
    public int popularity { get; set; }
    public int inestability { get; set; }

    public Element(int popularity, int inestability)
    {
        this.popularity = popularity;
        this.inestability = inestability;
    }

}

public class TextElement : Element
{
    public string text_value { get; set; }

    public TextElement(int popularity, int inestability, string text_value) : base(popularity, inestability)
    {
        this.text_value = text_value;
    }
}

public class ImageElement : Element
{
    public ImageElement(int popularity, int inestability) : base(popularity, inestability)
    {

    }
}


public static class CATEGORIAS
{
    public static string BORING = "boring";
    public static string CONSERVATIVE = "conservative";
    public static string NEUTRAL = "neutral";
    public static string STIRRER = "stirrer";
    public static string INCENDIARY = "incendiary";
}


public static class URLS
{
    public static string IMAGES = "Assets/Images/";

    public static string HEADINGS = IMAGES + "Headings/heading_";
    public static string SUBHEADINGS = IMAGES + "Subheadings/subheading_";
    public static string PHOTOS = IMAGES + "Photos/photo_";

    public static string BORING = "boring.jpg";
    public static string CONSERVATIVE = "conservative.jpg";
    public static string NEUTRAL = "neutral.jpg";
    public static string INCENDIARY = "incendiary.jpg";
    public static string STIRRER = "stirrer.jpg";

}

public static class TITLE_VALUES
{
    //Popularity
    public static int BORING_POPULARITY = -500;
    public static int CONSERVATIVE_POPULARITY = 100;
    public static int NEUTRAL_POPULARITY = 0;
    public static int STIRRER_POPULARITY = 200;
    public static int INCENDIARY_POPULARITY = 1000;
    //Inestability %
    public static int BORING_INESTABILITY = 0;
    public static int CONSERVATIVE_INESTABILITY = -10;
    public static int NEUTRAL_INESTABILITY_LIMIT_A = -3;
    public static int NEUTRAL_INESTABILITY_LIMIT_B = 3;
    public static int STIRRER_INESTABILITY = 10;
    public static int INCENDIARY_INESTABILITY = 20;
}
public static class SUBHEADINGS_VALUES
{
    //Popularity
    public static int BORING_POPULARITY = -250;
    public static int CONSERVATIVE_POPULARITY = 50;
    public static int NEUTRAL_POPULARITY = 0;
    public static int STIRRER_POPULARITY = 100;
    public static int INCENDIARY_POPULARITY = 500;
    //Inestability %
    public static int BORING_INESTABILITY = 0;
    public static int CONSERVATIVE_INESTABILITY = -5;
    public static int NEUTRAL_INESTABILITY_LIMIT_A = -1;
    public static int NEUTRAL_INESTABILITY_LIMIT_B = 1;
    public static int STIRRER_INESTABILITY = 5;
    public static int INCENDIARY_INESTABILITY = 10;
}
public static class PHOTO_VALUES
{
    //Popularity
    public static int BORING_POPULARITY = -300;
    public static int CONSERVATIVE_POPULARITY = 60;
    public static int NEUTRAL_POPULARITY = 0;
    public static int STIRRER_POPULARITY = 150;
    public static int INCENDIARY_POPULARITY = 750;
    //Inestability %
    public static int BORING_INESTABILITY = 0;
    public static int CONSERVATIVE_INESTABILITY = -6;
    public static int NEUTRAL_INESTABILITY_LIMIT_A = -2;
    public static int NEUTRAL_INESTABILITY_LIMIT_B = 2;
    public static int STIRRER_INESTABILITY = 6;
    public static int INCENDIARY_INESTABILITY = 20;
}