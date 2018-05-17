using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpellButtons : MonoBehaviour {
    public GameObject dictionary;

    void Awake()
    {
        dictionary = GameObject.FindGameObjectWithTag("Info");
    }
    public void OnClick()
    {
        dictionary.GetComponent<SpellFunctions>().converter(gameObject.GetComponentInChildren<Text>().text);
    }
}
