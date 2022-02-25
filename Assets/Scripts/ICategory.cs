using UnityEngine;

public interface ICategory
{
    int GetPopularity();
    int GetInstability();
}

class Boring : ICategory
{
    public int GetInstability()
    {
        return Random.Range(-25, -15);
    }

    public int GetPopularity()
    {
        return Random.Range(-500, -300);
    }
}

class Conservative : ICategory
{
    public int GetInstability()
    {
        return Random.Range(-15, -5);
    }

    public int GetPopularity()
    {
        return Random.Range(-300, -100);
    }
}

class Neutral : ICategory
{
    public int GetInstability()
    {
        return Random.Range(-5, 5);
    }

    public int GetPopularity()
    {
        return Random.Range(-100, 100);
    }
}

class Stirrer : ICategory
{
    public int GetInstability()
    {
        return Random.Range(5, 15);
    }

    public int GetPopularity()
    {
        return Random.Range(100, 300);
    }
}

class Incendiary : ICategory
{
    public int GetInstability()
    {
        return Random.Range(15, 25);
    }

    public int GetPopularity()
    {
        return Random.Range(300, 500);
    }
}

