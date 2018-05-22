using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateDamage : MonoBehaviour {

    public string attackName;
    public GameObject targetUnit;

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
