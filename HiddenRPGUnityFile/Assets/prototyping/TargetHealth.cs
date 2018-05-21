using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TargetHealth : MonoBehaviour
{
    public GameObject button;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (button.GetComponent<TargetButtons>().Enemy.GetComponent<EnemyInfo>().hp > 0)
        {


            gameObject.GetComponent<Text>().text = button.GetComponent<TargetButtons>().Enemy.GetComponent<EnemyInfo>().Name + " " + button.GetComponent<TargetButtons>().Enemy.GetComponent<EnemyInfo>().hp + "";
        }
    }
}
