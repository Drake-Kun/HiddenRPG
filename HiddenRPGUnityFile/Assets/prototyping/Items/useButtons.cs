using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class useButtons : MonoBehaviour {
    public Selection canvas;
    GameObject gameinfo;
    public bool is_Text;
    public bool is_image;
    void Start()
    {
        gameinfo = GameObject.Find("gameinfo");
    }

    void Update()
    {
        if (is_image && gameinfo.GetComponent<Inventory>().items[canvas.selected.GetComponent<Tools>().num].Display != null)
            gameObject.GetComponent<Image>().sprite = gameinfo.GetComponent<Inventory>().items[canvas.selected.GetComponent<Tools>().num].Display;
        else if (is_image)
            gameObject.GetComponent<Image>().sprite = null;

        if (gameinfo.GetComponent<Inventory>().items[canvas.selected.GetComponent<Tools>().num].is_equipment && !is_Text && !is_image || gameinfo.GetComponent<Inventory>().items[canvas.selected.GetComponent<Tools>().num].is_potion && !is_Text && !is_image)
            gameObject.GetComponent<Button>().interactable = true;

        if (gameinfo.GetComponent<Inventory>().items[canvas.selected.GetComponent<Tools>().num].is_bomb && is_Text)
            gameObject.GetComponent<Text>().text = "this " + gameinfo.GetComponent<Inventory>().items[canvas.selected.GetComponent<Tools>().num].Name + " does " + gameinfo.GetComponent<Inventory>().items[canvas.selected.GetComponent<Tools>().num].damage + " damage";
        

        if (gameinfo.GetComponent<Inventory>().items[canvas.selected.GetComponent<Tools>().num].is_potion && is_Text)
        {
            gameObject.GetComponent<Text>().text = "this " + gameinfo.GetComponent<Inventory>().items[canvas.selected.GetComponent<Tools>().num].Name + " heals " + gameinfo.GetComponent<Inventory>().items[canvas.selected.GetComponent<Tools>().num].healing + " health";
        }

        if (gameinfo.GetComponent<Inventory>().items[canvas.selected.GetComponent<Tools>().num].is_stat_booster && is_Text)
        {
            gameObject.GetComponent<Text>().text = "this " + gameinfo.GetComponent<Inventory>().items[canvas.selected.GetComponent<Tools>().num].Name + 

                " increases strength by " + gameinfo.GetComponent<Inventory>().items[canvas.selected.GetComponent<Tools>().num].consume_str_increase +

                " increases Speed by " + gameinfo.GetComponent<Inventory>().items[canvas.selected.GetComponent<Tools>().num].consume_speed_increase +

                " increases intelligence by " + gameinfo.GetComponent<Inventory>().items[canvas.selected.GetComponent<Tools>().num].consume_intel_increase +

                " increases defense by " + gameinfo.GetComponent<Inventory>().items[canvas.selected.GetComponent<Tools>().num].consume_def_increase +

                " increases magic defense by " + gameinfo.GetComponent<Inventory>().items[canvas.selected.GetComponent<Tools>().num].consume_mag_def_increase;
        }
        if (gameinfo.GetComponent<Inventory>().items[canvas.selected.GetComponent<Tools>().num].is_equipment && is_Text)
        {
            gameObject.GetComponent<Text>().text = "this " + gameinfo.GetComponent<Inventory>().items[canvas.selected.GetComponent<Tools>().num].Name +

                " increases strength by " + gameinfo.GetComponent<Inventory>().items[canvas.selected.GetComponent<Tools>().num].str_increase +

                " increases Speed by " + gameinfo.GetComponent<Inventory>().items[canvas.selected.GetComponent<Tools>().num].speed_increase +

                " increases intelligence by " + gameinfo.GetComponent<Inventory>().items[canvas.selected.GetComponent<Tools>().num].intel_increase +

                " increases defense by " + gameinfo.GetComponent<Inventory>().items[canvas.selected.GetComponent<Tools>().num].def_increase +

                " increases magic defense by " + gameinfo.GetComponent<Inventory>().items[canvas.selected.GetComponent<Tools>().num].mag_def_increase;
        }

    }

}
