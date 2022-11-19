using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour {
    private Rigidbody _rb;
    private float _xDisplacement;
    private float _yDisplacement;
    private bool _trash = false;
    private GameObject gameObject;

    [SerializeField] private int _speed = 5;
    void Start(){
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _xDisplacement = Input.GetAxis(GameData.HORIZONTALP1);
        _yDisplacement = Input.GetAxis(GameData.VERTICALP1);
    }

    void FixedUpdate() {
        PlayerMovement.movePlayer(_rb, _xDisplacement, _yDisplacement, transform.position, _speed);
    }
}
