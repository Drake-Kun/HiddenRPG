using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuS : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if we press escape or P
		if(Input.GetKeyDown(KeyCode.Escape) ||
			Input.GetKeyDown(KeyCode.P))
		{
			//stop time from passing in the game
			Time.timeScale = 0;
			//we are assuming this script is attached
			//to our pause canvas
			gameObject.GetComponent<Canvas>().enabled = true;

	}
}

	public void Resume()
	{
		Time.timeScale = 1;
		gameObject.GetComponent<Canvas> ().enabled = false;
	}

	public void RageQuitGame()
	{
		//this will stop the .exe application from
		//running after the game has been built
		Application.Quit ();
	}

}