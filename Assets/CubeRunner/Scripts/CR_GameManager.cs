using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CR_GameManager : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private int score = 0;

    [SerializeField] private float spawningRateMin = 0.4f;
    [SerializeField] private float spawningRateMax = 2.2f;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CR_SpawnObstacles()
    {
        while (true)
        {
            float waitTime = Random.Range(spawningRateMin, spawningRateMax);
            yield return new WaitForSeconds(waitTime);

            Instantiate(obstacle, spawnPoint.position, Quaternion.identity);
        }
    }

    void CR_ScoreUp()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void CR_GameStart()
    {
        player.SetActive(true);
        playButton.SetActive(false);

        StartCoroutine("CR_SpawnObstacles");
        InvokeRepeating("CR_ScoreUp", 2f, 1f);
    }

}
