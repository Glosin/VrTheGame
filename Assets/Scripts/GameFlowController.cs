using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameFlowController : MonoBehaviour
{
    public GameObject[] zombieSpawnPoint;
    public TMP_Text roundText;
    public int round, maxZombiesSpawned;
    public GameObject zombiePrefab;
    private bool _isWaitingForRound;

    public void Start()
    {
        roundText.text = "";
        _isWaitingForRound = true;
        StartCoroutine(RoundFlow(10f));
    }

    private IEnumerator RoundFlow(float time)
    {
        yield return new WaitForSeconds(time);
        roundText.text = $"Round: {round}";
        _isWaitingForRound = false;
        StartCoroutine(SpawnZombies());
    }

    private IEnumerator SpawnZombies()
    { 
        var zombieCount = round * 4;
        while (zombieCount > 0)
        {
            var randomIndex = Random.Range(0, zombieSpawnPoint.Length);
            if (FindObjectsByType<ZombieController>(sortMode: FindObjectsSortMode.None).Length < maxZombiesSpawned)
            {
                Instantiate(zombiePrefab, zombieSpawnPoint[randomIndex].transform.position, Quaternion.identity);
                zombieCount--;
                yield return new WaitForSeconds(1f);
            }
            else yield return new WaitForSeconds(5f);
        }
    }

    public void Update()
    {
        if (FindObjectsByType<ZombieController>(sortMode: FindObjectsSortMode.None).Length > 0) return;
        if (_isWaitingForRound) return;
        round++;
        _isWaitingForRound = true;
        zombiePrefab.GetComponent<ZombieController>().level++;
        StartCoroutine(RoundFlow(2f));
    }
}
