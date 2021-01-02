using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAtHighHealth : MonoBehaviour
{
    public Health tempHealth;

    // Start is called before the first frame update
    void Start()
    {
        GameObject tempObj = GameObject.Find("PlayerShip");
        tempHealth = tempObj.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tempHealth.CurrentHealth > 30)
        {
            Destroy(gameObject);
            
        }
    }
}
