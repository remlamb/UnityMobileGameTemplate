using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DD_MenuController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DD_Play()
    {
        SceneManager.LoadScene("DD_MainScene");
    }
    public void CR_Play()
    {
        SceneManager.LoadScene("CR_MainScene");
    }

    public void DD_Quit()
    {
        Application.Quit();
    }
}
