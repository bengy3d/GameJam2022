using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player2Movement : MonoBehaviour
{
    private Rigidbody _rb;
    private float _xDisplacement;
    private float _yDisplacement;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        _xDisplacement = Input.GetAxis(GameData.HORIZONTALP2);
        _yDisplacement = Input.GetAxis(GameData.VERTICALP2);
    }

    void FixedUpdate()
    {
        _rb.MovePosition(transform.position + new Vector3(_xDisplacement, 0, _yDisplacement));
    }
}
