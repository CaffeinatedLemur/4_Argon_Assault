using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{

    public int StartingSpawnFreq = 1;
    public int CurrentLap;
    public int difficulty;

    public float scalefactor;


    public float cooldown;
    public float timer;

    public GameObject nextEnemy;

    public GameObject[] enemies;
    public GameObject[] spawnpoints;

    public Transform SpawnCenterTransform;

    public Vector3 NextSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        scalefactor = difficulty * 0.1f;
        spawnpoints = GameObject.FindGameObjectsWithTag("Spawner");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer = timer + Time.deltaTime;

        if (timer >= cooldown)
        {
            cooldown = 0;
            nextEnemy = enemies[(int)Random.Range(0, enemies.Length)];

            NextSpawnPoint = spawnpoints[(int)Random.Range(0, spawnpoints.Length)].transform.localPosition;

            //NextSpawnPoint = SpawnCenterTransform.localPosition;

            Instantiate(nextEnemy, NextSpawnPoint, Quaternion.identity);
            /*
            for (int i = 0; i < CurrentLap * scalefactor; i++)
            {
                

            }
            */

           
        }
    }
}
