using UnityEngine;

public abstract class Element
{
    public int popularity { get; set; }
    public int instability { get; set; }

    public double multiplier { get; set; }

    public Element(int popularity, int instability, double multiplier)
    {
        this.popularity = popularity;
        this.instability = instability;
        this.multiplier = multiplier;
    }

}

public class TextElement : Element
{
    public string text_value { get; set; }

    public TextElement(int popularity, int instability, double multiplier, string text_value) : base(popularity, instability, multiplier)
    {
        this.text_value = text_value;
    }
}

public class ImageElement : Element
{
    public ImageElement(int popularity, int instability, double multiplier) : base(popularity, instability, multiplier)
    {

    }
}


public static class CATEGORIES
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
    //Instability %
    public static int BORING_INSTABILITY = 0;
    public static int CONSERVATIVE_INSTABILITY = -10;
    public static int NEUTRAL_INSTABILITY_LIMIT_A = -3;
    public static int NEUTRAL_INSTABILITY_LIMIT_B = 3;
    public static int STIRRER_INSTABILITY = 10;
    public static int INCENDIARY_INSTABILITY = 20;
}
public static class SUBHEADINGS_VALUES
{
    //Popularity
    public static int BORING_POPULARITY = -250;
    public static int CONSERVATIVE_POPULARITY = 50;
    public static int NEUTRAL_POPULARITY = 0;
    public static int STIRRER_POPULARITY = 100;
    public static int INCENDIARY_POPULARITY = 500;
    //Instability %
    public static int BORING_INSTABILITY = 0;
    public static int CONSERVATIVE_INSTABILITY = -5;
    public static int NEUTRAL_INSTABILITY_LIMIT_A = -1;
    public static int NEUTRAL_INSTABILITY_LIMIT_B = 1;
    public static int STIRRER_INSTABILITY = 5;
    public static int INCENDIARY_INSTABILITY = 10;
}
public static class PHOTO_VALUES
{
    //Popularity
    public static int BORING_POPULARITY = -300;
    public static int CONSERVATIVE_POPULARITY = 60;
    public static int NEUTRAL_POPULARITY = 0;
    public static int STIRRER_POPULARITY = 150;
    public static int INCENDIARY_POPULARITY = 750;
    //Instability %
    public static int BORING_INSTABILITY = 0;
    public static int CONSERVATIVE_INSTABILITY = -6;
    public static int NEUTRAL_INSTABILITY_LIMIT_A = -2;
    public static int NEUTRAL_INSTABILITY_LIMIT_B = 2;
    public static int STIRRER_INSTABILITY = 6;
    public static int INCENDIARY_INSTABILITY = 20;
}

public static class CATEGORY_MULTIPLIERS
{
    public static double BORING_HEADING = -0.3;
    public static double CONSERVATIVE_HEADING = -0.2;
    public static double NEUTRAL_HEADING = 0;
    public static double STIRRER_HEADING = 0.2;
    public static double INCENDIARY_HEADING = 0.4;

    public static double BORING_SUBHEADING = -0.2;
    public static double CONSERVATIVE_SUBHEADING = -0.1;
    public static double NEUTRAL_SUBHEADING = 0;
    public static double STIRRER_SUBHEADING = 0.1;
    public static double INCENDIARY_SUBHEADING = 0.2;

    public static double BORING_PHOTO = -0.3;
    public static double CONSERVATIVE_PHOTO = -0.2;
    public static double NEUTRAL_PHOTO = 0;
    public static double STIRRER_PHOTO = 0.2;
    public static double INCENDIARY_PHOTO = 0.4;
}