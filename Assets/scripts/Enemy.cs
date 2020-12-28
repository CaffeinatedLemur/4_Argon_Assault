using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] GameObject deathFX;
	[SerializeField] Transform parent;

	public GameObject explodtion;
	// Use this for initialization
	void Start()
	{
		Collider boxCollider = gameObject.AddComponent<BoxCollider>();
		boxCollider.isTrigger = false;
	}

	void OnParticleCollision(GameObject other)
	{
		GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
		fx.transform.parent = parent;
		Instantiate(explodtion, gameObject.transform.position, Quaternion.identity	);
		Destroy(gameObject);
	}
}