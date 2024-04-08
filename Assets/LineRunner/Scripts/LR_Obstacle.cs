using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LR_Obstacle : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x <= -15.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
