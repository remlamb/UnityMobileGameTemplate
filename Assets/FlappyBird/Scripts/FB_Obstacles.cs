using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FB_Obstacles : MonoBehaviour
{
    [SerializeField] private float moveSpeed;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        if (transform.position.x < -10)
        {
            Destroy(this.gameObject);
        }
    }


}
