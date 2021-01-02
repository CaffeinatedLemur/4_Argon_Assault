using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillIfUnderTerrian : MonoBehaviour
{

    public GameObject player;

    public GameObject terrainCollider;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
            player = GameObject.FindWithTag("Player");
        if (terrainCollider == null)
            terrainCollider = GameObject.FindWithTag("Terrian");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, player.transform.position, out hit))
        {
            if (hit.collider == terrainCollider)
            {
                Destroy(gameObject);
            }
        }

    }


}
