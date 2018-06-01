using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour {
    public items[] whats_In_The_Chest;
	// Use this for initialization
    void OnTriggerEnter2D(Collider2D collision)
    {
       if( collision.gameObject.tag == "Player")
        {

                GameObject.Find("gameinfo").GetComponent<Inventory>().items.AddRange(whats_In_The_Chest);
            GameObject.Find("gameinfo").GetComponent<Inventory>().items.RemoveRange(0,whats_In_The_Chest.Length);
        }
    }

}
