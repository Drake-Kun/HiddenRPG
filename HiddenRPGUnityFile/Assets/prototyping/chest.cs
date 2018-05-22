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
            for (int i = 0; i < whats_In_The_Chest.Length; i++)
            {
                GameObject.Find("gameinfo").GetComponent<Inventory>().items.Add(whats_In_The_Chest[i]);
            }
        }
    }

}
