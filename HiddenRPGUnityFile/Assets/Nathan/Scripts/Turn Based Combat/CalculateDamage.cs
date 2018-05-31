using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateDamage : MonoBehaviour {

    public string attackName;
    public bool validMove;

    public GameObject targetUnit;

    public void BloodSacrificeCheck()
    {
        if (attackName == "Shine" && GetComponent<PlayerInformation>().representative.hp < (GetComponent<PlayerInformation>().representative.maxhp / 10))
        {
            validMove = false;
        }

        else if (attackName == "Radiate" && GetComponent<PlayerInformation>().representative.hp < (GetComponent<PlayerInformation>().representative.maxhp / 10 * 2))
        {
            validMove = false;
        }

        else if (attackName == "Purify" && GetComponent<PlayerInformation>().representative.hp < (GetComponent<PlayerInformation>().representative.maxhp / 10 * 3))
        {
            validMove = false;
        }

        else if (attackName == "Shade" && GetComponent<PlayerInformation>().representative.hp < (GetComponent<PlayerInformation>().representative.maxhp / 10))
        {
            validMove = false;
        }

        else if (attackName == "Darken" && GetComponent<PlayerInformation>().representative.hp < (GetComponent<PlayerInformation>().representative.maxhp / 10 * 2))
        {
            validMove = false;
        }

        else if (attackName == "Taint" && GetComponent<PlayerInformation>().representative.hp < (GetComponent<PlayerInformation>().representative.maxhp / 10 * 3))
        {
            validMove = false;
        }

        else
        {
            validMove = true;
        }
    }

    public void DoDamage()
    {
        GetComponent<SpellFunctions>().activeUnit = gameObject;
        GetComponent<SpellFunctions>().targetUnit = targetUnit;
        GetComponent<SpellFunctions>().converter(attackName);
    }

}
