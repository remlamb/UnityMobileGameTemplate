using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DD_ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private float spawnRate;
    [SerializeField] private float spawnRange;

    

    // Start is called before the first frame update
    void Start()
    {
        StartSpawning();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()
    {
        float randomX = Random.Range(-spawnRange, spawnRange);
        Vector2 spawnPos = new Vector2(randomX, transform.position.y);

        Instantiate(obstacle, spawnPos, Quaternion.identity);
    }

    void StartSpawning()
    {
        InvokeRepeating("Spawn", 1.2f, spawnRate);
    }

    public void DD_StopSpawning()
    {
        CancelInvoke("Spawn");
    }
}
