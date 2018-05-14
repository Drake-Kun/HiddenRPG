using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class call : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<listofchar>().ReturnChar("kyler");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
