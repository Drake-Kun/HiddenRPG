using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class listofactivechar : MonoBehaviour {
    public combatidea[] list;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public combatidea ReturnChar (string name)
    {
        for (int i = 0; i < list.Length; i++)
        {
            if(list[i].name == name)
            {
                return list[i];
            }


        }
        return null;

    }
}
