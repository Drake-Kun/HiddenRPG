using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

	public GameObject slimePrefab;
	public GameObject smallSlimePrefab;
	public GameObject brigandPrefab;
	public GameObject ruffianPrefab;

    void Start()
    {
        Area1Spawn();
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
            if (spawnType > 70)
            {
				GameObject normalSlime;
				GameObject smallSlime;
				normalSlime = Instantiate(slimePrefab, GetComponentInParent<Transform>());
				smallSlime = Instantiate(smallSlimePrefab, GetComponentInParent<Transform>());
                //Instantiate a slime (EnemyUnit1) and a small slime (EnemyUnit2)
            }

            // 25% chance: OR all are Slimes
            if (spawnType <= 70 && spawnType > 60)
            {
				GameObject normalSlime1;
				GameObject normalSlime2;
				normalSlime1 = Instantiate(slimePrefab, GetComponentInParent<Transform>());
				normalSlime2 = Instantiate(slimePrefab, GetComponentInParent<Transform>());
                //Instantiate two Slimes (EnemyUnit1)(EnemyUnit2)
            }

            // 60% chance: OR all are Small Slimes
            if (spawnType <= 60)
            {
                //Instantiate two Small Slimes (EnemyUnit1)(EnemyUnit2)
            }
        }

        else if (numberOfEnemies == 3)
        {
            int spawnType = Random.Range(1, 101);

            // 25% chance: 1-2 Slimes-Small Slimes
            if (spawnType > 75)
            {
                //Instantiate one Slime (EnemyUnit1) and two Small Slimes (EnemyUnit2)(EnemyUnit3)
            }

            // 15% chance: 2-1 Slimes-Small Slimes
            if (spawnType <= 75 && spawnType > 60)
            {
                //Instantiate two Slimes (EnemyUnit1)(EnemyUnit2) and two Small Slimes (EnemyUnit3)
            }

            // 10% chance: 3 Slimes

            // 50% chance: 3 Small Slimes


        }
    }

}
