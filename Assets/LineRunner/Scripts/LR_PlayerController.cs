using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LR_PlayerController : MonoBehaviour
{
    private float playerYPos;
    // Start is called before the first frame update
    void Start()
    {
        playerYPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (LR_GameManager.instance.LR_gameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                playerYPos = -playerYPos;
                transform.position = new Vector3(transform.position.x, playerYPos, transform.position.z);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            LR_GameManager.instance.LR_UpdateLives();
            LR_GameManager.instance.LR_CameraShake();
        }
    }
}
