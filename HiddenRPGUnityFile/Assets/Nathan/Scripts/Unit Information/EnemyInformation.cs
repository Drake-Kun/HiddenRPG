using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInformation : MonoBehaviour {

    public string Name;
    public int hpMax;
    public int hpCurrent;
    public int spMax;
    public int spCurrent;
    public int str;
    public int intel;
    public int spd;
    public int def;
    public int magicdef;

    public string elementWeakness;
    public string elementResistence;

    public int expGiven;

    public bool isBurned;
    public bool isFrozen;
    public bool isParalyzed;

    public bool isDead;
}
