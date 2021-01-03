using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillIfUnderTerrian : MonoBehaviour
{

    public GameObject player;

    public GameObject terrian;
    public Collider terrainCollider;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
            player = GameObject.FindWithTag("Player");
        if (terrian == null)
            terrian = GameObject.FindWithTag("Terrian");
        if (terrainCollider == null)
            terrainCollider = terrian.GetComponent<TerrainCollider>();
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
