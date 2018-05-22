using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetButtons : MonoBehaviour {
    public GameObject Enemy;
    public int num;
	// Use this for initialization
	void FixedUpdate () {

        if (Enemy == null)
        {
            Enemy = GameObject.Find("combat machine").GetComponent<TurnBasedCombatStateMachine>().enemyUnits[num];
        }
	}
	
	// Update is called once per frame
    public GameObject returnEnemy()
    {
        return Enemy;
    }
}
