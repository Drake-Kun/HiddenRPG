using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "item", menuName = "items", order = 0)]
public class items : MonoBehaviour {
    public bool is_potion;
    public int healing;
    [Space]
    public bool is_equipment;
    public int str_increase;
    public int intel_increase;
    public int def_increase;
    public int speed_increase;
    public int mag_def_increase;
    [Space]
    public bool is_bomb;
    public int damage;
    [Space]
    public bool is_stat_booster;
    public int consume_str_increase;
    public int consume_intel_increase;
    public int consume_def_increase;
    public int consume_speed_increase;
    public int consume_mag_def_increase;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void onequip()
    {



    }

}
