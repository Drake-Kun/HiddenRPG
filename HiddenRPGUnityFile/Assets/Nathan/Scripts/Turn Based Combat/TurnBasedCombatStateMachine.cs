using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TurnBasedCombatStateMachine : MonoBehaviour {

    public List<GameObject> playerUnits;

    public List<GameObject> enemyUnits;

    


    public int expGiven;

    public enum BattleStates
    {
        START,
        PLAYERCHOICE,
        ENEMYCHOICE,
        CALCULATEDAMAGE,
        LOSE,
        WIN
    }

    public static BattleStates currentState;

    public void SpawnEnemies()
    {

    }

    void Start()
    {
        currentState = BattleStates.START;
		// Spawn enemies

        // expGiven = all of the enemies expGiven stats added together
        // SO:
        
        //expGiven = enemy1.GetComponent<>().exp + enemy2.GetComponent<>().exp;
        
    }

    void Update()
    {
        switch (currentState)
        {

            case (BattleStates.START):



                break;


            case (BattleStates.PLAYERCHOICE):

                // (player1 selects a target)
                // player1TargetUnit = Some game object

                break;


            case (BattleStates.ENEMYCHOICE):

                break;


            case (BattleStates.CALCULATEDAMAGE):

                // (player1s turn)
                // We use fireball
                // GetComponent<SpellFunctions>().Fireball();

                break;


            case (BattleStates.LOSE):

                // Go back to last save point

                break;


            case (BattleStates.WIN):

                // Reward exp and go back to the location where the player entered battle

                break;

        }
    }
}