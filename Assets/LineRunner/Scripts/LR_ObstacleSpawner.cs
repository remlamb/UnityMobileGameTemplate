using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LR_ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    private Vector3 spawnPos;
    [SerializeField] private float spawnRate;
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
        StartCoroutine(SpawmObsctacles());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawmObsctacles()
    {
        while (true)
        {
            Spawn();
            LR_GameManager.instance.LR_UpdateScore();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    void Spawn()
    {
        int randObstacle = Random.Range(0, obstacles.Length);
        spawnPos = transform.position;
        if (randObstacle < 3)
        {
            Instantiate(obstacles[randObstacle], spawnPos, transform.rotation);
        }
        else
        {
            spawnPos.y = -transform.position.y;
            Instantiate(obstacles[randObstacle], spawnPos, obstacles[randObstacle].transform.rotation);
        }

    }
}
