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
        Debug.Log("HIt");
        Enemy = GameObject.Find("combat machine").GetComponent<TurnBasedCombatStateMachine>().enemyUnits[num];
        Debug.Log("HIt");
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
            Debug.Log("hitt");
            }
        //}
        else if (Enemy == null) {
            gameObject.GetComponent<Button>().interactable = false;
            Debug.Log("hittt");
        }
	}
	
	// Update is called once per frame
    public GameObject returnEnemy()
    {
        return Enemy;
    }
}
