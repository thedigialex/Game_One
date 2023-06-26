using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject playerObject;
    public Transform spawnPoint;
    public float spawnInterval = 2f;
    
    private float timer;

    private void Start()
    {
        timer = spawnInterval;
        
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            GenerateEnemy();
            timer = spawnInterval;
        }
    }

    private void GenerateEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        ChasePlayer enemyChase = enemy.GetComponent<ChasePlayer>();
        enemyChase.player = playerObject.transform;
    }
}
