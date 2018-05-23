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
        }       
    }

    public void Attack(int activeStr, int targetDef)
    {
        int damage = Mathf.RoundToInt(activeStr * 1.5f - targetDef);
    }


    // Generic fire spells
    public void Fire(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel * 1.5f + 40) - targetMagDef);
        // actionElementType = "Fire";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness == "Fire")
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence == "Fire")
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }
    }

    public void Flame(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel * 1.5f + 85) - targetMagDef);
        // actionElementType = "Fire";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness == "Fire")
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence == "Fire")
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }

    }

    public void Cinder(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel * 1.5f + 115) - targetMagDef);
        // actionElementType = "Fire";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness == "Fire")
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence == "Fire")
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }

        int inflictStatusAilment = Random.Range(1, 101);
        if (inflictStatusAilment > 90)
        {
            GetComponent<TurnBasedCombatStateMachine>().targetUnit.GetComponent<EnemyInformation>().isBurned = true;
        }
    }


    // Generic ice spells
    public void Ice(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel * 1.5f + 40) - targetMagDef);
        // actionElementType = "Ice";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness == "Ice")
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence == "Ice")
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }
    }

    public void Chill(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel * 1.5f + 85) - targetMagDef);
        // actionElementType = "Ice";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness == "Ice")
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence == "Ice")
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }
    }

    public void Frost(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel * 1.5f + 115) - targetMagDef);
        // actionElementType = "Ice";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness == "Ice")
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence == "Ice")
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }

        int inflictStatusAilment = Random.Range(1, 101);
        if (inflictStatusAilment > 90)
        {
            GetComponent<TurnBasedCombatStateMachine>().targetUnit.GetComponent<EnemyInformation>().isFrozen = true;
        }
    }


    // Generic thunder spells
    public void Thunder(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel * 1.5f + 40) - targetMagDef);
        // actionElementType = "Thunder";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness == "Thunder")
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence == "Thunder")
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }
    }

    public void Thunderbolt(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel * 1.5f + 85) - targetMagDef);
        // actionElementType = "Thunder";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness == "Thunder")
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence == "Thunder")
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }
    }

    public void Lightning(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel * 1.5f + 115) - targetMagDef);
        // actionElementType = "Thunder";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness == "Thunder")
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence == "Thunder")
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }

        int inflictStatusAilment = Random.Range(1, 101);
        if (inflictStatusAilment > 90)
        {
            GetComponent<TurnBasedCombatStateMachine>().targetUnit.GetComponent<EnemyInformation>().isParalyzed = true;
        }
    }


    // Generic wind spells
    public void Wind(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel * 1.5f + 40) - targetMagDef);
        // actionElementType = "Wind";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness == "Wind")
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence == "Wind")
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }
    }

    public void Gust(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel * 1.5f + 85) - targetMagDef);
        // actionElementType = "Wind";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness == "Wind")
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence == "Wind")
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }
    }

    public void Whirlwind(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel * 1.5f + 115) - targetMagDef);
        // actionElementType = "Wind";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness == "Wind")
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence == "Wind")
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }
    }


    // Light magic tree
    public void Shine(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel * 1.5f + 60) - targetMagDef);
        // actionElementType = "Light";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness == "Light")
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence == "Light")
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }

        activeUnit.GetComponent<PlayerInformation>().representative.hp -= Mathf.RoundToInt(activeUnit.GetComponent<PlayerInformation>().representative.maxhp / 0.1f);
    }

    public void Radiate(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel * 1.5f + 130) - targetMagDef);
        // actionElementType = "Light";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness == "Light")
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence == "Light")
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }

        activeUnit.GetComponent<PlayerInformation>().representative.hp -= Mathf.RoundToInt(activeUnit.GetComponent<PlayerInformation>().representative.maxhp / 0.2f);
        activeUnit.GetComponent<PlayerInformation>().representative.hp += Mathf.RoundToInt(damage / 0.3f);
    }

    public void Purify(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel * 1.5f + 180) - targetMagDef);
        // actionElementType = "Light";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness == "Light")
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence == "Light")
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }

        activeUnit.GetComponent<PlayerInformation>().representative.hp -= Mathf.RoundToInt(activeUnit.GetComponent<PlayerInformation>().representative.maxhp / 0.3f);
        activeUnit.GetComponent<PlayerInformation>().representative.hp += Mathf.RoundToInt(damage / 0.5f);
    }


    // Dark magic tree
    public void Shade(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel * 1.5f + 50) - targetMagDef);
        // actionElementType = "Light";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness == "Light")
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence == "Light")
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }

        activeUnit.GetComponent<PlayerInformation>().representative.hp -= Mathf.RoundToInt(activeUnit.GetComponent<PlayerInformation>().representative.maxhp / 0.1f);
    }

    public void Darken(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel * 1.5f + 100) - Mathf.RoundToInt(targetMagDef / 0.7f));
        // actionElementType = "Light";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness == "Light")
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence == "Light")
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }

        activeUnit.GetComponent<PlayerInformation>().representative.hp -= Mathf.RoundToInt(activeUnit.GetComponent<PlayerInformation>().representative.maxhp / 0.2f);
    }

    public void Taint(int activeIntel, int targetMagDef)
    {
        int damage = Mathf.RoundToInt((activeIntel * 1.5f + 150) - Mathf.RoundToInt(targetMagDef / 0.5f));
        // actionElementType = "Light";

        if (targetUnit.GetComponent<EnemyInformation>().elementWeakness == "Light")
        {
            damage = Mathf.RoundToInt(damage * 1.50f);
        }

        else if (targetUnit.GetComponent<EnemyInformation>().elementResistence == "Light")
        {
            damage = Mathf.RoundToInt(damage * 0.5f);
        }

        activeUnit.GetComponent<PlayerInformation>().representative.hp -= Mathf.RoundToInt(activeUnit.GetComponent<PlayerInformation>().representative.maxhp / 0.3f);
    }
}
