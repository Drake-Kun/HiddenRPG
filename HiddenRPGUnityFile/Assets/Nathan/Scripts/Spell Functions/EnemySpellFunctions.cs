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
            case "Attack":
                Attack(activeUnit.GetComponent<EnemyInformation>().str, targetUnit.GetComponent<PlayerInformation>().representative.def);
                break;
        }

    }

    public void Attack(int activeStr, int targetDef)
    {
        int damage = Mathf.RoundToInt(activeStr * 1.5f - targetDef);

        // Apply damage
        targetUnit.GetComponent<EnemyInformation>().hpCurrent -= damage;
        if (targetUnit.GetComponent<EnemyInformation>().hpCurrent < 0)
        {
            targetUnit.GetComponent<EnemyInformation>().isDead = true;
        }
    }

}
