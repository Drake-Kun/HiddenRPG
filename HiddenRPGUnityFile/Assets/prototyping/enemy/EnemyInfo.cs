using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour {
    public enemies enemy;
    public string Name;
    public int hp;
    public int expgiven;
    public Sprite sprite;
    // Use this for initialization
    void Start () {
        Name = enemy.Name;
        hp = enemy.hp;
        gameObject.GetComponent<SpriteRenderer>().sprite = enemy.sprite;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
