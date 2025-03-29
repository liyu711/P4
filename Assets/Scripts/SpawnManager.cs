using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9;
    public int waveCount = 1;

    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {

        SpawnEnemyWave(waveCount);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log(enemyCount);
        if (enemyCount == 0)
        {
            waveCount++;
            SpawnEnemyWave(waveCount);
        }
    }
    private Vector3 getSpwanPos()
    {
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(spawnX, 0, spawnZ);
        return spawnPos;
    }
    void SpawnEnemyWave(int emenyCount)
    {
        for (int i = 0; i < emenyCount; i ++)
        {
            Instantiate(enemyPrefab, getSpwanPos(), enemyPrefab.transform.rotation);
        }

    }
}
