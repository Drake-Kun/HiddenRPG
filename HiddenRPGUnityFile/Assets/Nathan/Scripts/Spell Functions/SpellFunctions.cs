using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellFunctions : MonoBehaviour {

    public GameObject activeUnit;
    public GameObject targetUnit;

    // public string actionElementType;

    public void converter(string name)
    {
        switch(name){
            case "Attack":
                Attack(activeUnit.GetComponent<PlayerInformation>().representative.str, targetUnit.GetComponent<EnemyInformation>().def);
                break;

            case "Fire":
                Fire(activeUnit.GetComponent<PlayerInformation>().representative.intel, targetUnit.GetComponent<EnemyInformation>().magicdef);
                break;

            case "Flame":
                Flame(activeUnit.GetComponent<PlayerInformation>().representative.intel, targetUnit.GetComponent<EnemyInformation>().magicdef);
                break;

            case "Cinder":
                Cinder(activeUnit.GetComponent<PlayerInformation>().representative.intel, targetUnit.GetComponent<EnemyInformation>().magicdef);
                break;

            case "Ice":
                Ice(activeUnit.GetComponent<PlayerInformation>().representative.intel, targetUnit.GetComponent<EnemyInformation>().magicdef);
                break;

            case "Chill":
                Chill(activeUnit.GetComponent<PlayerInformation>().representative.intel, targetUnit.GetComponent<EnemyInformation>().magicdef);
                break;

            case "Frost":
                Frost(activeUnit.GetComponent<PlayerInformation>().representative.intel, targetUnit.GetComponent<EnemyInformation>().magicdef);
                break;

            case "Thunder":
                Thunder(activeUnit.GetComponent<PlayerInformation>().representative.intel, targetUnit.GetComponent<EnemyInformation>().magicdef);
                break;

            case "Thunderbolt":
                Thunderbolt(activeUnit.GetComponent<PlayerInformation>().representative.intel, targetUnit.GetComponent<EnemyInformation>().magicdef);
                break;

            case "Lightning":
                Lightning(activeUnit.GetComponent<PlayerInformation>().representative.intel, targetUnit.GetComponent<EnemyInformation>().magicdef);
                break;

            case "Wind":
                Wind(activeUnit.GetComponent<PlayerInformation>().representative.intel, targetUnit.GetComponent<EnemyInformation>().magicdef);
                break;

            case "Gust":
                Gust(activeUnit.GetComponent<PlayerInformation>().representative.intel, targetUnit.GetComponent<EnemyInformation>().magicdef);
                break;

            case "Whirlwind":
                Whirlwind(activeUnit.GetComponent<PlayerInformation>().representative.intel, targetUnit.GetComponent<EnemyInformation>().magicdef);
                break;

            case "Shine":
                Shine(activeUnit.GetComponent<PlayerInformation>().representative.intel, targetUnit.GetComponent<EnemyInformation>().magicdef);
                break;

            case "Radiate":
                Radiate(activeUnit.GetComponent<PlayerInformation>().representative.intel, targetUnit.GetComponent<EnemyInformation>().magicdef);
                break;

            case "Purify":
                Purify(activeUnit.GetComponent<PlayerInformation>().representative.intel, targetUnit.GetComponent<EnemyInformation>().magicdef);
                break;

            case "Shade":
                Shade(activeUnit.GetComponent<PlayerInformation>().representative.intel, targetUnit.GetComponent<EnemyInformation>().magicdef);
                break;

            case "Darken":
                Darken(activeUnit.GetComponent<PlayerInformation>().representative.intel, targetUnit.GetComponent<EnemyInformation>().magicdef);
                break;

            case "Taint":
                Taint(activeUnit.GetComponent<PlayerInformation>().representative.intel, targetUnit.GetComponent<EnemyInformation>().magicdef);
                break;
        }       
    }

    public void Attack(int activeStr, int targetDef)
    {
        int damage = Mathf.RoundToInt(activeStr * 1.5f - targetDef);

        // Apply damage
        targetUnit.GetComponent<EnemyInformation>().hpCurrent -= damage;
        GameObject.Find("combat info").GetComponent<TurnBasedCombatStateMachine>().displayDamage = damage;
        if (targetUnit.GetComponent<EnemyInformation>().hpCurrent < 0)
        {
            targetUnit.GetComponent<EnemyInformation>().isDead = true;
        }
    }


    // Generic fire spells
    public void Fire(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel + 40) - targetMagDef);
        // actionElementType = "Fire";


        // If the enemy is weak to fire, multiply the damage int to do extra damage
        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness.Contains("Fire"))
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        // If the enemy is resistant to fire, multiply the damage into to do less damage
        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence.Contains("Fire"))
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }

        // Apply damage
        targetUnit.GetComponent<EnemyInformation>().hpCurrent -= damage;
        if (targetUnit.GetComponent<EnemyInformation>().hpCurrent < 0)
        {
            targetUnit.GetComponent<EnemyInformation>().isDead = true;
        }
    }

    public void Flame(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel + 85) - targetMagDef);
        // actionElementType = "Fire";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness.Contains("Fire"))
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementWeakness.Contains("Fire"))
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }

        // Apply damage
        targetUnit.GetComponent<EnemyInformation>().hpCurrent -= damage;
        if (targetUnit.GetComponent<EnemyInformation>().hpCurrent < 0)
        {
            targetUnit.GetComponent<EnemyInformation>().isDead = true;
        }
    }

    public void Cinder(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel + 115) - targetMagDef);
        // actionElementType = "Fire";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness.Contains("Fire"))
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence.Contains("Fire"))
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }

        // 10% chance to burn the enemy
        int inflictStatusAilment = Random.Range(1, 101);
        if (inflictStatusAilment > 90)
        {
            GetComponent<TurnBasedCombatStateMachine>().targetUnit.GetComponent<EnemyInformation>().isBurned = true;
            GetComponent<TurnBasedCombatStateMachine>().statusAilment = "burned";
        }

        // Apply damage
        targetUnit.GetComponent<EnemyInformation>().hpCurrent -= damage;
        if (targetUnit.GetComponent<EnemyInformation>().hpCurrent < 0)
        {
            targetUnit.GetComponent<EnemyInformation>().isDead = true;
        }
    }


    // Generic ice spells
    public void Ice(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel + 40) - targetMagDef);
        // actionElementType = "Ice";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness.Contains("Ice"))
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence.Contains("Ice"))
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }

        // Apply damage
        targetUnit.GetComponent<EnemyInformation>().hpCurrent -= damage;
        if (targetUnit.GetComponent<EnemyInformation>().hpCurrent < 0)
        {
            targetUnit.GetComponent<EnemyInformation>().isDead = true;
        }
    }

    public void Chill(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel + 85) - targetMagDef);
        // actionElementType = "Ice";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness.Contains("Ice"))
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence.Contains("Ice"))
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }

        // Apply damage
        targetUnit.GetComponent<EnemyInformation>().hpCurrent -= damage;
        if (targetUnit.GetComponent<EnemyInformation>().hpCurrent < 0)
        {
            targetUnit.GetComponent<EnemyInformation>().isDead = true;
        }
    }

    public void Frost(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel + 115) - targetMagDef);
        // actionElementType = "Ice";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness.Contains("Ice"))
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence.Contains("Ice"))
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }

        // 10% chance to freeze the enemy
        int inflictStatusAilment = Random.Range(1, 101);
        if (inflictStatusAilment > 90)
        {
            GetComponent<TurnBasedCombatStateMachine>().targetUnit.GetComponent<EnemyInformation>().isFrozen = true;
            GetComponent<TurnBasedCombatStateMachine>().statusAilment = "frozen";
        }

        // Apply damage
        targetUnit.GetComponent<EnemyInformation>().hpCurrent -= damage;
        if (targetUnit.GetComponent<EnemyInformation>().hpCurrent < 0)
        {
            targetUnit.GetComponent<EnemyInformation>().isDead = true;
        }
    }


    // Generic thunder spells
    public void Thunder(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel + 40) - targetMagDef);
        // actionElementType = "Thunder";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness.Contains("Thunder"))
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence.Contains("Thunder"))
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }

        // Apply damage
        targetUnit.GetComponent<EnemyInformation>().hpCurrent -= damage;
        if (targetUnit.GetComponent<EnemyInformation>().hpCurrent < 0)
        {
            targetUnit.GetComponent<EnemyInformation>().isDead = true;
        }
    }

    public void Thunderbolt(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel + 85) - targetMagDef);
        // actionElementType = "Thunder";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness.Contains("Thunder"))
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence.Contains("Thunder"))
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }

        // Apply damage
        targetUnit.GetComponent<EnemyInformation>().hpCurrent -= damage;
        if (targetUnit.GetComponent<EnemyInformation>().hpCurrent < 0)
        {
            targetUnit.GetComponent<EnemyInformation>().isDead = true;
        }
    }

    public void Lightning(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel + 115) - targetMagDef);
        // actionElementType = "Thunder";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness.Contains("Thunder"))
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence.Contains("Thunder"))
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }

        // 10% chance to paralyze the enemy
        int inflictStatusAilment = Random.Range(1, 101);
        if (inflictStatusAilment > 90)
        {
            GetComponent<TurnBasedCombatStateMachine>().targetUnit.GetComponent<EnemyInformation>().isParalyzed = true;
            GetComponent<TurnBasedCombatStateMachine>().statusAilment = "paralyzed";
        }

        // Apply damage
        targetUnit.GetComponent<EnemyInformation>().hpCurrent -= damage;
        if (targetUnit.GetComponent<EnemyInformation>().hpCurrent < 0)
        {
            targetUnit.GetComponent<EnemyInformation>().isDead = true;
        }
    }


    // Generic wind spells
    public void Wind(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel + 40) - targetMagDef);
        // actionElementType = "Wind";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness.Contains("Wind"))
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence.Contains("Wind"))
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }

        // Apply damage
        targetUnit.GetComponent<EnemyInformation>().hpCurrent -= damage;
        if (targetUnit.GetComponent<EnemyInformation>().hpCurrent < 0)
        {
            targetUnit.GetComponent<EnemyInformation>().isDead = true;
        }
    }

    public void Gust(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel + 85) - targetMagDef);
        // actionElementType = "Wind";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness.Contains("Wind"))
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence.Contains("Wind"))
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }

        // Apply damage
        targetUnit.GetComponent<EnemyInformation>().hpCurrent -= damage;
        if (targetUnit.GetComponent<EnemyInformation>().hpCurrent < 0)
        {
            targetUnit.GetComponent<EnemyInformation>().isDead = true;
        }
    }

    public void Whirlwind(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel + 115) - targetMagDef);
        // actionElementType = "Wind";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness.Contains("Wind"))
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence.Contains("Wind"))
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }


    }


    // Light magic tree
    public void Shine(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel + 60) - targetMagDef);
        // actionElementType = "Light";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness.Contains("Light"))
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence.Contains("Light"))
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }

        // Apply damage
        targetUnit.GetComponent<EnemyInformation>().hpCurrent -= damage;
        if (targetUnit.GetComponent<EnemyInformation>().hpCurrent < 0)
        {
            targetUnit.GetComponent<EnemyInformation>().isDead = true;
        }

        activeUnit.GetComponent<PlayerInformation>().representative.hp -= Mathf.RoundToInt(activeUnit.GetComponent<PlayerInformation>().representative.maxhp / 0.1f);
    }

    public void Radiate(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel + 130) - targetMagDef);
        // actionElementType = "Light";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness.Contains("Light"))
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence.Contains("Light"))
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }

        // Apply damage
        targetUnit.GetComponent<EnemyInformation>().hpCurrent -= damage;
        if (targetUnit.GetComponent<EnemyInformation>().hpCurrent < 0)
        {
            targetUnit.GetComponent<EnemyInformation>().isDead = true;
        }

        activeUnit.GetComponent<PlayerInformation>().representative.hp -= Mathf.RoundToInt(activeUnit.GetComponent<PlayerInformation>().representative.maxhp / 0.2f);
        activeUnit.GetComponent<PlayerInformation>().representative.hp += Mathf.RoundToInt(damage / 0.3f);
    }

    public void Purify(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel + 180) - targetMagDef);
        // actionElementType = "Light";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness.Contains("Light"))
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence.Contains("Light"))
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }

        // Apply damage
        targetUnit.GetComponent<EnemyInformation>().hpCurrent -= damage;
        if (targetUnit.GetComponent<EnemyInformation>().hpCurrent < 0)
        {
            targetUnit.GetComponent<EnemyInformation>().isDead = true;
        }

        activeUnit.GetComponent<PlayerInformation>().representative.hp -= Mathf.RoundToInt(activeUnit.GetComponent<PlayerInformation>().representative.maxhp / 0.3f);
        activeUnit.GetComponent<PlayerInformation>().representative.hp += Mathf.RoundToInt(damage / 0.5f);
    }


    // Dark magic tree
    public void Shade(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel + 50) - targetMagDef);
        // actionElementType = "Shade";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness.Contains("Shade"))
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence.Contains("Shade"))
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }

        // Apply damage
        targetUnit.GetComponent<EnemyInformation>().hpCurrent -= damage;
        if (targetUnit.GetComponent<EnemyInformation>().hpCurrent < 0)
        {
            targetUnit.GetComponent<EnemyInformation>().isDead = true;
        }

        activeUnit.GetComponent<PlayerInformation>().representative.hp -= Mathf.RoundToInt(activeUnit.GetComponent<PlayerInformation>().representative.maxhp / 0.1f);
    }

    public void Darken(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel + 100) - Mathf.RoundToInt(targetMagDef / 0.7f));
        // actionElementType = "Shade";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness.Contains("Shade"))
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence.Contains("Shade"))
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }

        // Apply damage
        targetUnit.GetComponent<EnemyInformation>().hpCurrent -= damage;
        if (targetUnit.GetComponent<EnemyInformation>().hpCurrent < 0)
        {
            targetUnit.GetComponent<EnemyInformation>().isDead = true;
        }

        activeUnit.GetComponent<PlayerInformation>().representative.hp -= Mathf.RoundToInt(activeUnit.GetComponent<PlayerInformation>().representative.maxhp / 0.2f);
    }

    public void Taint(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel + 150) - Mathf.RoundToInt(targetMagDef / 0.5f));
        // actionElementType = "Shade";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness.Contains("Shade"))
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence.Contains("Shade"))
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }

        // Apply damage
        targetUnit.GetComponent<EnemyInformation>().hpCurrent -= damage;
        if (targetUnit.GetComponent<EnemyInformation>().hpCurrent < 0)
        {
            targetUnit.GetComponent<EnemyInformation>().isDead = true;
        }

        activeUnit.GetComponent<PlayerInformation>().representative.hp -= Mathf.RoundToInt(activeUnit.GetComponent<PlayerInformation>().representative.maxhp / 0.3f);
    }
}
