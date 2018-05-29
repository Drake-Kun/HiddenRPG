using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Party : MonoBehaviour {

    public GameObject gameinfo;
    public int num;
    void Awake()
    {
        gameinfo = GameObject.Find("gameinfo");
        if (gameinfo.GetComponent<listofParty>().list.Count >= num + 1)
        {
            gameObject.GetComponentInChildren<Text>().text = gameinfo.GetComponent<listofParty>().list[num].name + "";
            gameObject.GetComponent<Button>().interactable = true;
        }
        else
            gameObject.GetComponent<Button>().interactable = false;

    }
    
	public	void OnMouseOver()
    {
        gameObject.GetComponent<Image>().color = new Vector4(200, 200, 200, 1);
        gameObject.GetComponentInParent<Selection>().selectedchar = gameinfo.GetComponent<listofParty>().list[num];
        gameObject.GetComponent<AudioSource>().Play();
    }
	
}
