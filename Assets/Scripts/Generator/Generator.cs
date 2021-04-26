using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
     
    public float SpawnTimerRocks = 10; // => диапазон
    public float SpawnTimerRats = 1; // => диапазон
    
    public GameObject[] obstacles;
    public Transform[] spawnPoints;

    public GameObject rat;
    
    void Start()
    {
        // карутины для даунов
        StartCoroutine(tickForRocks());
        StartCoroutine(tickForRats());
    }

    IEnumerator tickForRocks()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnTimerRocks);
            SpawnRocks();
        }
    }
    IEnumerator tickForRats()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnTimerRats);
            SpawnRats();
        }
    }

    private void SpawnRocks()
    {
        var randomInt = Random.Range(0, spawnPoints.Length);
        for (int i = 0; i < randomInt; i++) { Instantiate(obstacles[Random.Range(0, obstacles.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity); }
    }
    private void SpawnRats()
    {
        Instantiate(rat, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
    }
}
