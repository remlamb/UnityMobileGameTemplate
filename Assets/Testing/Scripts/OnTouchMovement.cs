using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTouchMovement : MonoBehaviour
{
    private Rigidbody rb;



    public float speed = 5f;
    private Vector3 targetPosition; // Position cible du clic de souris
    private bool isMoving = false;


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
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = gameObject.transform.position.z;

            isMoving = true;
            rb.MovePosition(targetPosition);
        }


        if (isMoving)
        {
            Vector3 direction = (targetPosition - transform.position).normalized;
            Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
            rb.MovePosition(newPosition);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
            }
        }

    }

    public void TM_Menu()
    {
        SceneManager.LoadScene("DD_MainMenu");
    }
}
