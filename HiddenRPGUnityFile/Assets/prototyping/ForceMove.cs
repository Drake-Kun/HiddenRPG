﻿using UnityEngine;
using System.Collections;

public class ForceMove : MonoBehaviour {

	public float speed = 0.1f;
	private float startSpeed;
	// Use this for initialization
	void Start () {
		startSpeed = speed;
		//Instantiate (prefab, new Vector3 (0, 0, 0), Quaternion.identity); 
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 force = new Vector2 (0, 0);


		if(Input.GetKey(KeyCode.LeftShift)){
			speed = startSpeed * 1.5f;
		}else{
			speed = startSpeed;
		}


		if (Input.GetKey ("w")) {
			force.y += speed;
		}

		if (Input.GetKey ("s")) {
			force.y -= speed;
		}

		if (Input.GetKey ("a")) {
			force.x -= speed;
		}

		if (Input.GetKey ("d")) {
			force.x += speed;
		}
		GetComponent<Rigidbody2D> ().velocity = force;
	}
}
