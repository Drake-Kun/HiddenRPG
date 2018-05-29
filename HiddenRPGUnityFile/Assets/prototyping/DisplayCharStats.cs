using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayCharStats : MonoBehaviour {

    public GameObject Selection;

	void Update () {

        gameObject.GetComponent<Text>().text = Selection.GetComponent<Selection>().selectedchar.name + "\r\n" + 
            "Hp: " + Selection.GetComponent<Selection>().selectedchar.hp + "/" + Selection.GetComponent<Selection>().selectedchar.maxhp + "\r\n" + 
            "Strength: " + Selection.GetComponent<Selection>().selectedchar.Cstr + "\r\n" +
             "Inteligence: " + Selection.GetComponent<Selection>().selectedchar.Cintel + "\r\n" +
             "Speed: " + Selection.GetComponent<Selection>().selectedchar.Cspeed + "\r\n" +
             "Defense: " + Selection.GetComponent<Selection>().selectedchar.Cdef + "\r\n" +
             "Magic Defense: " + Selection.GetComponent<Selection>().selectedchar.Cmagdef;

    }
}
