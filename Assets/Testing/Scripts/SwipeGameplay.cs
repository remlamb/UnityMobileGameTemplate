using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class SwipeGameplay : MonoBehaviour
{
    private InputSwipe playerInput;

    [SerializeField] private AudioSource sound;
    [SerializeField] private float xAxisMovement;

    private float currentTimeScale;
    private float currentPitch;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<InputSwipe>();
        currentTimeScale = Time.timeScale;
        currentPitch = sound.pitch;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput.isSwipingUp)
        {
            currentTimeScale += 0.4f;
            currentPitch += 0.4f;

        }
        if (playerInput.isSwipingDown)
        {
            currentTimeScale -= 0.4f;
            currentPitch -= 0.4f;

        }
        Clamp(1.8f, 0.2f, ref currentTimeScale);
        Clamp(1.8f, 0.2f,ref currentPitch);
        Time.timeScale = currentTimeScale;
        sound.pitch = currentPitch;


        float newPosX = gameObject.transform.position.x;
        if (playerInput.isSwipingRight)
        {
            newPosX += xAxisMovement;
        }
        if (playerInput.isSwipingLeft)
        {
            newPosX -= xAxisMovement;
        }

        Clamp(1.7f, -1.7f, ref newPosX);
        gameObject.transform.position = new Vector3(newPosX,
            gameObject.transform.position.y, gameObject.transform.position.z);

    }

    void Clamp(float max, float min, ref float value)
    {
        if (value > max)
        {
            value = max;
        }
        else if (value < min)
        {
            value = min;
        }
    }

    public void TEST_Menu()
    {
        SceneManager.LoadScene("DD_MainMenu");
    }
}
