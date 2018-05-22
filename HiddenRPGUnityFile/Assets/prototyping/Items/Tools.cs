﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tools : MonoBehaviour {

    public GameObject gameinfo;
    public int num;
    void Awake()
    {
        gameinfo = GameObject.Find("gameinfo");
        if(gameinfo.GetComponent<Inventory>().items.Count >= num)
        gameObject.GetComponentInChildren<Text>().text = gameinfo.GetComponent<Inventory>().items[num].name + "";
    }

    void OnGUI()
    {
        // Make a button using a custom GUIContent parameter to pass in the tooltip.
        

        // Display the tooltip from the element that has mouseover or keyboard focus
        GUI.Label(new Rect(10, 40, gameObject.transform.position.x, gameObject.transform.position.y), GUI.tooltip);
        
    }
    
	public	void OnMouseOver()
    {
        gameObject.GetComponent<Image>().color = new Vector4(200, 200, 200, 1);
        gameObject.GetComponentInParent<Selection>().selected = this.gameObject;
    }
	
}
