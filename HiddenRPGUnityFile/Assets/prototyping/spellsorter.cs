using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class spellsorter : MonoBehaviour {
    public combatidea current_charecter;
    combatidea stored_charecter;
    public GameObject[] buttons;
	// Use this for initialization
	void Start () {
        stored_charecter = current_charecter;	
	}
    // Update is called once per frame

    void Update () {
        if(current_charecter != stored_charecter)
        {
            Update_Charecter();
        }
	}

    public void Update_Charecter (combatidea new_charecter)
    {
        current_charecter = new_charecter;
        stored_charecter = current_charecter;
        for (int i = 0; i < current_charecter.spellbook.Count; i++)
        {

            buttons[i].GetComponentInChildren<Text>().text = current_charecter.spellbook[i];
        }
    }

    public void Update_Charecter()
    {
        stored_charecter = current_charecter;
        for (int i = 0; i < current_charecter.spellbook.Count; i++)
        {
            buttons[i].GetComponentInChildren<Text>().text = current_charecter.spellbook[i];
        }
    }
}
