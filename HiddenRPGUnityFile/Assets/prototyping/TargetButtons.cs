using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TargetButtons : MonoBehaviour {
    public GameObject Enemy;
    public int num;
    // Use this for initialization
    public void ModifiedStart()
        {
       
        Enemy = GameObject.Find("combat machine").GetComponent<TurnBasedCombatStateMachine>().enemyUnits[num];
        
        }
	void FixedUpdate () {

        /*        if (Enemy == null)
                {
                    Enemy = GameObject.Find("combat machine").GetComponent<TurnBasedCombatStateMachine>().enemyUnits[num];
                   */
        if (Enemy != null)
        {
            gameObject.GetComponent<Button>().interactable = true;
            gameObject.GetComponentInChildren<Text>().text = Enemy.GetComponent<EnemyInfo>().name;
            
            }
        //}
        else if (Enemy == null) {
            gameObject.GetComponent<Button>().interactable = false;
            
        }
	}
	
	// Update is called once per frame
    public GameObject returnEnemy()
    {
        return Enemy;
    }
}
