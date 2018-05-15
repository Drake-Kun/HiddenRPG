using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TurnBasedCombatStateMachine : MonoBehaviour {

    public GameObject gameinfo;
    public List<combatidea> partyUnitsInfo;
    public List<GameObject> partyUnits;
    public List<string> currentSpellBook;

    public int activePartyMemberInt;
    public GameObject activePartyMember;
    public GameObject targetUnit;

    public List<GameObject> enemyUnits;

    public List<GameObject> orderOfCombat;


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

    void Start()
    {
        currentState = BattleStates.START;

        // Grabs the list of our party units from our (GameInformationObject)
        for (int i = 0; i < 4; i++)
        {
            partyUnitsInfo.Add(gameinfo.GetComponent<listofParty>().ReturnChar(i));
        }


        // Grabs the (enemies) list from the (SpawnEnemies) script
        enemyUnits = GetComponent<SpawnEnemies>().enemies;
    
        // Goes through the (EnemyUnits) list and get sthe (expGiven) stat from each enemy,
        // then adds them all up into our (expGiven) stat in this script
        for (int i = 0; i < enemyUnits.Count; i++)
        {
            expGiven += enemyUnits[i].GetComponent<EnemyInformation>().expGiven;
        }
                
    }

    void Update()
    {
        switch (currentState)
        {

            case (BattleStates.START):



                break;


            case (BattleStates.PLAYERCHOICE):

                

                // (player1 selects a target)
                // activePartyMember

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