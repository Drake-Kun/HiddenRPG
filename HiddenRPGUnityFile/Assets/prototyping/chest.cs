using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour {
    public items[] WhatsInTheChest;
    public int GoldInChest; 
	// Use this for initialization
    void OnTriggerEnter2D(Collider2D collision)
    {
       if( collision.gameObject.tag == "Player")
        {

                GameObject.Find("gameinfo").GetComponent<Inventory>().items.AddRange(WhatsInTheChest);
            GameObject.Find("gameinfo").GetComponent<Inventory>().items.RemoveRange(0,WhatsInTheChest.Length);
            GameObject.Find("gameinfo").GetComponent<Inventory>().Gold += GoldInChest;

        }
    }

}
