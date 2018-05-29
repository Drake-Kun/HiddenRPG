using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TurnBasedCombatStateMachine : MonoBehaviour {

    // This is our gameinfo object, I don't know if we NEED it. We could refine how we use it though.
    public GameObject gameinfo;

    public List<combatidea> partyUnitsInfo;

    // A list of our party members
    public List<GameObject> partyUnits;

    // This is the spellbook of our current activeUnit
    public List<string> currentSpellBook;

    public int activePartyMemberInt;
    // Do we need this? We could probably remove it. Active party member, though.
    public GameObject activePartyMember;

    // Our active unit. This changes as CALCULATEDAMAGE progresses from one unit to another.
    public GameObject activeUnit;

    // Our active unit's target unit. This changes as CALCULATEDAMAGE progresses from one unit to another.
    public GameObject targetUnit;

    public List<GameObject> enemyUnits;

    // This is the list that has the order of units that will take action based on speed: Fastest goes first, slowest goes last. Updates after every DoDamage();
    public List<GameObject> orderOfCombat;

    // This is the text that will display the progressive information of the battle, such as damage done, status effects inflicted, etc.
    public GameObject displayText;

    public int expGiven;
    public bool expGivenBool;

    // 0. Initialize the order of combat, this will also do the damage for the first unit in (orderOfCombat), then skip to whatever stageOfDamageCalculation that is appropriate
    // 1. Unit does damage
    // 2. Unit fells the enemy (not always), check here to see if all of the units in (enemyUnits) or (playerUnits) are dead, send the player to WIN or LOSE as deemed appropriate.
    // 3. Unit inflicts a status ailment (not always)
    // 4. Remove the current unit from the orderOfCombat list, MakeOrderOfCombat(), stageOfDamageCalculation = 1 again.
    // 5. If our int for who's turn it is exceeds (combatUnits.Count), stageOfCombatCalculation = 5, remove all units from combatUnits. GO TO START
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

        
        

        // Goes through the (EnemyUnits) list and get sthe (expGiven) stat from each enemy,
        // then adds them all up into our (expGiven) stat in this script
        for (int i = 0; i < enemyUnits.Count; i++)
        {
            expGiven += enemyUnits[i].GetComponent<EnemyInformation>().expGiven;
        }
                
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            GetComponent<SetOrderOfCombat>().MakeOrderOfCombat();
        }

        // activePartyMember = partyUnits[activePartyMemberInt];

        switch (currentState)
        {

            case (BattleStates.START):

                activePartyMemberInt = 0;

                break;


            case (BattleStates.PLAYERCHOICE):


                // vvv When we are done making our choices, probably an if statement vvv
                stageOfDamageCalculation = 0;

                break;


            case (BattleStates.ENEMYCHOICE):

                break;


            case (BattleStates.CALCULATEDAMAGE):

                // After the player has decided what they are going to do, and the enemy has as well, we set the stageOfDamageCalculation = 0,
                // This will allow us to InitiateOrderOfCombat(), adding all units who are alive to the combatUnits list.
                if (stageOfDamageCalculation == 0)
                {
                    GetComponent<SetOrderOfCombat>().InitiateOrderOfCombat();

                    stageOfDamageCalculation = 1;
                    
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    
                }

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
            if (stageOfDamageCalculation == 1)
            {
                orderOfCombat[0].GetComponent<CalculateDamage>().DoDamage();
                displayText.GetComponent<Text>().text = targetUnit.GetComponent<EnemyInformation>().Name + " takes " + displayDamage + " damage!";
            }

            else if (stageOfDamageCalculation == 3 && statusAilment != null)
            {
                displayText.GetComponent<Text>().text = targetUnit.GetComponent<EnemyInformation>().Name + " is now " + statusAilment;
            }

            else if (stageOfDamageCalculation == 2)
            {
                displayText.GetComponent<Text>().text = "You fell the " + targetUnit.GetComponent<EnemyInformation>().Name + "!";
            }
        }

        else if (activeUnit.GetComponent<PlayerInformation>() == true)
        {
            if (stageOfDamageCalculation == 1)
            {
                orderOfCombat[0].GetComponent<CalculateDamage>().DoDamage();
                displayText.GetComponent<Text>().text = targetUnit.GetComponent<PlayerInformation>().representative.name + " takes " + displayDamage + " damage!";
            }

            else if (stageOfDamageCalculation == 3 && statusAilment != null)
            {
                displayText.GetComponent<Text>().text = targetUnit.GetComponent<PlayerInformation>().representative.Name + " is now " + statusAilment;
            }

            else if (stageOfDamageCalculation == 2)
            {
                displayText.GetComponent<Text>().text = "You fell the " + targetUnit.GetComponent<PlayerInformation>().representative.Name + "!";
            }
        }
    }
}