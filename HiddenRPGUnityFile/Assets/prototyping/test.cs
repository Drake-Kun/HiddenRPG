using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
    public combatidea ok;
    public combatidea aok;
    public combatidea bok;
    public combatidea cok;
    // Use this for initialization
    void Start () {
       
             
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(ok.exp);
		if (Input.GetKeyDown(KeyCode.K))
        {
            ok.exp += 900;
            ok.AfterBattle();
        }
	}
}
