public static class DIFICULTY_LEVELS
{
    public static int EASY = 0;
    public static int MEDIUM = 1;
    public static int HARD = 2;
}
public static class CATEGORIES
{
    public const string BORING = "boring";
    public const string CONSERVATIVE = "conservative";
    public const string NEUTRAL = "neutral";
    public const string STIRRER = "stirrer";
    public const string INCENDIARY = "incendiary";

    public static string[] CATEGORY_LIST = { BORING, CONSERVATIVE, NEUTRAL, STIRRER, INCENDIARY };
    internal static string GetCategory(string category)
    {
        foreach (string c in CATEGORY_LIST)
        {
            if (category.Contains(c))
                return c;
        }
        return "";

    }
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

/**

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

    public static int GetPopularity(String categoria)
    {
        switch (CATEGORIES.GetCategory(categoria))
        {
            case CATEGORIES.BORING:
                return BORING_POPULARITY;
            case CATEGORIES.CONSERVATIVE:
                return CONSERVATIVE_POPULARITY;
            case CATEGORIES.NEUTRAL:
                return NEUTRAL_POPULARITY;
            case CATEGORIES.STIRRER:
                return STIRRER_POPULARITY;
            case CATEGORIES.INCENDIARY:
                return INCENDIARY_POPULARITY;
        }
        Debug.LogError("No existe la categoria");
        return -11111;
    }
    public static int GetInstability(String categoria)
    {
        switch (CATEGORIES.GetCategory(categoria))
        {
            case CATEGORIES.BORING:
                return BORING_INSTABILITY;
            case CATEGORIES.CONSERVATIVE:
                return CONSERVATIVE_INSTABILITY;
            case CATEGORIES.NEUTRAL:
                return NEUTRAL_INSTABILITY_LIMIT_A;
            case CATEGORIES.STIRRER:
                return STIRRER_INSTABILITY;
            case CATEGORIES.INCENDIARY:
                return INCENDIARY_INSTABILITY;
        }
        Debug.LogError("No existe la categoria");
        return -11111;
    }

    public static double GetMultipliers(String categoria)
    {
        switch (CATEGORIES.GetCategory(categoria))
        {
            case CATEGORIES.BORING:
                return BORING_MULTIPLIER;
            case CATEGORIES.CONSERVATIVE:
                return CONSERVATIVE_MULTIPLIER;
            case CATEGORIES.NEUTRAL:
                return NEUTRAL_MULTIPLIER;
            case CATEGORIES.STIRRER:
                return STIRRER_MULTIPLIER;
            case CATEGORIES.INCENDIARY:
                return INCENDIARY_MULTIPLIER;
        }
        Debug.LogError("No existe la categoria");
        return -11111;
    }

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

    public static int GetPopularity(String categoria)
    {
        switch (CATEGORIES.GetCategory(categoria))
        {
            case CATEGORIES.BORING:
                return BORING_POPULARITY;
            case CATEGORIES.CONSERVATIVE:
                return CONSERVATIVE_POPULARITY;
            case CATEGORIES.NEUTRAL:
                return NEUTRAL_POPULARITY;
            case CATEGORIES.STIRRER:
                return STIRRER_POPULARITY;
            case CATEGORIES.INCENDIARY:
                return INCENDIARY_POPULARITY;
        }
        Debug.LogError("No existe la categoria");
        return -11111;
    }
    public static int GetInstability(String categoria)
    {
        switch (CATEGORIES.GetCategory(categoria))
        {
            case CATEGORIES.BORING:
                return BORING_INSTABILITY;
            case CATEGORIES.CONSERVATIVE:
                return CONSERVATIVE_INSTABILITY;
            case CATEGORIES.NEUTRAL:
                return NEUTRAL_INSTABILITY_LIMIT_A;
            case CATEGORIES.STIRRER:
                return STIRRER_INSTABILITY;
            case CATEGORIES.INCENDIARY:
                return INCENDIARY_INSTABILITY;
        }
        Debug.LogError("No existe la categoria");
        return -11111;
    }

    public static double GetMultipliers(String categoria)
    {
        switch (CATEGORIES.GetCategory(categoria))
        {
            case CATEGORIES.BORING:
                return BORING_MULTIPLIER;
            case CATEGORIES.CONSERVATIVE:
                return CONSERVATIVE_MULTIPLIER;
            case CATEGORIES.NEUTRAL:
                return NEUTRAL_MULTIPLIER;
            case CATEGORIES.STIRRER:
                return STIRRER_MULTIPLIER;
            case CATEGORIES.INCENDIARY:
                return INCENDIARY_MULTIPLIER;
        }
        Debug.LogError("No existe la categoria");
        return -11111;
    }
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
    public static int GetPopularity(String categoria)
    {
        switch (CATEGORIES.GetCategory(categoria))
        {
            case CATEGORIES.BORING:
                return BORING_POPULARITY;
            case CATEGORIES.CONSERVATIVE:
                return CONSERVATIVE_POPULARITY;
            case CATEGORIES.NEUTRAL:
                return NEUTRAL_POPULARITY;
            case CATEGORIES.STIRRER:
                return STIRRER_POPULARITY;
            case CATEGORIES.INCENDIARY:
                return INCENDIARY_POPULARITY;
        }
        Debug.LogError("No existe la categoria");
        return -11111;
    }
    public static int GetInstability(String categoria)
    {
        switch (CATEGORIES.GetCategory(categoria))
        {
            case CATEGORIES.BORING:
                return BORING_INSTABILITY;
            case CATEGORIES.CONSERVATIVE:
                return CONSERVATIVE_INSTABILITY;
            case CATEGORIES.NEUTRAL:
                return NEUTRAL_INSTABILITY_LIMIT_A;
            case CATEGORIES.STIRRER:
                return STIRRER_INSTABILITY;
            case CATEGORIES.INCENDIARY:
                return INCENDIARY_INSTABILITY;
        }
        Debug.LogError("No existe la categoria");
        return -11111;
    }

    public static double GetMultipliers(String categoria)
    {
        switch (CATEGORIES.GetCategory(categoria))
        {
            case CATEGORIES.BORING:
                return BORING_MULTIPLIER;
            case CATEGORIES.CONSERVATIVE:
                return CONSERVATIVE_MULTIPLIER;
            case CATEGORIES.NEUTRAL:
                return NEUTRAL_MULTIPLIER;
            case CATEGORIES.STIRRER:
                return STIRRER_MULTIPLIER;
            case CATEGORIES.INCENDIARY:
                return INCENDIARY_MULTIPLIER;
        }
        Debug.LogError("No existe la categoria");
        return -11111;
    }


}

**/

