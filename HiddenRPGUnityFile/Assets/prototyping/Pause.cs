using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
    public GameObject Canvas;
    public string button;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(button))
        {
            Switch();
        }
	}

    void Switch()
    {
        if (Canvas.activeSelf)
        {
            Canvas.SetActive(false);
        }
        else
            Canvas.SetActive(true);
    }
}
