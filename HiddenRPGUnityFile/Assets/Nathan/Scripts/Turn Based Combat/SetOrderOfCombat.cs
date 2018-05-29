using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SetOrderOfCombat : MonoBehaviour {

    public List<GameObject> orderOfCombat;

    List<GameObject> partyUnits;
    List<GameObject> enemyUnits;

    public List<GameObject> combatUnits;

    public void InitiateOrderOfCombat()
    {
        List<GameObject> partyUnits = GameObject.Find("combat machine").GetComponent<TurnBasedCombatStateMachine>().partyUnits;
        List<GameObject> enemyUnits = GameObject.Find("combat machine").GetComponent<TurnBasedCombatStateMachine>().enemyUnits;
        // Add our party units to the total combatUnits list
        for (int i1 = 0; i1 < partyUnits.Count; i1++)
        {
            if (partyUnits[i1].GetComponent<PlayerInformation>().representative.hp != 0)
            {
                combatUnits.Add(partyUnits[i1]);
            }
        }

        // Add the enemy units to the total combatUnits list
        for (int i2 = 0; i2 < enemyUnits.Count; i2++)
        {
            if (enemyUnits[i2].GetComponent<EnemyInformation>().hpCurrent != 0)
            {
                combatUnits.Add(enemyUnits[i2]);
            }
        }
    }

    public void MakeOrderOfCombat()
    {
        List<int> speedValues = new List<int>();

        for (int i = 0; i < combatUnits.Count; i++)
        {
            if (combatUnits[i].GetComponent<EnemyInformation>() == true)
            {
                speedValues.Add(combatUnits[i].GetComponent<EnemyInformation>().spd);
            }

            else if (combatUnits[i].GetComponent<PlayerInformation>() == true)
            {
                speedValues.Add(combatUnits[i].GetComponent<PlayerInformation>().representative.Cspeed);
            }
        }

        speedValues.Sort();
        speedValues.Reverse();

        for (int i2 = speedValues[0]; i2 > 0; i2--)
        {
            for (int i3 = 0; i3 < combatUnits.Count; i3++)
            {
                if (combatUnits[i3].GetComponent<EnemyInformation>() == true)
                {
                    if (combatUnits[i3].GetComponent<EnemyInformation>().spd == i2)
                    {
                        orderOfCombat.Add(combatUnits[i3]);
                    }
                }

                else if (combatUnits[i3].GetComponent<PlayerInformation>() == true)
                {
                    if (combatUnits[i3].GetComponent<PlayerInformation>().representative.Cspeed == i2)
                    {
                        orderOfCombat.Add(combatUnits[i3]);
                    }
                }
            }
        }

        GetComponent<TurnBasedCombatStateMachine>().orderOfCombat = orderOfCombat;
       
    }

}
