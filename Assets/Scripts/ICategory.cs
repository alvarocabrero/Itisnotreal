using UnityEngine;

public interface ICategory
{
    int GetPopularity();
    int GetInstability();
    string GetCategory();
}

class Boring : ICategory
{
    public string GetCategory()
    {
        return CATEGORIES.BORING;
    }

    public int GetInstability()
    {
        return Random.Range(-5, -3);
    }

    public int GetPopularity()
    {
        return Random.Range(-100, -60);
    }
}

class Conservative : ICategory
{
    public string GetCategory()
    {
        return CATEGORIES.CONSERVATIVE;
    }
    public int GetInstability()
    {
        return Random.Range(-3, -1);
    }

    public int GetPopularity()
    {
        return Random.Range(-60, -20);
    }
}

class Neutral : ICategory
{
    public string GetCategory()
    {
        return CATEGORIES.NEUTRAL;
    }
    public int GetInstability()
    {
        return Random.Range(-1, 1);
    }

    public int GetPopularity()
    {
        return Random.Range(-20, 20);
    }
}

class Stirrer : ICategory
{
    public string GetCategory()
    {
        return CATEGORIES.STIRRER;
    }
    public int GetInstability()
    {
        return Random.Range(1, 3);
    }

    public int GetPopularity()
    {
        return Random.Range(20, 60);
    }
}

class Incendiary : ICategory
{
    public string GetCategory()
    {
        return CATEGORIES.INCENDIARY;
    }
    public int GetInstability()
    {
        return Random.Range(3, 5);
    }

    public int GetPopularity()
    {
        return Random.Range(60, 100);
    }
}

