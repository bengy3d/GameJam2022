using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed = 5;

    Rigidbody rb;

    private float movementV;
    private float movementH;

    void Awake(){
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        movementH = Input.GetAxis("Horizontal");
        movementV = Input.GetAxis("Vertical");
    }

    void FixedUpdate(){
        rb.MovePosition(transform.position + new Vector3(movementH, 0, movementV));

    }
}
