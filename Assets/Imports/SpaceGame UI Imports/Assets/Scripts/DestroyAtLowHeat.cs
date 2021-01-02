using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAtLowHeat : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerCannon tempHeat;

    // Start is called before the first frame update
    void Start()
    {
        GameObject tempObj = GameObject.Find("PlayerShip");
        tempHeat = tempObj.GetComponent<PlayerCannon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tempHeat.count < 90)
        {
            Destroy(gameObject);

        }
    }
}
