using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReadGold : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       gameObject.GetComponent<Text>().text = "Gold: " + GameObject.Find("gameinfo").GetComponent<Inventory>().Gold;

    }
}
