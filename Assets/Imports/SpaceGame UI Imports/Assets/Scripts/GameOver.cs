////////////////
//Name: Thomas Allen
//Date: 10/28/2020
//Desc: Attached to the player's OnDeath event to load the game over scene
////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOverSceneLoad()
    {
        //load game over scene
        SceneManager.LoadScene("GameOver");
    }
}
