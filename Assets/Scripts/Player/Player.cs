using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour {
    
    [SerializeField] private int _speed = 5;

    [SerializeField] private TrigerBoxController colider;
    private Rigidbody _rb;
    private float x;
    private float z;
    private bool _trash = false;
    void Start(){
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        x = Input.GetAxis(GameData.HORIZONTALP1);
        z = Input.GetAxis(GameData.VERTICALP1);
        
    }

    void FixedUpdate() {
        _rb.MovePosition(transform.position + new Vector3(x, 0, z) * Time.fixedDeltaTime * _speed) ;
    }
}
