using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newspaper
{
    public int credibility { get; set; }

    public Newspaper()
    {
        credibility = DIFICULTY_LEVELS.EASY;
    }

    public void DecrementCredibility()
    {
        credibility--;
        if (credibility <= 0)
        {
            Censor();
        }
        else
            Debug.Log("FAKE NEWS! Credibility:" + credibility);
    }

    public void Censor()
    {
        Debug.Log("CENSORED! You lost.");
    }
}

public static class DIFICULTY_LEVELS
{
    public static int EASY = 5;
    public static int MEDIUM = 3;
    public static int HARD = 1;
}
