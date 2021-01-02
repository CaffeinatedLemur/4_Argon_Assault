////////////////
//Name: Thomas Allen
//Date: 10/28/2020
//Desc: Gives enemies simple follow/retreat AI. majority of code from 
//BlackThornProd's Shooting/Follow/retreating enemy 
//tutorial posted in modules
////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyImported : MonoBehaviour
{
    [Tooltip("How fast the enmy moves")]
    public float speed;
    [Tooltip("How close the enemy is willing to get to the player")]
    public float stoppingDistance;
    [Tooltip("When the enemy qwill start retreating")]
    public float retreatDistance;



    [Tooltip("How quickly the enemy shoots")]
    public float timeBtwShots;
    [Tooltip("Temp value for timeBtwShots")]
    public float startTimeBtwShots;

    [Tooltip("The projectile they will fire")]
    public GameObject projectile;
    public GameObject enemy;

    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;

    }

    // Update is called once per frame
    void Update()
    {

        //should we move closer
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        //stay in the same place
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        //or retreat?
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }


        //fire if timer is updated
        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            //count down the timer if not
            timeBtwShots -= Time.deltaTime;
        }
    }
}
