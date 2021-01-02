////////////////
//Name: Thomas Allen
//Date: 10/28/2020
//Desc: Resets the main scene and loads it
////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //load the level if player presses space
        if (Input.GetKey(KeyCode.R))
            SceneManager.LoadScene("Level");
    }
}
