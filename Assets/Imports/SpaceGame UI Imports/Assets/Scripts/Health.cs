////////////////
//Name: Thomas Allen
//Date: 10/28/2020
//Desc: Manages the Health of gameObjects as well as regen for the player
////////////////


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Tooltip("The maximum shields of the gameobject")]
    public int MaxHealth = 100;
    [Tooltip("The current shields of the gameobject")]
    public float CurrentHealth = 100;
    [Tooltip("Do you want the object to be immediatly destroyed on death?")]
    public bool DestroyAtZero = true;
    [Tooltip("A list of things to do at 0 health")]
    public UnityEvent OnDeath = new UnityEvent();
    [Tooltip("The maximum health of the gameobject")]
    public int Crithealth = 30;
    [Tooltip("The current health of the gameobject")]
    public float CurrentCritHealth = 30;

    public GameObject AlarmSound;
    public GameObject RegenSound;

    public bool ActiveAlarm = false;

    public float HealthThreshold = 0;

    public float NoCombatCooldown = 7f;
    public float Cooldown = 1f;
    public float timer = 0;
    public float CooldownTimer = 0;

    public int i;
    public int p;

    public UnityEvent OnHealthChange = new UnityEvent();
    public Image[] Images;
    public Image[] Images2;

    public Text WarningHull;
    public Text WarningShields;
    public void ChangeHealth(int change)
    {
        timer = 0;
        //alter the current health
        if (CurrentHealth > 0)
            CurrentHealth += change;
        else
        {
            Crithealth += change;
            if (Crithealth <= 0)
                Crithealth = 0;
            Images2[Crithealth / 10].enabled = false;
            WarningHull.enabled = true;
        }
        //make sure not overhelaed (more than maxhp)
        if (CurrentHealth > MaxHealth)
            CurrentHealth = MaxHealth;
        //decide what happens at 0 hp
        if (CurrentHealth <= 0 )
            CurrentHealth = 0;
        if (Crithealth <= 0 )
        {
         
            OnDeath.Invoke();
        }
        
        OnHealthChange.Invoke();
    }

    public String Heal(int change)
    {
        //alter the current health
        CurrentHealth += change;
        //make sure not overhelaed (more than maxhp)
        if (CurrentHealth > MaxHealth)
            CurrentHealth = MaxHealth;
        //decide what happens at 0 hp
        
        OnHealthChange.Invoke();
        return null;
    }
    public void CritHeal()
    {
        //alter the current health
        Crithealth = 30;
        Images2[Crithealth / 10].enabled = true;
        Images2[Crithealth / 10].enabled = true;
        Images2[Crithealth / 10].enabled = true;
    }



    public void RegenHealth()
    {
        if (timer >= NoCombatCooldown)
        {
            if ( CooldownTimer >= Cooldown && CurrentHealth != MaxHealth)
            {
                Heal(10);
                GameObject sfx = Instantiate<GameObject>(RegenSound, transform.position, transform.rotation);
                if (CurrentHealth == 100)
                {
                    timer = 0;
                }
                CooldownTimer = 0;
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        WarningHull.enabled = false;
        WarningShields.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        RegenHealth();


        if (CurrentHealth <= 30 && !ActiveAlarm)
        {

            ActiveAlarm = true;
            GameObject sfx = Instantiate<GameObject>(AlarmSound, transform.position, transform.rotation);
            WarningShields.enabled = true;
        }
        else if (CurrentHealth > 30 && ActiveAlarm)
        {
            ActiveAlarm = false;
            WarningShields.enabled = false;
        }
        
        //update timer
        timer += Time.deltaTime;
        CooldownTimer += Time.deltaTime;

        //get the health variable
        Health otherHealth = gameObject.GetComponent<Health>();
        if (otherHealth != null)
        {
            

        }

    }

    

    public void Disable_Enable()
    {
        
        for (i = 10; i != 0; i--)
        {
            if (i * 10 >= CurrentHealth)
            {
                Images[(i) - 1].enabled = false;
            }
            if (i * 10 <= CurrentHealth)
            {
                Images[(i) - 1].enabled = true;
            }
        }

        /*
        for (p = 3; p != 0; p--)
        {
            print("Index: " + p);
            

            if (CurrentCritHealth < 30)
            {
                Images2[3].enabled = false;
            }
            if (CurrentCritHealth < 20)
            {
                Images2[2].enabled = false;
            }
            

            /*
            if (p * 10 > CurrentCritHealth)
            {
                print("If Working");
                Images2[(p) - 1].enabled = false;
            }
            
        }
        */


    }
}
