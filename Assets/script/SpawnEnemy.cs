using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

	GameObject [] spawnPoint;
	public GameObject zombie;
	public float minSpawnTime = 0.2f;
	public float maxSpawnTime = 0.9f;
	private float lastSpawnTime = 0;
	private float spawnTime = 0;
	// Use this for initialization
	void Start () {
		spawnPoint = GameObject.FindGameObjectsWithTag ("Respawn");
        
        UpdateSpawnTime ();
	}
	
	// Update is called once per frame
	void Update () {
		SubUpdate ();
	}

	void Spawn()
	{
		int point = Random.Range (0, spawnPoint.Length);
		Instantiate (zombie, spawnPoint[point].transform.position, Quaternion.identity);
		UpdateSpawnTime ();
	}
	void UpdateSpawnTime()
	{
		lastSpawnTime = Time.time;
		spawnTime = Random.Range (minSpawnTime, maxSpawnTime);
	}
	void SubUpdate()
	{
		if (Time.time >= lastSpawnTime + spawnTime)
			Spawn ();
	}
}
