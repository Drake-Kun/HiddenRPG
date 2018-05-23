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
    public GameObject activeUnit;
    public GameObject targetUnit;

    public List<GameObject> enemyUnits;

    public List<GameObject> orderOfCombat;


    public int expGiven;
    public bool expGivenBool;

    // 1. Unit does damage
    // 2. Unit inflicts a status ailment (not always)
    // 3. Unit fells the enemy (not always)
    public int stageOfDamageCalculation;
    public int displayDamage;
    public string statusAilment;
    
    

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
        for (int i = 0; i < gameinfo.GetComponent<listofParty>().list.Count; i++)
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
        activePartyMember.GetComponent<CalculateDamage>().attackName = "Attack";
    }

    void OnclickSpell1()
    {
        activePartyMember.GetComponent<CalculateDamage>().attackName = currentSpellBook[0];
        activePartyMember.GetComponent<CalculateDamage>().BloodSacrificeCheck();
        if (activePartyMember.GetComponent<CalculateDamage>().validMove == false)
        {
            // Tell the player "NO!!!"
            activePartyMember.GetComponent<CalculateDamage>().attackName = null;
            return;
        }

        // Let the player Select and enemy
    }

    void OnclickSpell2()
    {
        activePartyMember.GetComponent<CalculateDamage>().attackName = currentSpellBook[1];
        activePartyMember.GetComponent<CalculateDamage>().BloodSacrificeCheck();
        if (activePartyMember.GetComponent<CalculateDamage>().validMove == false)
        {
            // Tell the player "NO!!!"
            activePartyMember.GetComponent<CalculateDamage>().attackName = null;
            return;
        }

        // Let the player Select and enemy
    }

    void OnclickSpell3()
    {
        activePartyMember.GetComponent<CalculateDamage>().attackName = currentSpellBook[2];
        activePartyMember.GetComponent<CalculateDamage>().BloodSacrificeCheck();
        if (activePartyMember.GetComponent<CalculateDamage>().validMove == false)
        {
            // Tell the player "NO!!!"
            activePartyMember.GetComponent<CalculateDamage>().attackName = null;
            return;
        }

        // Let the player Select and enemy
    }

    void OnclickSpell4()
    {
        activePartyMember.GetComponent<CalculateDamage>().attackName = currentSpellBook[3];
        activePartyMember.GetComponent<CalculateDamage>().BloodSacrificeCheck();
        if (activePartyMember.GetComponent<CalculateDamage>().validMove == false)
        {
            // Tell the player "NO!!!"
            activePartyMember.GetComponent<CalculateDamage>().attackName = null;
            return;
        }

        // Let the player Select and enemy
    }

    void OnclickSpell5()
    {
        activePartyMember.GetComponent<CalculateDamage>().attackName = currentSpellBook[4];
        activePartyMember.GetComponent<CalculateDamage>().BloodSacrificeCheck();
        if (activePartyMember.GetComponent<CalculateDamage>().validMove == false)
        {
            // Tell the player "NO!!!"
            activePartyMember.GetComponent<CalculateDamage>().attackName = null;
            return;
        }

        // Let the player Select and enemy
    }

    void OnclickSpell6()
    {
        activePartyMember.GetComponent<CalculateDamage>().attackName = currentSpellBook[5];
        activePartyMember.GetComponent<CalculateDamage>().BloodSacrificeCheck();
        if (activePartyMember.GetComponent<CalculateDamage>().validMove == false)
        {
            // Tell the player "NO!!!"
            activePartyMember.GetComponent<CalculateDamage>().attackName = null;
            return;
        }

        // Let the player Select and enemy
    }

    void OnClickEnemy1()
    {
        activePartyMember.GetComponent<CalculateDamage>().targetUnit = enemyUnits[0];
        if (targetUnit.GetComponent<EnemyInformation>().isDead == true)
        {
            targetUnit = null;
            return;
        }
        activePartyMemberInt++;
    }

    void OnClickEnemy2()
    {
        activePartyMember.GetComponent<CalculateDamage>().targetUnit = enemyUnits[1];
        if (targetUnit.GetComponent<EnemyInformation>().isDead == true)
        {
            targetUnit = null;
            return;
        }
        activePartyMemberInt++;
    }

    void OnClickEnemy3()
    {
        activePartyMember.GetComponent<CalculateDamage>().targetUnit = enemyUnits[2];
        if (targetUnit.GetComponent<EnemyInformation>().isDead == true)
        {
            targetUnit = null;
            return;
        }
        activePartyMemberInt++;
    }

    void OnClickEnemy4()
    {
        activePartyMember.GetComponent<CalculateDamage>().targetUnit = enemyUnits[3];
        if (targetUnit.GetComponent<EnemyInformation>().isDead == true)
        {
            targetUnit = null;
            return;
        }
        activePartyMemberInt++;
    }

    void DamageCalculationProcess(string displayInfo)
    {
        if (activeUnit.GetComponent<EnemyInformation>() == true)
        {
            if (displayInfo == "Damage")
            {
                orderOfCombat[0].GetComponent<CalculateDamage>().DoDamage();
                // text = targetUnit.GetComponent<EnemyInformation>().Name + " takes " + displayDamage + " damage!";
                // displayDamage = null;
            }

            else if (displayInfo == "StatusInfliction" && statusAilment != null)
            {
                // text = targetUnit.GetComponent<EnemyInformation>().Name + " is now " + statusAilment;
            }

            else if (displayInfo == "EnemyDeath")
            {
                // text = "You fell the " + targetUnit.GetComponent<EnemyInformation>().Name;
            }
        }

        else if (activeUnit.GetComponent<PlayerInformation>() == true)
        {
            if (displayInfo == "Damage")
            {
                // text = targetUnit.GetComponent<EnemyInformation>
            }
        }
    }
}