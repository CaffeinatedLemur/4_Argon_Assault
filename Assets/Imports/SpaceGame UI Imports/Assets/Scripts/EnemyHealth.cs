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

public class EnemyHealth : MonoBehaviour
{
    [Tooltip("The maximum health of the gameobject")]
    public int MaxHealth = 100;
    [Tooltip("The current health of the gameobject")]
    public float CurrentHealth = 100;
    [Tooltip("Do you want the object to be immediatly destroyed on death?")]
    public bool DestroyAtZero = true;
    [Tooltip("A list of things to do at 0 health")]
    public UnityEvent OnDeath = new UnityEvent();



    public bool ActiveAlarm = false;


    public void ChangeHealth(int change)
    {
        //alter the current health
        CurrentHealth += change;
        //make sure not overhelaed (more than maxhp)
        if (CurrentHealth >= MaxHealth)
            CurrentHealth = MaxHealth;
        //decide what happens at 0 hp
        if (CurrentHealth <= 0)
        {
            //set to zero to avoid glitcheds
            CurrentHealth = 0;
            
            Destroy(gameObject);
            OnDeath.Invoke();

        }
    }
}
