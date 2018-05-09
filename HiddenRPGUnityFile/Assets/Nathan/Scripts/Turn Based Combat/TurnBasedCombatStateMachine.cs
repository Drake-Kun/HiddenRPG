using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TurnBasedCombatStateMachine : MonoBehaviour {

    // Create a list here for our party members
    // Create a list here for our enemy units

    public int expRewarded;

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
        
    }

    void Update()
    {
        switch (currentState)
        {

            case (BattleStates.START):



                break;


            case (BattleStates.PLAYERCHOICE):

                break;


            case (BattleStates.ENEMYCHOICE):

                break;


            case (BattleStates.CALCULATEDAMAGE):

                break;


            case (BattleStates.LOSE):

                break;


            case (BattleStates.WIN):

                break;

        }
    }
}