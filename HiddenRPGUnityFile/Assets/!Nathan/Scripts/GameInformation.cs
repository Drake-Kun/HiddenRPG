using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInformation : MonoBehaviour {

    // areaID #1 = "A place"
    // areaID #2 = "A different place"
    // etc.

    public int areaID;
    
	void Start () {
        DontDestroyOnLoad(this.gameObject);
	}
	
	void Update () {
		
	}
}
