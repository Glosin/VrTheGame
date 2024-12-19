using System.Collections;
using UnityEngine;

public class ZombieSpawnPoint : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject zombiePrefab;
    public int spawnCount = 30;
    
    public void SpawnZombie()
    {
        StartCoroutine(StartSpawnEnumerator());
    }
    
    public IEnumerator StartSpawnEnumerator()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            // Select a random spawn point from the array
            GameObject selectedSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            
            // Get the position of the selected spawn point
            Vector3 spawnPosition = selectedSpawnPoint.transform.position;

            // Instantiate the zombie prefab at the selected spawn point
            Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);

            // Wait for 0.5 seconds before spawning the next zombie
            yield return new WaitForSeconds(0.5f);
        }

    }
}
