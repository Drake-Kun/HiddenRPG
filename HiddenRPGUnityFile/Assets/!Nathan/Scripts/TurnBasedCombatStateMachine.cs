using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TurnBasedCombatStateMachine : MonoBehaviour {


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
        SpawnEnemies();
    }

    void Update()
    {
        switch (currentState)
        {

            case (BattleStates.START):

                // This is the beginning of each turn

                break;


            case (BattleStates.PLAYERCHOICE):

                // This is where the menu-related code will probably be

                break;


            case (BattleStates.ENEMYCHOICE):

                // This is where we'll process enemy choices

                break;


            case (BattleStates.CALCULATEDAMAGE):

                // Units take turns based on speed

                // Here we'll calculate and 

                break;


            case (BattleStates.LOSE):

                break;


            case (BattleStates.WIN):

                break;

        }
    }
}