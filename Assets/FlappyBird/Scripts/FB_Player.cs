using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class FB_Player : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float jumpForce;
    private int score = 0;

    [SerializeField] private GameObject scoreUI;

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        rb = GetComponent<Rigidbody>();
        score = 0;
        Physics.gravity = new Vector3(0, -9.81f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector3.up * jumpForce;
        }
    }



    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "ScoreChecker")
        {
            AddScore();
        }
        if (collision.tag == "Obstacle")
        {
            SceneManager.LoadScene("FB_MainScene");
        }
    }

    private void AddScore()
    {
        score++;
        scoreUI.GetComponent<TextMeshProUGUI>().text = score.ToString();
    }

    public void FB_Menu()
    {
        SceneManager.LoadScene("DD_MainMenu");
    }
}
