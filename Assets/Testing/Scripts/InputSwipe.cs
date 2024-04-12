using UnityEngine;

public class InputSwipe : MonoBehaviour
{
    [SerializeField] private float maxTime;
    [SerializeField] private float minSwipeDist;

    private float startTime;
    private float endTime;

    private Vector3 startPos;
    private Vector3 endPos;

    private float swipeDistance;
    private float swipeTime;

    public bool isSwipingRight;
    public bool isSwipingLeft;
    public bool isSwipingUp;
    public bool isSwipingDown;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isSwipingRight = false;
        isSwipingLeft = false;
        isSwipingUp = false;
        isSwipingDown = false;

        if (Input.touchCount > 0)
        {
            Debug.Log("Touched");
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startTime = Time.time;
                startPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endTime = Time.time;
                endPos = touch.position;

                swipeDistance = (endPos - startPos).magnitude;
                swipeTime = endTime - startTime;

                if (swipeTime < maxTime && swipeDistance > minSwipeDist)
                {
                    swipe();
                }
            }
        }
    }


    void swipe()
    {
        Vector2 distance = endPos - startPos;
        if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
        {
            Debug.Log("Horizontal swipe");
            if (distance.x > 0)
            {
                Debug.Log("Right swipe");
                isSwipingRight = true;
            }
            if (distance.x < 0)
            {
                Debug.Log("Left swipe");
                isSwipingLeft = true;
            }
        }
        else if (Mathf.Abs(distance.x) < Mathf.Abs(distance.y))
        {
            Debug.Log("Vertical swipe");
            if (distance.y > 0)
            {
                isSwipingUp = true;
                Debug.Log("Right swipe");
            }
            if (distance.y < 0)
            {
                isSwipingDown = true;
                Debug.Log("Left swipe");
            }
        }
    }
}
