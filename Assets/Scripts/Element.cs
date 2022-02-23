using UnityEngine;

public class Element
{
    public int popularity { get; set; }
    public int instability { get; set; }
    public float detectionRisk { get; set; }
    public double multiplier { get; set; }


    public Element(int popularity, int instability, double multiplier)
    {
        this.popularity = popularity;
        this.instability = instability;
        this.multiplier = multiplier;
        this.detectionRisk = 0.1f;
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
    private static int BORING_POPULARITY = -500;
    private static int CONSERVATIVE_POPULARITY = 100;
    private static int NEUTRAL_POPULARITY = 0;
    private static int STIRRER_POPULARITY = 200;
    private static int INCENDIARY_POPULARITY = 1000;
    //Instability %
    private static int BORING_INSTABILITY = 0;
    private static int CONSERVATIVE_INSTABILITY = -10;
    private static int NEUTRAL_INSTABILITY_LIMIT_A = -3;
    private static int NEUTRAL_INSTABILITY_LIMIT_B = 3;
    private static int STIRRER_INSTABILITY = 10;
    private static int INCENDIARY_INSTABILITY = 20;

    //Multipliers
    private static double BORING_MULTIPLIER = -0.3;
    private static double CONSERVATIVE_MULTIPLIER = -0.2;
    private static double NEUTRAL_MULTIPLIER = 0;
    private static double STIRRER_MULTIPLIER = 0.2;
    private static double INCENDIARY_MULTIPLIER = 0.4;

    public static int[] POPULARITIES = { BORING_POPULARITY, CONSERVATIVE_POPULARITY, NEUTRAL_POPULARITY, STIRRER_POPULARITY, INCENDIARY_POPULARITY };
    public static int[] INSTABILITY = { BORING_INSTABILITY, CONSERVATIVE_INSTABILITY, NEUTRAL_INSTABILITY_LIMIT_A, STIRRER_INSTABILITY, INCENDIARY_INSTABILITY };
    public static double[] MULTIPLIERS = { BORING_MULTIPLIER, CONSERVATIVE_MULTIPLIER, NEUTRAL_MULTIPLIER, STIRRER_MULTIPLIER, INCENDIARY_MULTIPLIER };

}
public static class SUBHEADINGS_VALUES
{

    //Popularity
    private static int BORING_POPULARITY = -250;
    private static int CONSERVATIVE_POPULARITY = 50;
    private static int NEUTRAL_POPULARITY = 0;
    private static int STIRRER_POPULARITY = 100;
    private static int INCENDIARY_POPULARITY = 500;
    //Instability %
    private static int BORING_INSTABILITY = 0;
    private static int CONSERVATIVE_INSTABILITY = -5;
    private static int NEUTRAL_INSTABILITY_LIMIT_A = -1;
    private static int NEUTRAL_INSTABILITY_LIMIT_B = 1;
    private static int STIRRER_INSTABILITY = 5;
    private static int INCENDIARY_INSTABILITY = 10;
    //Multipliers
    private static double BORING_MULTIPLIER = -0.2;
    private static double CONSERVATIVE_MULTIPLIER = -0.1;
    private static double NEUTRAL_MULTIPLIER = 0;
    private static double STIRRER_MULTIPLIER = 0.1;
    private static double INCENDIARY_MULTIPLIER = 0.2;

    public static int[] POPULARITIES = { BORING_POPULARITY, CONSERVATIVE_POPULARITY, NEUTRAL_POPULARITY, STIRRER_POPULARITY, INCENDIARY_POPULARITY };
    public static int[] INSTABILITY = { BORING_INSTABILITY, CONSERVATIVE_INSTABILITY, NEUTRAL_INSTABILITY_LIMIT_A, STIRRER_INSTABILITY, INCENDIARY_INSTABILITY };
    public static double[] MULTIPLIERS = { BORING_MULTIPLIER, CONSERVATIVE_MULTIPLIER, NEUTRAL_MULTIPLIER, STIRRER_MULTIPLIER, INCENDIARY_MULTIPLIER };


}
public static class PHOTO_VALUES
{

    //Popularity
    private static int BORING_POPULARITY = -300;
    private static int CONSERVATIVE_POPULARITY = 60;
    private static int NEUTRAL_POPULARITY = 0;
    private static int STIRRER_POPULARITY = 150;
    private static int INCENDIARY_POPULARITY = 750;
    //Instability %
    private static int BORING_INSTABILITY = 0;
    private static int CONSERVATIVE_INSTABILITY = -6;
    private static int NEUTRAL_INSTABILITY_LIMIT_A = -2;
    private static int NEUTRAL_INSTABILITY_LIMIT_B = 2;
    private static int STIRRER_INSTABILITY = 6;
    private static int INCENDIARY_INSTABILITY = 20;

    //Multipliers
    private static double BORING_MULTIPLIER = -0.3;
    private static double CONSERVATIVE_MULTIPLIER = -0.2;
    private static double NEUTRAL_MULTIPLIER = 0;
    private static double STIRRER_MULTIPLIER = 0.2;
    private static double INCENDIARY_MULTIPLIER = 0.4;

    public static int[] POPULARITIES = { BORING_POPULARITY, CONSERVATIVE_POPULARITY, NEUTRAL_POPULARITY, STIRRER_POPULARITY, INCENDIARY_POPULARITY };
    public static int[] INSTABILITY = { BORING_INSTABILITY, CONSERVATIVE_INSTABILITY, NEUTRAL_INSTABILITY_LIMIT_A, STIRRER_INSTABILITY, INCENDIARY_INSTABILITY };
    public static double[] MULTIPLIERS = { BORING_MULTIPLIER, CONSERVATIVE_MULTIPLIER, NEUTRAL_MULTIPLIER, STIRRER_MULTIPLIER, INCENDIARY_MULTIPLIER };
}

