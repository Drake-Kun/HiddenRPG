using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpellFunctions : MonoBehaviour {

    public GameObject activeUnit;
    public GameObject targetUnit;

    public void converter(string name)
    {
        switch (name)
        {
            case "attack":
                Attack(activeUnit.GetComponent<EnemyInformation>().str, targetUnit.GetComponent<PlayerInformation>().representative.def);
                break;
        }

    }

    public void Attack(int activeStr, int targetDef)
    {
        int damage = (activeStr *= 2 - targetDef);
    }

}
