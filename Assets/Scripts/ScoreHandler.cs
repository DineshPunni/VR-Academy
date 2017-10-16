using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour {

	Text scoreText;
	int score = 0;


	void OnEnable()
	{
		EnemyControl.OnEnemyDied += IncreaseScore;
		GameManager.OnRestart += ResetScore;
	}

	void OnDisable()
	{
		EnemyControl.OnEnemyDied -= IncreaseScore;
		GameManager.OnRestart -= ResetScore;
	}

	void Start ()
	{
		scoreText = GetComponent<Text>();
	}
	

	void IncreaseScore()
	{
		score++;
		scoreText.text = "Score: " + score.ToString();
	}


	void ResetScore()
	{
		score = 0;
		scoreText.text = "Score: " + score.ToString();
	}

}
