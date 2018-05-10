﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="character",menuName = "party",order = 0)]
public class combatidea : ScriptableObject {
    public Sprite sprite;
    public int hp;
    public int lv;
    public int exp;
    public int expNeeded;
    int exponent = 900;
    public int str;
    public int speed;
    public int intel;
    public int def;
    public int magdef;
    public bool prof_str;
    public bool prof_speed;
    public bool prof_intel;
    public bool prof_def;
    public bool prof_magdef;

    public void AfterBattle()
    {


        if(exp >= expNeeded)
        {
            lv++;
            expNeeded += exponent;
            exponent += 300;
            if (!prof_str)
                str += str + 3;
            else if (prof_str)
            {
                str += str + 6;
            } 
        }
        // add exp
        // check if we level up
        // if level up: add stats
    }
                         
}