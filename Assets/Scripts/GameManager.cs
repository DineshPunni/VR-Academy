using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static Action OnRestart;

	public GameObject GameOverCanvas;
	GameObject enemy;
	AudioSource source;

	void OnEnable()
	{
		EnemyControl.OnGameOver += GameOver;
	}

	void GameOver()
	{
		source.Play();
		enemy.SetActive(false);
		SpawnGameOverCanvas();
	}

	void OnDisable()
	{
		EnemyControl.OnGameOver -= GameOver;
	}

	void Start()
	{
		enemy = FindObjectOfType<EnemyControl>().gameObject;
		source = GetComponent<AudioSource>();
	}



	public void Restart()
	{
		if (OnRestart != null)
			OnRestart();

		GameOverCanvas.SetActive(false);
		//Instantiate(enemy, new Vector3(0, 0, 5), Quaternion.identity);
		enemy.SetActive(true);
		enemy.GetComponent<EnemyControl>().TeleportEnemy();
	}


	void SpawnGameOverCanvas()
	{
		//GameObject tmp = Instantiate(GameOverPrefab, transform.position, Quaternion.identity);
		GameOverCanvas.SetActive(true);
		GameOverCanvas.transform.LookAt(Camera.main.transform);
		GameOverCanvas.transform.Rotate(new Vector3(0, 180, 0));
		//GameOverPrefab.transform.Translate(Vector3.forward * 5);
	}
}
