using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newspaper
{
    public int credibility { get; set; }
    public int popularity { get; set; }
    public int instability { get; set; }

    public Newspaper(int dificulty)
    {
        InitValues(dificulty);
    }

    private void InitValues(int dificulty)
    {
        if (dificulty == DIFICULTY_LEVELS.EASY)
        {
            credibility = 5;
            popularity = 5000;
            instability = 10;
        }
        else if (dificulty == DIFICULTY_LEVELS.MEDIUM)
        {
            credibility = 3;
            popularity = 2500;
            instability = 25;
        }
        else if (dificulty == DIFICULTY_LEVELS.HARD)
        {
            credibility = 1;
            popularity = 1000;
            instability = 50;
        }
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
