using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] GameObject deathFX;
	[SerializeField] Transform parent;
	[SerializeField] int scorePerHit = 12;
	[SerializeField] int hits = 3;


	public GameObject SpawnCenter;

	public Transform SpawnCenterTransform;

	Scoreboard scoreBoard;

	public GameObject explodtion;

	public Vector3 NextSpawnPoint;
	// Use this for initialization
	void Start()
	{
		/*
		SpawnCenter = GameObject.FindWithTag("Spawner");
		SpawnCenterTransform = SpawnCenter.transform;

		gameObject.transform.parent = SpawnCenterTransform;
		*/

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

	public void calculatePosition()
    {
		NextSpawnPoint.z = SpawnCenter.transform.position.z;
		NextSpawnPoint.x = Random.Range(-15f, 15f);
		NextSpawnPoint.y = Random.Range(-5f, 5f);


		gameObject.transform.localPosition = NextSpawnPoint;
	}
}