using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOrderOfCombat : MonoBehaviour {

    public List<GameObject> orderOfCombat;

    List<GameObject> partyUnits = GameObject.Find("combat machine").GetComponent<TurnBasedCombatStateMachine>().partyUnits;
    List<GameObject> enemyUnits = GameObject.Find("combat machine").GetComponent<TurnBasedCombatStateMachine>().enemyUnits;

    public List<GameObject> combatUnitsGameObject;

    public void MakeOrderOfCombat()
    {
        List<CombatUnit> combatUnitsClass = new List<CombatUnit>();
        GameObject[] combatUnitsList = combatUnitsGameObject;

        for (int i = 0; i < combatUnitsClass; i++)
        {

        }

        // Add our party units to the total combatUnits list
        for (int i1 = 0; i1 < partyUnits.Count; i1++)
        {
            combatUnits.Add(partyUnits[i1]);
        }

        // Add the enemy units to the total combatUnits list
        for (int i2 = 0; i2 < partyUnits.Count; i2++)
        {
            combatUnits.Add(enemyUnits[i2]);
        }


        for (int i3 = 0; i3 < combatUnits.Count; i3++) {
            combatUnits.Sort()

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
