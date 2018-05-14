using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInformation : MonoBehaviour {

    // areaID #1 = "A place"
    // areaID #2 = "A different place"
    // etc.

    public GameObject playerOverworldUnit;
    public Vector3 playerOverworldPosition;

    public Scene OverworldScene;

    public int areaID;
    
	void Start () {
        DontDestroyOnLoad(this.gameObject);
	}
	
	void Update () {
		
	}

    void BattleEncounter()
    {
        OverworldScene = SceneManager.GetActiveScene();
        playerOverworldPosition = playerOverworldUnit.transform.position;
        SceneManager.LoadScene("CombatScene");
    }

    void ReturnToOverworld()
    {
        SceneManager.SetActiveScene(OverworldScene);
        playerOverworldUnit.transform.position = playerOverworldPosition;
    }
}
