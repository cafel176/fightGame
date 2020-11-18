using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{
    public Vector3 move;
    public float speed = 1;

    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        _rigidbody.velocity = move.normalized * speed;
        _rigidbody.angularVelocity = Vector3.zero;
    }
}
