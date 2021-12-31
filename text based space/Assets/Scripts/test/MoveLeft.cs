using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D transformMe;
    // Start is called before the first frame update
    void Start()
    {
        //transformMe.velocity = Vector2.left;
        transformMe.AddForce(Vector2.left);
    }

    // Update is called once per frame
    void Update()
    {
        //transformMe.AddForce(Vector2.left);
        if (Input.GetKey(KeyCode.A))
        {
            transformMe.velocity = Vector2.left;
        }
        else
        {
            transformMe.velocity = Vector2.zero;
        }


    }


}
