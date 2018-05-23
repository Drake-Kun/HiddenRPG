using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class useButtons : MonoBehaviour {
    public Selection canvas;
    GameObject gameinfo;
    public bool is_Text;
    void Start()
    {
        gameinfo = GameObject.Find("gameinfo");
    }

    void Update()
    {
        if (canvas.selected != null && !is_Text)
            gameObject.GetComponent<Button>().interactable = true;

        if (gameinfo.GetComponent<Inventory>().items[canvas.selected.GetComponent<Tools>().num].is_bomb && is_Text)
        {
            gameObject.GetComponent<Text>().text = "this " + gameinfo.GetComponent<Inventory>().items[canvas.selected.GetComponent<Tools>().num].Name + " does " + gameinfo.GetComponent<Inventory>().items[canvas.selected.GetComponent<Tools>().num].damage + " damage";
        }

        if (gameinfo.GetComponent<Inventory>().items[canvas.selected.GetComponent<Tools>().num].is_bomb && is_Text)
        {

        }

        if (gameinfo.GetComponent<Inventory>().items[canvas.selected.GetComponent<Tools>().num].is_bomb && is_Text)
        {
        
        }

    }

}
