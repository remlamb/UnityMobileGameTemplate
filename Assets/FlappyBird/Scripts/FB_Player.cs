using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FB_Player : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector3.up * jumpForce;
        }
    }
}
