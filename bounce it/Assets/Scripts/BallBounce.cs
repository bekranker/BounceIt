using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public Vector2 StartWay;
    public ButtonEffect _ButtonEffect;

    
    private Rigidbody2D _rb;
    private Collider2D _collider;
    private Vector3 _lastVelocity;
    public bool _didPush;


    void Start()
    {
        _didPush = false;
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _ButtonEffect._doClick = Push;
    }

    private void Push()
    {
        if (_didPush) return;

        _collider.enabled = true;
        _rb.velocity = StartWay * 200 * Time.deltaTime;
        _didPush = true;
    }


    void Update()
    {
        _lastVelocity = _rb.velocity;
    }


   


    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = _lastVelocity.magnitude;
        var direction = Vector3.Reflect(_lastVelocity.normalized, collision.contacts[0].normal);
        _rb.velocity = direction * Mathf.Max(speed, 0f);
    }
}
