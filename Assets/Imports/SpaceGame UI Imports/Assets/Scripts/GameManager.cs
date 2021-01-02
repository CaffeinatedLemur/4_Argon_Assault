/////////////////////////
///Name: Ryan Scheppler
///Date: 10/26/2020
///Desc: This class is not a component and is built to just exist and store game data between scenes
/////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager
{
    private static int score = 0;

    public static UnityEvent OnScoreChange = new UnityEvent();

    public static int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            OnScoreChange.Invoke();
        }
    }

}
