using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public GameObject ballPrefab;
	public Transform shootOffset;
	public float power;


	void Start () {
		
	}
	
	void Update () {

		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			ThrowBall();
		}
	}

	void ThrowBall()
	{
		GameObject tmpBall = Instantiate(ballPrefab, shootOffset.position, shootOffset.transform.rotation);
		tmpBall.GetComponent<Rigidbody>().velocity = shootOffset.forward * power;
	}
}
