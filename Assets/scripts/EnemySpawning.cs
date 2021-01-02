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

    public GameObject SpawnCenter;
    public GameObject nextEnemy;

    public GameObject[] enemies;

    public Vector3 NextSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        scalefactor = difficulty * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;

        if (timer >= cooldown)
        {
            for (int i = 0; i < CurrentLap * scalefactor; i++)
            {
                nextEnemy = enemies[(int)Random.Range(0, enemies.Length)];

                NextSpawnPoint.z = SpawnCenter.transform.position.z;
                NextSpawnPoint.x = Random.Range(-15f, 15f);
                NextSpawnPoint.y = Random.Range(-5f, 5f);

                Instantiate(nextEnemy, NextSpawnPoint, Quaternion.identity);

                
            }

            cooldown = cooldown * Random.Range(0.5f, 1.5f);
        }
    }
}
