using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;

    public List<Transform> spawnPoints;
    public GameObject enemy;
    public GameObject ME;
    
    public float spawnInterval;
    public float spawnRange = 10f;
    
    public PlayerScript PS;

    private void Awake()
    {
        instance = this;
    }

    void SpawnEnemy(Transform spawnPoint)
    {
        Debug.Log("spawned");
        GameObject spawnedEnemy = Instantiate(enemy, spawnPoint.position, Quaternion.identity);

        ZombieScript zombie = spawnedEnemy.GetComponent<ZombieScript>();
        if (zombie != null)
        {
            zombie.SetTarget(ME, PS);
        }

    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {

            foreach (Transform point in spawnPoints)
            {
                float distanceToPlayer = Vector2.Distance(point.position, PS.transform.position);
                if (distanceToPlayer <= spawnRange)
                {
                    SpawnEnemy(point);
                }

            }
            yield return new WaitForSeconds(spawnInterval);

        }
    }

    public void Start()
    {
        StartCoroutine(SpawnLoop());
    }
    public void StopSpawning()
    {
        StopAllCoroutines();
    }
}
