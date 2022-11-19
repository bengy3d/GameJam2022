using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player2Movement : MonoBehaviour
{
    private Rigidbody _rb;
    private float _xDisplacement;
    private float _yDisplacement;

    [SerializeField] private int _speed = 5;

    private bool _thrash = false;


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
        _rb.MovePosition(transform.position + new Vector3(_xDisplacement * _speed * Time.deltaTime, 0,
            _yDisplacement * _speed * Time.deltaTime));
    }

    private void OnTriggerStay(Collider other)
    {


        if (other.gameObject.CompareTag("Thrash"))
        {
            if (_thrash == true)
            {
                return;
            }

            if (Input.GetButtonDown(GameData.PICKUPP2))
            {
                Destroy(other.gameObject);
                _thrash = true;
            }
        }

        if (other.gameObject.CompareTag("Garbage"))
        {
            if (Input.GetButtonDown(GameData.PICKUPP2))
            {
                _thrash = false;
                print(_thrash);
            }
        }

    }
}
