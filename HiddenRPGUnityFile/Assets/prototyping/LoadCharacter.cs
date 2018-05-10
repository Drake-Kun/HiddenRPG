using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour {
   public combatidea refrence;
    void Awake()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = refrence.sprite;
    }

}
