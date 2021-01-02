using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeButtons : MonoBehaviour
{

    public GameObject projectile;
    public GameObject player;

    public GameObject[] Stars;
    public Canvas upgradeCanvas;


    public Waves ReturnWaves;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DamageUp()
    {
        DamageOnCollide damageOnCollide = projectile.GetComponent<DamageOnCollide>();
        damageOnCollide.damage += 10;
        ReturnToScene();
    }

    public void Heal()
    {
        Health health = player.GetComponent<Health>();
        health.CritHeal();
    }

    public void ReturnToScene()
    {
        Invoke("ReturnToGame", 3f);
    }

    public void ReturnToGame()
    {
        /*
        GameObject waves = GameObject.Find("PlayerShip");
        ReturnWaves = waves.GetComponent<Waves>();

        ReturnWaves.ReturnToLevel();
        */

        Time.timeScale = 1;

        Stars[0].layer = 0;
        Stars[1].layer = 0;
        Stars[2].layer = 0;

        upgradeCanvas.enabled = false;
    }
}
