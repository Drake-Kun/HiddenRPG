using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="character",menuName = "party",order = 0)]
public class combatidea : ScriptableObject {
    public string Name;
    public Sprite sprite;
    public int mana;
    public int maxhp;
    public int hp;
    public int lv;
    public int exp;
    public int expNeeded;
    public int exponent = 900;
    public int str;
    public int speed;
    public int intel;
    public int def;
    public int magdef;
    public int Cstr;
    public int Cspeed;
    public int Cintel;
    public int Cdef;
    public int Cmagdef;
    public int hpscale;
    public bool prof_str;
    public bool prof_speed;
    public bool prof_intel;
    public bool prof_def;
    public bool prof_magdef;
    public string[] spellbook;

    public void AfterBattle()
    {


        if(exp >= expNeeded)
        {
            lv++;
            expNeeded += exponent;
            exponent += 100 * lv;
            if(hpscale <= 4)
            {
                maxhp += hpscale;
                hp = maxhp;
            }
            if (hpscale <= 4)
            {
                maxhp += hpscale + Mathf.RoundToInt(lv * .2f);
                hp = maxhp;
            }
            if (!prof_str)
                str = str + 3 +Mathf.RoundToInt(lv * .2f);
            else if (prof_str)
            {
                str = str + 6 + Mathf.RoundToInt(lv * .25f);
            }
            if (!prof_speed)
                speed = speed + 3 + Mathf.RoundToInt(lv * .2f);
            else if (prof_speed)
            {
                speed = speed + 6 + Mathf.RoundToInt(lv * .25f);
            }
            if (!prof_intel)
                intel = intel + 3 + Mathf.RoundToInt(lv * .2f);
            else if (prof_intel)
            {
                intel = intel + 6 + Mathf.RoundToInt(lv * .25f);
            }
            if (!prof_def)
                def = def + 3 + Mathf.RoundToInt(lv * .2f);
            else if (prof_def)
            {
                def = def + 6 + Mathf.RoundToInt(lv * .25f);
            }
            if (!prof_magdef)
                magdef = magdef + 3 + Mathf.RoundToInt(lv * .2f);
            else if (prof_magdef)
            {
                magdef = magdef + 6 + Mathf.RoundToInt(lv * .25f);
            }
            Cdef = def;
            Cmagdef = magdef;
            Cspeed = speed;
            Cstr = str;
            intel = Cintel;




        }
        // add exp
        // check if we level up
        // if level up: add stats
        
    }
                         
}