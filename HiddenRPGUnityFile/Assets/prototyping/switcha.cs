using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switcha : MonoBehaviour {
    public GameObject button;
       public void Switch()
    {
        if (button.activeSelf)
            button.SetActive(false);
        else
            button.SetActive(true);
        
    }

}
