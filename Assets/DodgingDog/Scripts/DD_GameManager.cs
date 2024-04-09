using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DD_GameManager : MonoBehaviour
{

    public static DD_GameManager instance;
    private bool gameOver = false;
    private int score = 0;
    [SerializeField] private GameObject scoreText;
    [SerializeField] private GameObject GOPanel;



    private void Awake() { instance = this; }

    // Start is called before the first frame update
    void Start()
    {
        GOPanel.SetActive(false);
        Screen.orientation = ScreenOrientation.Portrait;
        Physics.gravity = new Vector3(0, -9.81f, 0);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DD_GameOver()
    {
        gameOver = true;
        GameObject.Find("ObstacleSpawner").GetComponent<DD_ObstacleSpawner>().DD_StopSpawning();
        GOPanel.SetActive(true);

    }

    public void DD_IncrementScore()
    {
        if (!gameOver)
        {
            score++;
            scoreText.GetComponent<TextMeshProUGUI>().text = score.ToString();
        }
    }

    public void DD_Restart()
    {
        SceneManager.LoadScene("DD_MainScene");
    }

    public void DD_Menu()
    {
        SceneManager.LoadScene("DD_MainMenu");
    }
}
