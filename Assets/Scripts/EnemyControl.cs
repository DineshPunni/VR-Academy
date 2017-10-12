using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

	public float x;
	public float y;
	public float z;
	public float speed;



	public static Action OnGameOver;
	public static Action OnEnemyDied;

	public void TeleportEnemy()
	{
		float newX = UnityEngine.Random.Range(-x, x); 
		float newY = UnityEngine.Random.Range(0, y);
		float newZ = UnityEngine.Random.Range(-z, z);

		transform.position = new Vector3(newX, newY, newZ);
		transform.LookAt(Camera.main.transform);
	}


	void Update()
	{
		transform.Translate(Vector3.forward*Time.deltaTime * speed);
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.tag == ("Player"))
		{
			if (OnGameOver != null)
				OnGameOver();
		}
		if(other.tag == ("Ball"))
		{
			//Destroy(other.gameObject);
			TeleportEnemy();
			if (OnEnemyDied != null)
				OnEnemyDied();
		}
	}

	
}
