using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [RequireComponent(typeof(Rigidbody))]
public class Player1Movement : MonoBehaviour
{
    private Rigidbody _rb;
    private float _xDisplacement;
    private float _yDisplacement;
    void Start(){
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        _xDisplacement = Input.GetAxis(GameData.HORIZONTALP1);
        _yDisplacement = Input.GetAxis(GameData.VERTICALP1);
    }

    void FixedUpdate(){
        _rb.MovePosition(transform.position + new Vector3(_xDisplacement, 0, _yDisplacement));
    }
}
