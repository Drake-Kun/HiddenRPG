using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public GameObject[] list;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        for (int i = 0; i < list.Length; i++)
        {
            
            list[i].GetComponent<TargetButtons>().ModifiedStart();

        }
    }
}
