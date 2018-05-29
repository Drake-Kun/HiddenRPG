using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tools : MonoBehaviour {

    public GameObject gameinfo;
    public int num;
    void Update()
    {
        gameinfo = GameObject.Find("gameinfo");
        if (gameinfo.GetComponent<Inventory>().items.Count >= num + 1 )
        {
            gameObject.GetComponentInChildren<Text>().text = gameinfo.GetComponent<Inventory>().items[num].name + "";
            gameObject.GetComponent<Button>().interactable = true;
        }
        else {
            gameObject.GetComponent<Button>().interactable = false;
            gameObject.GetComponentInChildren<Text>().text = "";
                }

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
        gameObject.GetComponent<AudioSource>().Play();
    }
	
}
