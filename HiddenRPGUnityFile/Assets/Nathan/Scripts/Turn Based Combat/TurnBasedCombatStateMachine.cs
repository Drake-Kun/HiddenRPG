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

    // A list of the enemy units
    public List<GameObject> enemyUnits;

    // A list of all present and alive combat units.
    public List<GameObject> combatUnits;

    // This is the spellbook of our current activeUnit
    public List<string> currentSpellBook;

    public int activePartyMemberInt;
    // Do we need this? We could probably remove it. Active party member, though.
    public GameObject activePartyMember;

    // Our active unit. This changes as CALCULATEDAMAGE progresses from one unit to another.
    public GameObject activeUnit;

    // Our active unit's target unit. This changes as CALCULATEDAMAGE progresses from one unit to another.
    public GameObject targetUnit;

    

    // This is the list that has the order of units that will take action based on speed: Fastest goes first, slowest goes last. Updates after every DoDamage();
    public List<GameObject> orderOfCombat;

    // This is the active player's name, letting the player know who's turn it is.
    public GameObject displayName;

    // This is the text that will display the progressive information of the battle, such as damage done, status effects inflicted, etc.
    public GameObject displayText;

    public int expGiven;
    public bool expGivenBool;

    // 0. Initialize the order of combat, this will also do the damage for the first unit in (orderOfCombat), then skip to whatever stageOfDamageCalculation that is appropriate
    // 1. Unit does damage - If the unit is under the effects of paralysis, they must roll to see if they will take action - If the unit is under the effects of burn, they will take damage based on the caster's magDamage
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
        // activePartyMember = partyUnits[activePartyMemberInt];

        switch (currentState)
        {


            case (BattleStates.START):

                activePartyMemberInt = 0;
                currentState = BattleStates.PLAYERCHOICE;

                break;


            case (BattleStates.PLAYERCHOICE):

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    activePartyMemberInt--;
                    activePartyMember = partyUnits[activePartyMemberInt];
                    activePartyMember.GetComponent<CalculateDamage>().attackName = null;
                    activePartyMember.GetComponent<CalculateDamage>().targetUnit = null;

                }

                if (activePartyMember.GetComponent<CalculateDamage>().attackName != null && activePartyMember.GetComponent<CalculateDamage>().targetUnit != null)
                {
                    activePartyMemberInt++;

                    // If we still have party members who need to make a choice, let them.
                    if (activePartyMemberInt < partyUnits.Count)
                    {
                        activePartyMember = partyUnits[activePartyMemberInt];
                    }

                    // If we don't have any more party members who need to make a choice, go to damage calculation
                    else
                    {
                        stageOfDamageCalculation = 0;
                        currentState = BattleStates.CALCULATEDAMAGE;
                    }
                }
                break;


            case (BattleStates.ENEMYCHOICE):

                for (int i1 = 0; i1 < enemyUnits.Count; i1++)
                {
                    List<int> healthPercentages = new List<int>();
                    for (int i2 = 0; i2 < partyUnits.Count; i2++)
                    {
                        healthPercentages.Add(Mathf.RoundToInt((partyUnits[i2].GetComponent<PlayerInformation>().representative.hp / GetComponent<PlayerInformation>().representative.maxhp * 100)));
                    }
                    healthPercentages.Sort();

                    // This float is equal to the lowest health percentage in (healthPercentages), this will be used to set the order of targetPriority, making the party unit with the lowest health percentage index(0).
                    int hpSortingFloat = healthPercentages[0];

                    List<GameObject> hpTargetPriority = new List<GameObject>();
                    for (int i3 = hpSortingFloat; i3 > 0; i3++)
                    {
                        for (int i4 = 0; i4 < partyUnits.Count; i4++)
                        {
                            if (partyUnits[i4].GetComponent<PlayerInformation>().representative.hp / partyUnits[i4].GetComponent<PlayerInformation>().representative.maxhp * 100 == hpSortingFloat)
                            {
                                hpTargetPriority.Add(partyUnits[i4]);
                            }
                        }
                    }

                    int attackPriority = Random.Range(1,101);
                    if (hpSortingFloat < 60)
                    {
                        if (attackPriority <= 81)
                        {
                            enemyUnits[i1].GetComponent<CalculateDamage>().targetUnit = hpTargetPriority[0];
                        }

                        else
                        {
                            attackPriority = Random.Range(1, 5);
                            enemyUnits[i1].GetComponent<CalculateDamage>().targetUnit = hpTargetPriority[attackPriority];
                        }
                    }

                    else
                    {
                        attackPriority = Random.Range(1, 5);
                        enemyUnits[i1].GetComponent<CalculateDamage>().targetUnit = hpTargetPriority[attackPriority];
                    }
                }
                break;


            case (BattleStates.CALCULATEDAMAGE):

                // After the player has decided what they are going to do, and the enemy has as well, we set the stageOfDamageCalculation = 0,
                // This will allow us to InitiateOrderOfCombat(), adding all units who are alive to the combatUnits list.
                if (stageOfDamageCalculation == 0)
                {
                    InitiateOrderOfCombat();

                    stageOfDamageCalculation = 1;
                    DamageCalculationProcess();

                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    DamageCalculationProcess();
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

    // This function adds the party units and enemy units to a single list of combat units.
    public void InitiateOrderOfCombat()
    {
        // Add our party units to the total combatUnits list
        for (int i1 = 0; i1 < partyUnits.Count; i1++)
        {
            if (partyUnits[i1].GetComponent<PlayerInformation>().representative.hp != 0)
            {
                combatUnits.Add(partyUnits[i1]);
            }
        }

        // Add the enemy units to the total combatUnits list
        for (int i2 = 0; i2 < enemyUnits.Count; i2++)
        {
            if (enemyUnits[i2].GetComponent<EnemyInformation>().hpCurrent != 0)
            {
                combatUnits.Add(enemyUnits[i2]);
            }
        }
    }

    // This will make the order of combat
    public void MakeOrderOfCombat()
    {
        List<int> speedValues = new List<int>();

        for (int i = 0; i < combatUnits.Count; i++)
        {
            if (combatUnits[i].GetComponent<EnemyInformation>() == true)
            {
                speedValues.Add(combatUnits[i].GetComponent<EnemyInformation>().spd);
            }

            else if (combatUnits[i].GetComponent<PlayerInformation>() == true)
            {
                speedValues.Add(combatUnits[i].GetComponent<PlayerInformation>().representative.Cspeed);
            }
        }

        speedValues.Sort();
        speedValues.Reverse();

        for (int i2 = speedValues[0]; i2 > 0; i2--)
        {
            for (int i3 = 0; i3 < combatUnits.Count; i3++)
            {
                if (combatUnits[i3].GetComponent<EnemyInformation>() == true)
                {
                    if (combatUnits[i3].GetComponent<EnemyInformation>().spd == i2)
                    {
                        orderOfCombat.Add(combatUnits[i3]);
                    }
                }

                else if (combatUnits[i3].GetComponent<PlayerInformation>() == true)
                {
                    if (combatUnits[i3].GetComponent<PlayerInformation>().representative.Cspeed == i2)
                    {
                        orderOfCombat.Add(combatUnits[i3]);
                    }
                }
            }
        }

        GetComponent<TurnBasedCombatStateMachine>().orderOfCombat = orderOfCombat;

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
            displayText.GetComponent<Text>().text = "You don't have the strength to do that!";
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
            displayText.GetComponent<Text>().text = "You don't have the strength to do that!";
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
            displayText.GetComponent<Text>().text = "You don't have the strength to do that!";
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
            displayText.GetComponent<Text>().text = "You don't have the strength to do that!";
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
            displayText.GetComponent<Text>().text = "You don't have the strength to do that!";
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
            displayText.GetComponent<Text>().text = "You don't have the strength to do that!";
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

    void DamageCalculationProcess()
    {

        switch (stageOfDamageCalculation)
        {
            // 1. Unit does damage
            case 1:

                orderOfCombat[0].GetComponent<CalculateDamage>().DoDamage();
                displayText.GetComponent<Text>().text = targetUnit.GetComponent<EnemyInformation>().Name + " takes " + displayDamage + " damage!";
                if (activeUnit.GetComponent<PlayerInformation>() == true)
                {
                    if (activeUnit.GetComponent<CalculateDamage>().targetUnit.GetComponent<EnemyInformation>().hpCurrent <= 0)
                    {
                        stageOfDamageCalculation = 2;
                    }
                }

                else if (activeUnit.GetComponent<EnemyInformation>() == true)
                {

                }

                else if (statusAilment != null)
                {
                    stageOfDamageCalculation = 3;
                }

                else
                {
                    stageOfDamageCalculation = 4;
                }
                break;

            // 2. Unit fells the enemy (not always), check here to see if all of the units in (enemyUnits) or (playerUnits) are dead, send the player to WIN or LOSE as deemed appropriate.
            case 2:

                int unitsDead = 0;
                if (targetUnit.GetComponent<EnemyInformation>() == true)
                {
                    displayText.GetComponent<Text>().text = "The " + targetUnit.GetComponent<EnemyInformation>().Name + " is felled by " + activeUnit + "!";
                    for (int i = 0; i < enemyUnits.Count; i++)
                    {
                        if (enemyUnits[i].GetComponent<EnemyInformation>().hpCurrent <= 0)
                        {
                            unitsDead++;
                        }

                        if (unitsDead == enemyUnits.Count)
                        {
                            currentState = BattleStates.WIN;
                        }
                    }
                }

                else if (targetUnit.GetComponent<PlayerInformation>() == true)
                {
                    displayText.GetComponent<Text>().text = targetUnit.GetComponent<PlayerInformation>().representative.Name + "has been downed by " + activeUnit + "!";
                    for (int i = 0; i < partyUnits.Count; i++)
                    {
                        if (partyUnits[i].GetComponent<PlayerInformation>().representative.hp <= 0)
                        {
                            unitsDead++;
                        }

                        if (unitsDead == partyUnits.Count)
                        {
                            currentState = BattleStates.LOSE;
                        }
                    }

                    unitsDead = 0;
                    stageOfDamageCalculation = 4;
                }

                break;

            // 3. Unit inflicts a status ailment (not always)
            case 3:

                if (activeUnit.GetComponent<PlayerInformation>() == true)
                {
                    displayText.GetComponent<Text>().text = targetUnit.GetComponent<EnemyInformation>().Name + " is now " + statusAilment;
                }

                else if (activeUnit.GetComponent<EnemyInformation>() == true)
                {
                    displayText.GetComponent<Text>().text = targetUnit.GetComponent<PlayerInformation>().representative.Name + " is now " + statusAilment;
                }
                stageOfDamageCalculation = 4;
                break;


            // 4. Remove the current unit from the orderOfCombat list, MakeOrderOfCombat(), stageOfDamageCalculation = 1 again.
            case 4:

                orderOfCombat.Remove(orderOfCombat[0]);
                if (orderOfCombat.Count != 0)
                {
                    MakeOrderOfCombat();
                    stageOfDamageCalculation = 1;
                }

                else
                {
                    stageOfDamageCalculation = 5;
                }

                break;

            // 5. If (combatUnits.Count) is 0 then we have no more turns to calculate, stageOfCombatCalculation = 5, remove all units from combatUnits. GO TO START
            case 5:

                combatUnits.Clear();
                currentState = BattleStates.START;

                break;
        }
    }
}