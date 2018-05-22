using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SetOrderOfCombat : MonoBehaviour {

    public List<GameObject> orderOfCombat;

    List<GameObject> partyUnits = GameObject.Find("combat machine").GetComponent<TurnBasedCombatStateMachine>().partyUnits;
    List<GameObject> enemyUnits = GameObject.Find("combat machine").GetComponent<TurnBasedCombatStateMachine>().enemyUnits;

    public List<GameObject> combatUnitsGameObject;

    public void InitiateOrderOfCombat()
    {

    }

    public void MakeOrderOfCombat()
    {
        List<CombatUnit> combatUnitsClass = new List<CombatUnit>();

        for (int i = 0; i < combatUnitsClass.Count; i++)
        {

        }

        // Add our party units to the total combatUnits list
        for (int i1 = 0; i1 < partyUnits.Count; i1++)
        {
            combatUnitsGameObject.Add(partyUnits[i1]);
        }

        // Add the enemy units to the total combatUnits list
        for (int i2 = 0; i2 < partyUnits.Count; i2++)
        {
            combatUnitsGameObject.Add(enemyUnits[i2]);
        }
    }

}

public class CombatUnit : IComparable<CombatUnit>
{
    public string name;
    public GameObject me;
    public int spd;

    public CombatUnit()
    {
        name = "default";
        spd = 0;
    }

    public CombatUnit(string unitName, int unitSpd)
    {
        name = unitName;
        spd = unitSpd;
    }

    public int CompareTo(CombatUnit otherUnit)
    {
        return this.spd.CompareTo(otherUnit.spd);
    }
}
