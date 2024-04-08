using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class LR_GameManager : MonoBehaviour
{
    public static LR_GameManager instance;
    public bool LR_gameStarted = false;

    public GameObject player;
    [SerializeField] private int lives;
    private int score = 0;

    [SerializeField] private GameObject livesText;
    [SerializeField] private GameObject scoreText;

    [SerializeField] private GameObject spawner;

    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject gameplayUI;
    private Vector3 originalCamPos;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        scoreText.gameObject.GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString();
        livesText.gameObject.GetComponent<TextMeshProUGUI>().text = "Lives: " + lives.ToString();

        Screen.orientation = ScreenOrientation.LandscapeLeft;


        menuUI.SetActive(true);
        gameplayUI.SetActive(false);

        spawner.SetActive(false);
        LR_gameStarted = false;


        originalCamPos = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LR_StartGame()
    {
        LR_gameStarted = true;

        menuUI.SetActive(false);
        gameplayUI.SetActive(true);
        spawner.SetActive(true);
    }

    public void LR_GameOver()
    {
        player.SetActive(false);
        Invoke("LR_ReloadLevel", 1.5f);
    }

    public void LR_ReloadLevel()
    {
        SceneManager.LoadScene("LR_MainScene");
    }

    public void LR_UpdateLives()
    {
        lives--;
        livesText.gameObject.GetComponent<TextMeshProUGUI>().text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {
            LR_GameOver();
        }
    }

    public void LR_UpdateScore()
    {
        score++;
        scoreText.gameObject.GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString();
    }

    public void LR_Menu()
    {
        SceneManager.LoadScene("DD_MainMenu");
    }



    public void LR_CameraShake()
    {
        StartCoroutine(CameraShake());
    }

    IEnumerator CameraShake()
    {
        for (int i = 0; i < 8; i++)
        {
            Vector2 randomPos = Random.insideUnitCircle * 0.5f;
            Camera.main.transform.position = new Vector3(randomPos.x, randomPos.y, Camera.main.transform.position.z);
            yield return new WaitForSeconds(0.028f);
        }
        Camera.main.transform.position = originalCamPos;
    }

}
