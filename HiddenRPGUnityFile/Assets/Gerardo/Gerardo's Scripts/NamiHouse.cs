﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NamiHouse : MonoBehaviour {

	/*we created a new function ever object with this script attached to it
	 * collides with another object this function recieves a variable of type collision 2d named myCollisionInfo that acts like and incident
	 */
	void OnCollisionEnter2D(Collision2D myCollisionInfo)
	{
		//we debug.log the name of the object we
		//ran into,that triggered the collision
		Debug.Log (myCollisionInfo.gameObject.name); 
		if (myCollisionInfo.gameObject.name == "Door") 
		{
			//load next level
			SceneManager.LoadScene("House");
			//this code will reload the current scene
			//SceneManager.LoadScene(SceneManager.GetActiveScene().name);


		}
	}

}