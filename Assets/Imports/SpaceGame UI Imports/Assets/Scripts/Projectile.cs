////////////////
//Name: Thomas Allen
//Date: 10/28/2020
//Desc: Lets enemies shoot projectiles. majority of code from 
//BlackThornProd's Shooting/Follow/retreating enemy 
//tutorial posted in modules
////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Projectile : MonoBehaviour
{
    [Tooltip("Speed of prejectile")]
    public float speed;

    [Tooltip("The player target")]
    public Transform player;
    [Tooltip("the target x, y coords")]
    public Vector2 target;

    public Vector2 EnemyPos;


    public float diffx;

    public float diffy;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        EnemyPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);

        diffx = (player.position.x - EnemyPos.x) * 10;
        diffy = (player.position.y - EnemyPos.y) * 10;

        //find where the player is
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //set the target to where the player is
        //target = new Vector2(player.position.x + Random.Range(-1f, 1f), player.position.y + Random.Range(-1f, 1f));
        target = new Vector2(diffx + player.position.x + Random.Range(-1f, 1f), diffy + player.position.y + Random.Range(-1f, 1f));
    }

    // Update is called once per frame
    void Update()
    {


        //set trajectory for the projectile
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        //check if the projectile has reached the target
        /*
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            //if so, destroy it
            DestroyProjectile();
        }
        */
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //destroy it when it collides with the player
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
        }
    }

    //method to call to destroy the projectile
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
