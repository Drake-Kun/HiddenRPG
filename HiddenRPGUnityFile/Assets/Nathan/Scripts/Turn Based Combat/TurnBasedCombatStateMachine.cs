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
    public bool expGivenBool;

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
        expGivenBool = false;
        // Grabs the list of our party units from our (GameInformationObject)
        //for (int i = 0; i < 4; i++)
        //{
        //    partyUnitsInfo.Add(gameinfo.GetComponent<listofParty>().ReturnChar(i));
        //}


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
        activePartyMember = partyUnits[activePartyMemberInt];

        switch (currentState)
        {

            case (BattleStates.START):

                activePartyMemberInt = 0;

                break;


            case (BattleStates.PLAYERCHOICE):

                

                

                break;


            case (BattleStates.ENEMYCHOICE):

                break;


            case (BattleStates.CALCULATEDAMAGE):

                // Run the MakeOrderOfCombat() function to figure out who goes first.
                GetComponent<SetOrderOfCombat>().MakeOrderOfCombat();

                // (player1s turn)
                // We use fireball
                // GetComponent<SpellFunctions>().Fireball();

                break;


            case (BattleStates.LOSE):

                // Go back to last save point

                break;


            case (BattleStates.WIN):
                
                if (expGivenBool == false)
                {
                    for (int i = 0; i < partyUnitsInfo.Count; i++)
                    {
                        partyUnitsInfo[i].AfterBattle();
                    }

                    expGivenBool = true;
                }
                // if (you press continue) { SceneManager.SetActiveScene(gameinfo.GetComponent<GameInformation>().OverworldScene); }

                break;

        }
    }

    void OnClickAttack()
    {
        activePartyMember.GetComponent<CalculateDamage>().actionName = "Attack";
    }

    void OnclickSpell1()
    {
        activePartyMember.GetComponent<CalculateDamage>().actionName = currentSpellBook[0];
    }

    void OnclickSpell2()
    {
        activePartyMember.GetComponent<CalculateDamage>().actionName = currentSpellBook[1];
    }

    void OnclickSpell3()
    {
        activePartyMember.GetComponent<CalculateDamage>().actionName = currentSpellBook[2];
    }

    void OnclickSpell4()
    {
        activePartyMember.GetComponent<CalculateDamage>().actionName = currentSpellBook[3];
    }

    void OnclickSpell5()
    {
        activePartyMember.GetComponent<CalculateDamage>().actionName = currentSpellBook[4];
    }

    void OnclickSpell6()
    {
        activePartyMember.GetComponent<CalculateDamage>().actionName = currentSpellBook[5];
    }

    void OnClickEnemy1()
    {
        activePartyMember.GetComponent<CalculateDamage>().targetUnit = enemyUnits[0];
        activePartyMemberInt++;
    }
}