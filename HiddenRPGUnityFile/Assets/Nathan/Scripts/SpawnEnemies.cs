using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

    void Start()
    {
        Area1Spawn();
    }

    public void Area1Spawn()
    {
        // What enemies can spawn here?
        // EnemyType1
        // EnemyType2

        // Lets us know that we're going to encounter either 2 or 3 enemies.
        int numberOfEnemies = Random.Range(2, 4);

        // Now we decide how many of each type of enemy to spawn
        int enemyType1Amount = Random.Range(0, numberOfEnemies + 1);
        Debug.Log(enemyType1Amount);
        Debug.Log(numberOfEnemies);
        numberOfEnemies -= enemyType1Amount;
        // What happens if number of enemies == 0? Random.Range will be (1, 1), so will there always be ONE EnemyType2?
        int enemyType2Amount = Random.Range(0, numberOfEnemies + 1);
        Debug.Log(enemyType2Amount);

        int unitNumber = 1;


        for (int i = enemyType1Amount; enemyType1Amount > 0; enemyType1Amount--)
        {
            // Instantiate an enemyType1, call it ("enemyUnit" + unitNumber)

            
        }

        for (int i = enemyType2Amount; enemyType2Amount > 0; enemyType2Amount--)
        {
            // Instantiate an enemyType2, call it ("enemyUnit" + unitNumber)

        }
    }

}
