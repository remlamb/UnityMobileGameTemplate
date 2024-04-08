using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DD_Obstacles : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.Rotate(0,0, rotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
            DD_GameManager.instance.DD_IncrementScore();
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            DD_GameManager.instance.DD_GameOver();
        }
    }
}
