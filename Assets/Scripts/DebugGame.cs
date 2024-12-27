using System.Collections.Generic;
using UnityEngine;
public class DebugGame : MonoBehaviour
{
    public ZombieSpawnPoint zombieSpawnPoint;
    public GameObject zombiePrefab;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Stop Spawn And Kill Remaining Zombies");
            zombieSpawnPoint.StopAllCoroutines();
            ZombieController[] zombies = FindObjectsByType<ZombieController>(FindObjectsSortMode.None);
            foreach (ZombieController zombie in zombies)
            {
                Destroy(zombie.gameObject);
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            Debug.Log("Zombie Spawning");
            zombieSpawnPoint.SpawnZombie();
        }
    }

    public void TestTest()
    {
        Debug.Log("Test Zombie Spawning");
    }
}
