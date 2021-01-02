using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] GameObject deathFX;
	[SerializeField] Transform parent;
	[SerializeField] int scorePerHit = 12;
	[SerializeField] int hits = 3;


	Scoreboard scoreBoard;

	public GameObject explodtion;
	// Use this for initialization
	void Start()
	{
		AddBoxCollider();
		scoreBoard = FindObjectOfType<Scoreboard>();
	}

	private void AddBoxCollider()
	{
		Collider boxCollider = gameObject.AddComponent<BoxCollider>();
		boxCollider.isTrigger = false;
	}

	void OnParticleCollision(GameObject other)
	{
		ProcessHit();
		if (hits <= 1)
		{
			KillEnemy();
		}
	}

	private void ProcessHit()
	{
		scoreBoard.ScoreHit(scorePerHit);
		hits = hits - 1;
		// todo consider hit FX
	}

	private void KillEnemy()
	{
		GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
		fx.transform.parent = parent;
		Instantiate(explodtion, gameObject.transform.position, Quaternion.identity);
		Destroy(gameObject);

	}
}