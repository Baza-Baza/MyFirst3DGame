using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<GameObject> enemySpawns;
    [SerializeField] List<Transform> spawnPoints;
    private bool canSpawn = true;
    [SerializeField] bool retriggerable;



    private void OnTriggerEnter(Collider other)
    {
            if (other.CompareTag("Player"))
             {
            if (SaveScript.currentEnemiesInGame < SaveScript.maxEnemiesInGame)
            {
                if (SaveScript.enemiesOnScreen < SaveScript.maxEnemiesOnScreen)
                {

                    if (canSpawn == true)
                    {


                        canSpawn = false;
                        InstantiateEnemies(0);
                        InstantiateEnemies(1);
                        InstantiateEnemies(2);
                        if (retriggerable == true)
                        {
                            StartCoroutine(WaitToSpawn());
                        }
                    }
                }
            }
        }
    }
    IEnumerator WaitToSpawn()
    {
        yield return new WaitForSeconds(2f);
        canSpawn = true;
    }
    private void InstantiateEnemies(int enemiesPositionNumber)
    {
        Instantiate(enemySpawns[enemiesPositionNumber], spawnPoints[enemiesPositionNumber].position, spawnPoints[enemiesPositionNumber].rotation);
        SaveScript.enemiesOnScreen++;
        SaveScript.currentEnemiesInGame++;
    }
}
