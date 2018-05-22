using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateDamage : MonoBehaviour {

    public string attackName;
    public GameObject activeUnit;
    public GameObject targetUnit;

    public int str;
    public int def;
    public int intel;
    public int magDef;
    public int speed;

    public bool fireDamage;

    public float hitChance;

    public string actionName;

    public void DoDamage()
    {
        if (activeUnit.GetComponent<PlayerInformation>() == true)
        {
            GetComponent<SpellFunctions>().converter(attackName);
        }

        else if (activeUnit.GetComponent<EnemyInformation>() == true)
        {
            GetComponent<EnemySpellFunctions>().converter(attackName);
        }
    }

}
