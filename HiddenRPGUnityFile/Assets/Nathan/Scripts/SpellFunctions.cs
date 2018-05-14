using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellFunctions : MonoBehaviour {

    public void Fireball()
    {
        // Get playerTargetUnit
        // do damage - Mathf.Round(magicDamage * 1.1)

        int inflictStatusAilment = Random.Range (1,101);
        if (inflictStatusAilment > 60)
        {
            // Set (isBurned) on the enemy to true;
        }
    }

    public void Taunt()
    {
        List<GameObject> enemies = GameObject.Find("CombatMachine").GetComponent<TurnBasedCombatStateMachine>().enemyUnits;
        int inflictTaunt = Random.Range(0, enemies.Count + 1);
        
        
        for (int i = inflictTaunt; i >= enemies.Count; i --)
        {
            int enemyTauntedNumber = Random.Range(1, enemies.Count + 1);
            // GameObject enemyTaunted = enemies[enemyTauntedNumber];
            // enemyTaunted.GetComponent.<EnemyInformation>().isTaunted = true;
            
        // inflict taunt -= 1;
            // enemies.Remove[ (enemyTaunted int value) ]
            // EnemyUnit
        }
    }

    public void Cleave()
    {
        // Get playerTargetUnit
        // Do damage - Mathf.Round(physicalDamage * 1.5)
        // Reduce enemy defense by (physicalDamage * 0.25)
    }

    // More spells YAY
    // Poison, burn, stun, sleep, silence/seal, blind,
    // taunte, but this one might work differently
}
