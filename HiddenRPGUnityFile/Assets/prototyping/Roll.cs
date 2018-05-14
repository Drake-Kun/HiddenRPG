using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour {

   public int roll (int D){
        return Random.Range(1, D);
    }
}
