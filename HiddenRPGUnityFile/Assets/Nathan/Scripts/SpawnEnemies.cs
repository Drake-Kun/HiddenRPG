using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

    public List<GameObject> enemies;

	public GameObject slimePrefab;
	public GameObject smallSlimePrefab;
	public GameObject brigandPrefab;
	public GameObject ruffianPrefab;

    int areaID;

    void Start()
    {
        // Gets the (areaID) variable from the (GameInformationObject) -> (GameInformation) script
        areaID = GameObject.Find("gameinfo").GetComponent<GameInformation>().areaID;

        // This is temporary
        areaID = 1;
        // Until we have a transition between the overworld and combat

        switch (areaID)
        {
            case 1:
                Area1Spawn();

                break;
        }
        
    }

    public void Area1Spawn()
    {
        // What enemies can spawn here?
        // Small Slime
        // Slime

        // Lets us know that we're going to encounter either 2 or 3 enemies.
        int numberOfEnemies = Random.Range(2, 4);

        // Now we decide how many of each type of enemy to spawn
        if (numberOfEnemies == 2)
        {
            int spawnType = Random.Range(1, 101);

            // 15% chance: Spawn a 1-1 ratio of Slimes to Small Slimes,
            if (spawnType > 85)
            {
				GameObject normalSlime;
				GameObject smallSlime;
				normalSlime = Instantiate(slimePrefab, GetComponentInParent<Transform>());
                enemies.Add(normalSlime);
				smallSlime = Instantiate(smallSlimePrefab, GetComponentInParent<Transform>());
                enemies.Add(smallSlime);
            }

            // 25% chance: OR all are Slimes
            if (spawnType <= 85 && spawnType > 60)
            {
				GameObject normalSlime1;
				GameObject normalSlime2;
				normalSlime1 = Instantiate(slimePrefab, GetComponentInParent<Transform>());
                enemies.Add(normalSlime1);
				normalSlime2 = Instantiate(slimePrefab, GetComponentInParent<Transform>());
                enemies.Add(normalSlime2);
            }

            // 60% chance: OR all are Small Slimes
            if (spawnType <= 60)
            {
                GameObject smallSlime1;
                GameObject smallSlime2;
                smallSlime1 = Instantiate(smallSlimePrefab, GetComponentInParent<Transform>());
                enemies.Add(smallSlime1);
                smallSlime2 = Instantiate(smallSlimePrefab, GetComponentInParent<Transform>());
                enemies.Add(smallSlime2);
            }
        }

        else if (numberOfEnemies == 3)
        {
            int spawnType = Random.Range(1, 101);

            // 25% chance: 1-2 Slimes-Small Slimes
            if (spawnType > 75)
            {
                GameObject normalSlime;
                GameObject smallSlime1;
                GameObject smallSlime2;
                normalSlime = Instantiate(slimePrefab, GetComponentInParent<Transform>());
                enemies.Add(normalSlime);
                smallSlime1 = Instantiate(smallSlimePrefab, GetComponentInParent<Transform>());
                enemies.Add(smallSlime1);
                smallSlime2 = Instantiate(smallSlimePrefab, GetComponentInParent<Transform>());
                enemies.Add(smallSlime2);
            }

            // 15% chance: 2-1 Slimes-Small Slimes
            if (spawnType <= 75 && spawnType > 60)
            {
                GameObject normalSlime1;
                GameObject normalSlime2;
                GameObject smallSlime;
                normalSlime1 = Instantiate(slimePrefab, GetComponentInParent<Transform>());
                enemies.Add(normalSlime1);
                normalSlime2 = Instantiate(slimePrefab, GetComponentInParent<Transform>());
                enemies.Add(normalSlime2);
                smallSlime = Instantiate(smallSlimePrefab, GetComponentInParent<Transform>());
                enemies.Add(smallSlime);
            }

            // 10% chance: 3 Slimes
            if (spawnType <= 60 && spawnType > 50)
            {
                GameObject normalSlime1;
                GameObject normalSlime2;
                GameObject normalSlime3;
                normalSlime1 = Instantiate(slimePrefab, GetComponentInParent<Transform>());
                enemies.Add(normalSlime1);
                normalSlime2 = Instantiate(slimePrefab, GetComponentInParent<Transform>());
                enemies.Add(normalSlime2);
                normalSlime3 = Instantiate(slimePrefab, GetComponentInParent<Transform>());
                enemies.Add(normalSlime3);
            }

            // 50% chance: 3 Small Slimes
            if (spawnType <= 50 && spawnType > 0)
            {
                GameObject smallSlime1;
                GameObject smallSlime2;
                GameObject smallSlime3;
                smallSlime1 = Instantiate(smallSlimePrefab, GetComponentInParent<Transform>());
                enemies.Add(smallSlime1);
                smallSlime2 = Instantiate(smallSlimePrefab, GetComponentInParent<Transform>());
                enemies.Add(smallSlime2);
                smallSlime3 = Instantiate(smallSlimePrefab, GetComponentInParent<Transform>());
                enemies.Add(smallSlime3);
            }


        }
    }

}
