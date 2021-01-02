////////////////
///Name: Thomas Allen
///Date: 10/20/2020
///Desc: This script will allow the player to fire objects from the attached gameobject
///////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCannon : MonoBehaviour
{
    public GameObject player;
    [Tooltip("Make sure projectile to be fired has a rigidbody2d!")]
    public GameObject Projectile;
    [Tooltip("Shooting sound")]
    public GameObject Sound;
    [Tooltip("Speed of projectile")]
    public float ProjectileSpeed = 10;
    [Tooltip("minimum time between shots")]
    public float Cooldown = 0.5f;
    public float timer = 0;

    public Image[] Images;
    public Text WarningHeat;
    public int count;

    public int i;

    public GameObject AlarmSound;

    // Start is called before the first frame update
    void Start()
    {
        WarningHeat.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //update the timer
        timer += Time.deltaTime;

        if (Input.GetAxisRaw("Jump") > 0 && timer >= Cooldown && count < 100)
        {
            Fire(transform.position, transform.up);
            HeatManager();
        }
        else
        {
            if (count > 0 && count < 100)
            {
                //Invoke("RegenHeat", 1f);
                RegenHeat();
                HeatManager();
            }
        }

            
    }

    
    public void RegenHeat()
    {
        count = count - (int)timer;
        HeatManager();
       
    }

    public void HeatManager()
    {
        for (i = 10; i != 0; i--)
        {
            if (i * 10 >= count)
            {
                Images[(i) - 1].enabled = false;
            }
            if (i * 10 <= count)
            {
                Images[(i) - 1].enabled = true;
            }
        }

        if (count < 100)
        {
            WarningHeat.enabled = false;
        }
        else if (count >= 100)
        {
            WarningHeat.enabled = true;
            GameObject sfx = Instantiate<GameObject>(AlarmSound, transform.position, transform.rotation);
            Invoke("RegenHeat", 5f);
        }
        else
        {
            RegenHeat();
        }
    }

    void Fire(Vector3 position, Vector3 direction)
    {
        timer = 0;
        count += 3;
        //load the projectile into scene
        GameObject proj = Instantiate<GameObject>(Projectile, position, transform.rotation);
        //set projectile
        proj.GetComponent<Rigidbody2D>().velocity = direction * ProjectileSpeed;
        proj.GetComponent<Rigidbody2D>().AddForce(new Vector3(player.GetComponent<Rigidbody2D>().velocity.x, 0f, player.GetComponent<Rigidbody2D>().velocity.y));
        //load the sound effect and have it play
        GameObject sfx = Instantiate<GameObject>(Sound, position, transform.rotation);
    }
}
