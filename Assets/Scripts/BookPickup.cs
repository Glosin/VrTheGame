using System.Collections;
using UnityEngine;

public class BookPickup : MonoBehaviour
{
    public GameObject zombie;
    public GameObject spawnPoint;
    public float spawnCount = 1;
    
    public void SpawnZombie()
    {
        if (spawnCount > 0)
        {
            spawnCount -= 1;
            StartCoroutine(SpawnWithDelay());
        }
    }

    private IEnumerator SpawnWithDelay()
    {
        float delay = Random.Range(2f, 5f);
        yield return new WaitForSeconds(delay);
        
        Instantiate(zombie, spawnPoint.transform.position, Quaternion.identity);
    }
}
