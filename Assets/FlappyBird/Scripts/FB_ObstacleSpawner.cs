using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FB_ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private float maxYpos;
    private Vector3 spawnPos;

    private bool spawnObstacles;
    [SerializeField] private float spawnSpeed;

    public static FB_ObstacleSpawner instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        spawnPos = transform.position;
        FB_StartSpawning();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FB_StartSpawning()
    {
        spawnObstacles = true;
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        yield return new WaitForSeconds(0.5f);
        while (spawnObstacles)
        {
            int rand = Random.Range(0, obstacles.Length);
            spawnPos.y = Random.Range(-maxYpos, maxYpos);

            Instantiate(obstacles[rand], spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(spawnSpeed);
        }
    }
}
