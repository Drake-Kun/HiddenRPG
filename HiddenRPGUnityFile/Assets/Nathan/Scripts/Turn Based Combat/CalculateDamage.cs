using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateDamage : MonoBehaviour {

    public string attackName;
    public bool validMove;

    public GameObject activeUnit;
    public GameObject targetUnit;

    public void BloodSacrificeCheck()
    {
        if (attackName == "Shine" && activeUnit.GetComponent<PlayerInformation>().representative.hp < (activeUnit.GetComponent<PlayerInformation>().representative.maxhp / 10))
        {
            validMove = false;
        }

        else if (attackName == "Radiate" && activeUnit.GetComponent<PlayerInformation>().representative.hp < (activeUnit.GetComponent<PlayerInformation>().representative.maxhp / 10 * 2))
        {
            validMove = false;
        }

        else if (attackName == "Purify" && activeUnit.GetComponent<PlayerInformation>().representative.hp < (activeUnit.GetComponent<PlayerInformation>().representative.maxhp / 10 * 3))
        {
            validMove = false;
        }

        else if (attackName == "Shade" && activeUnit.GetComponent<PlayerInformation>().representative.hp < (activeUnit.GetComponent<PlayerInformation>().representative.maxhp / 10))
        {
            validMove = false;
        }

        else if (attackName == "Darken" && activeUnit.GetComponent<PlayerInformation>().representative.hp < (activeUnit.GetComponent<PlayerInformation>().representative.maxhp / 10 * 2))
        {
            validMove = false;
        }

        else if (attackName == "Taint" && activeUnit.GetComponent<PlayerInformation>().representative.hp < (activeUnit.GetComponent<PlayerInformation>().representative.maxhp / 10 * 3))
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
        if (gameObject.GetComponent<PlayerInformation>() == true)
        {
            GetComponent<SpellFunctions>().converter(attackName);
        }

        else if (gameObject.GetComponent<EnemyInformation>() == true)
        {
            GetComponent<EnemySpellFunctions>().converter(attackName);
        }
    }

}
