using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Use : MonoBehaviour {
    public GameObject Selection;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		if(Selection.GetComponent<Selection>().selected != null && Selection.GetComponent<Selection>().selectedchar != null)
        {
            gameObject.GetComponent<Button>().interactable = true;


        }
    }


   public void Equip()
    {
        int num = Selection.GetComponent<Selection>().selected.GetComponent<Tools>().num;
        if (Selection.GetComponent<Selection>().selected.GetComponent<Tools>().gameinfo.GetComponent<Inventory>().items[num].is_equipment)
        {
            Debug.Log("hey you have a sword");
            // if has a weapon then return it to inventory and - stats
            if (Selection.GetComponent<Selection>().selectedchar.weapon != null)
            {
                Debug.Log("hey you have a sword 22");

                Selection.GetComponent<Selection>().selected.GetComponent<Tools>().gameinfo.GetComponent<Inventory>().items.Add(Selection.GetComponent<Selection>().selectedchar.weapon);
                Selection.GetComponent<Selection>().selectedchar.weapon = Selection.GetComponent<Selection>().selected.GetComponent<Tools>().gameinfo.GetComponent<Inventory>().items[num];
                Selection.GetComponent<Selection>().selected.GetComponent<Tools>().gameinfo.GetComponent<Inventory>().items.RemoveAt(num);

                Selection.GetComponent<Selection>().selectedchar.def = Selection.GetComponent<Selection>().selectedchar.def - Selection.GetComponent<Selection>().selectedchar.weapon.def_increase;
                Selection.GetComponent<Selection>().selectedchar.intel = Selection.GetComponent<Selection>().selectedchar.intel - Selection.GetComponent<Selection>().selectedchar.weapon.intel_increase;
                Selection.GetComponent<Selection>().selectedchar.magdef = Selection.GetComponent<Selection>().selectedchar.magdef - Selection.GetComponent<Selection>().selectedchar.weapon.mag_def_increase;
                Selection.GetComponent<Selection>().selectedchar.speed = Selection.GetComponent<Selection>().selectedchar.speed - Selection.GetComponent<Selection>().selectedchar.weapon.speed_increase;
                Selection.GetComponent<Selection>().selectedchar.str = Selection.GetComponent<Selection>().selectedchar.str - Selection.GetComponent<Selection>().selectedchar.weapon.str_increase;


            }
            //-----------------------------------------------------------
            else
            {
                Debug.Log("plaese don't show");
                Selection.GetComponent<Selection>().selected.GetComponent<Tools>().gameinfo.GetComponent<Inventory>().items.RemoveAt(num);



                Selection.GetComponent<Selection>().selectedchar.weapon = Selection.GetComponent<Selection>().selected.GetComponent<Tools>().gameinfo.GetComponent<Inventory>().items[num];


                Selection.GetComponent<Selection>().selectedchar.def = Selection.GetComponent<Selection>().selectedchar.def + Selection.GetComponent<Selection>().selectedchar.weapon.def_increase;
                Selection.GetComponent<Selection>().selectedchar.intel = Selection.GetComponent<Selection>().selectedchar.intel + Selection.GetComponent<Selection>().selectedchar.weapon.intel_increase;
                Selection.GetComponent<Selection>().selectedchar.magdef = Selection.GetComponent<Selection>().selectedchar.magdef + Selection.GetComponent<Selection>().selectedchar.weapon.mag_def_increase;
                Selection.GetComponent<Selection>().selectedchar.speed = Selection.GetComponent<Selection>().selectedchar.speed + Selection.GetComponent<Selection>().selectedchar.weapon.speed_increase;
                Selection.GetComponent<Selection>().selectedchar.str = Selection.GetComponent<Selection>().selectedchar.str + Selection.GetComponent<Selection>().selectedchar.weapon.str_increase;
            }
        }
        if ((Selection.GetComponent<Selection>().selected.GetComponent<Tools>().gameinfo.GetComponent<Inventory>().items[num].is_potion)){
            Debug.Log("and its a potion");
            Selection.GetComponent<Selection>().selectedchar.hp += Selection.GetComponent<Selection>().selected.GetComponent<Tools>().gameinfo.GetComponent<Inventory>().items[num].healing;
            if (Selection.GetComponent<Selection>().selectedchar.hp > Selection.GetComponent<Selection>().selectedchar.maxhp)
                Selection.GetComponent<Selection>().selectedchar.hp = Selection.GetComponent<Selection>().selectedchar.maxhp;

                Selection.GetComponent<Selection>().selected.GetComponent<Tools>().gameinfo.GetComponent<Inventory>().items.RemoveAt(num);
        }
    }
}