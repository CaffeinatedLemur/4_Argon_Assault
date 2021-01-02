//////////////////////////
///Name: Ryan Scheppler
///Date: 10/26/2020
///Desc: Add to a text object to display the score!
//////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    Text myText;
    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<Text>();
        OnScoreUpdate();
        GameManager.OnScoreChange.AddListener(OnScoreUpdate);
    }

    void OnScoreUpdate()
    {
        myText.text = "Score: " + GameManager.Score.ToString();
    }
    private void OnDestroy()
    {
        GameManager.OnScoreChange.RemoveListener(OnScoreUpdate);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
