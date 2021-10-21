using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<GameObject> enemySpawns;
    [SerializeField] List<Transform> spawnPoints;
    private bool canSpawn = true;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (canSpawn == true)
            {
                canSpawn = false;
                Instantiate(enemySpawns[0], spawnPoints[0].position, spawnPoints[0].rotation);
                Instantiate(enemySpawns[1], spawnPoints[1].position, spawnPoints[1].rotation);
                Instantiate(enemySpawns[2], spawnPoints[2].position, spawnPoints[2].rotation);
                StartCoroutine(WaitToSpawn());
            }
        }
    }
    IEnumerator WaitToSpawn()
    {
        yield return new WaitForSeconds(2f);
        canSpawn = true;
    }
}
