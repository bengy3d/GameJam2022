using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    public static void movePlayer(Rigidbody rb, float x, float y, Vector3 pos, int speed)
    {
        rb.MovePosition(pos + new Vector3(x * speed * Time.deltaTime, 0,
            y * speed * Time.deltaTime));
    }
}
