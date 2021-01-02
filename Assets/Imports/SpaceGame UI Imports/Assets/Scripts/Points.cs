///////////////////////
///Name: Ryan Scheppler
///Date: 10/26/2020
///Desc: Add this to an object that you want to add points from on a certain Unity event, and add this function AddPoints to the list of listeners.
////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public int points = 10;

    public void AddPoints()
    {
        GameManager.Score += points;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetPoints()
    {
        GameManager.Score = 0;
    }
}
