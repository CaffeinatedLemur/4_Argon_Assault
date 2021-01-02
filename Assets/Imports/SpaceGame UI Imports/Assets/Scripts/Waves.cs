////////////////
//Name: Thomas Allen
//Date: 10/28/2020
//Desc: Spawns enemies in waves after previous wave is gone
////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Waves : MonoBehaviour
{
    [Tooltip("The enemy that will spawn")]
    public GameObject enemy;

    [Tooltip("how many waves have come")]
    public float WaveCount = 1;
    [Tooltip("the minimum number of enemies")]
    public float EnemyScalingMin = 1;
    [Tooltip("The maximum number of enemies")]
    public float EnemyScalingMax = 2;

    [Tooltip("randomly genereated every time a new wave is loaded, equates to an int of how many enemies will spawn this wave")]
    public float EnemySpawns;

    public float timer;
    public float Cooldown = 15;

    public GameObject[] enemies;

    public GameObject[] spawnables;

    //public GameObject[] Stars;
   // public Canvas upgradeCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        //fill an array with all the enemies
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        RandSpawns();
        timer += Time.deltaTime;

        /*
        if (WaveCount % 10 == 0)
        {
            UpgradeMenu();
        }
        */

    }

    /*
    public void UpgradeMenu()
    {
        Time.timeScale = 0;
        Stars[0].layer = 31;
        Stars[1].layer = 31;
        Stars[2].layer = 31;

        upgradeCanvas.enabled = true;
    }

    public void ReturnToLevel()
    {
        Time.timeScale = 1;

        Stars[0].layer = 0;
        Stars[1].layer = 0;
        Stars[2].layer = 0;

        upgradeCanvas.enabled = false;

    }
    */

    public void RandSpawns()
    {
        //update array
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //check if array is empty
        if (enemies.Length == 0 || timer >= Cooldown)
        {
            //reset timer
            timer = 0;
            //update wavecount
            ++WaveCount;
            // set max enemies
            EnemyScalingMax = WaveCount;
            //find out how many to spawn
            EnemySpawns = Random.Range(EnemyScalingMin, EnemyScalingMax);

            //spawn enemies
            for (int i = 0; i <= EnemySpawns; ++i)
            {
                //sopawn enemies at random places
                Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0);

                GameObject spawned = Instantiate<GameObject>(spawnables[(int) Random.Range(0f, 10.0f)], position, transform.rotation);
            }
            if (EnemySpawns < EnemySpawns / 2)
            {
                Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0);

                GameObject spawned = Instantiate<GameObject>(spawnables[10], position, transform.rotation);
            }
        }
        //break the function
        return;

    }
}
