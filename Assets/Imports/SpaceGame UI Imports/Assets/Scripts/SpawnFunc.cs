////////////////
///Name: Thomas Allen
///Date: 10/22/2020
///Desc: This component will have a function to be run by unity events
////////////////



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFunc : MonoBehaviour
{
    public GameObject[] ObjectsToSpawn;
    //This function will spawn in all the objects set to spawn
    //must be public so that unity events can use it
    public void Spawn()
    {
        //iterate throguh array
        for (int i = 0; i < ObjectsToSpawn.Length; ++i)
        {
            //spawn the thing
            Instantiate(ObjectsToSpawn[i], transform.position, Quaternion.identity);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
