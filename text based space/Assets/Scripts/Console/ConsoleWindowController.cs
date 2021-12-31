using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleWindowController : MonoBehaviour
{
    //private Ray mouseRay;
    //[SerializeField]
    //private BoxCollider2D dragger;
    public bool posisiondown = true;
    [SerializeField]
    private float downY = 1.7f;
    [SerializeField]
    private float upY = 7.6f;
    private float destinationY;
    public bool moving = false;
    [SerializeField]
    private Transform consoleTransform;
    private readonly float speed = 0.7f;
    private float eSpeed;
    [SerializeField]
    private bool stopOnPause;

    private void OnMouseDown()
    {
        MoveWindow();
    }
    private void Start()
    {
        posisiondown = true;
    }

    private void Update()
    {
        if (stopOnPause && PauseController.paused)
        { return; }
        bool reachedDestination;
        if (posisiondown)
        { reachedDestination = consoleTransform.position.y <= destinationY + eSpeed; }
        else
        { reachedDestination = consoleTransform.position.y >= destinationY + eSpeed; }
        if (moving)
        {
            if (reachedDestination)
            {
                consoleTransform.position = new Vector3(consoleTransform.position.x, destinationY, 0);
                moving = false;
            }
            else
            {
                consoleTransform.position = new Vector3(consoleTransform.position.x, consoleTransform.position.y + eSpeed, 0);
            }
        }
    }

    public void MoveWindow()
    {
        moving = true;
        posisiondown = !posisiondown;
        if (posisiondown)
        {
            eSpeed = -speed;
            destinationY = downY;
        }
        else
        {
            eSpeed = speed;
            destinationY = upY;
        }
    }
}
