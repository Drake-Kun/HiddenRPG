using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour {
    public int number;
    [Space]
   public combatidea refrence;
    [Space]
    public int Cstr;
    public int Cspeed;
    public int Cintel;
    public int Cdef;
    public int Cmagdef;
    [Space]
    public int mana;
    public int maxhp;
    public int hp;
    void Awake()
    {
        if (!(GameObject.Find("gameinfo").GetComponent<listofParty>().list[number] == null))
            refrence = GameObject.Find("gameinfo").GetComponent<listofParty>().list[number];

        gameObject.GetComponent<SpriteRenderer>().sprite = refrence.sprite;

        Cstr = refrence.str;
        Cspeed = refrence.speed;
        Cintel = refrence.intel;
        Cdef = refrence.def;
        Cmagdef = refrence.magdef;

        mana = refrence.mana;
        maxhp = refrence.maxhp;
        hp = refrence.hp;
        
    }

}
