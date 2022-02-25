using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;

public interface IElement
{
    bool IsFake();
    ICategory GetCategory();
    double GetMultiplier();
    float GetDetectionRisk();
    SpriteRenderer GetSprite();
    string GetTheme();
}


public abstract class AbstractElement : IElement
{
    private bool fake;
    private float concretedetectionRisk;
    private double multiplier;
    private SpriteRenderer sprite;

    private ICategory category;
    private string theme;

    public AbstractElement(ICategory category, SpriteRenderer sprite, string theme, float concretedetectionRisk, float multiplier, bool fake)
    {
        this.fake = fake;
        this.category = category;
        this.sprite = sprite;
        this.theme = theme;
        this.concretedetectionRisk = concretedetectionRisk;
        this.multiplier = multiplier;
    }

    protected float GetConcreteDetectionRisk()
    {
        return concretedetectionRisk;
    }
    public double GetMultiplier()
    {
        return multiplier;
    }

    public ICategory GetCategory()
    {
        return category; ;
    }


    public float GetDetectionRisk()
    {
        return fake ? GetConcreteDetectionRisk() : 0f;
    }

    public SpriteRenderer GetSprite()
    {
        return sprite;
    }

    public bool IsFake()
    {
        return fake;
    }

    public string GetTheme()
    {
        return theme;
    }
}

public class Heading : AbstractElement, IElement
{
    public Heading(ICategory category, SpriteRenderer sprite, string theme, float concretedetectionRisk, float multiplier, bool fake) : base(category, sprite, theme, concretedetectionRisk, multiplier, fake) { }


}

public class Subheading : AbstractElement, IElement
{

    public Subheading(ICategory category, SpriteRenderer sprite, string theme, float concretedetectionRisk, float multiplier, bool fake) : base(category, sprite, theme, concretedetectionRisk, multiplier, fake) { }

}

public class Photo : AbstractElement, IElement
{

    public Photo(ICategory category, SpriteRenderer sprite, string theme, float concretedetectionRisk, float multiplier, bool fake) : base(category, sprite, theme, concretedetectionRisk, multiplier, fake) { }

}

