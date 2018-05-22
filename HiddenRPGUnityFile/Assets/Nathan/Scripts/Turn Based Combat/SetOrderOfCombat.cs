using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOrderOfCombat : MonoBehaviour {

    public List<GameObject> orderOfCombat;

    List<GameObject> partyUnits = GameObject.Find("combat machine").GetComponent<TurnBasedCombatStateMachine>().partyUnits;
    List<GameObject> enemyUnits = GameObject.Find("combat machine").GetComponent<TurnBasedCombatStateMachine>().enemyUnits;

    public List<GameObject> combatUnitsGameObject;

    

}


