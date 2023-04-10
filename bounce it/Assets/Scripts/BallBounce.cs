using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallBounce : MonoBehaviour
{
    public Vector2 StartWay;
    public ButtonEffect _ButtonEffect;
    public ButtonEffect OpenLayer;


    private Rigidbody2D _rb;
    private Collider2D _collider;
    private Vector3 _lastVelocity;
    public bool _didPush;


    void Start()
    {
        _didPush = false;
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _ButtonEffect._doClick += Push;
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
        Vector3 direction = Vector3.Reflect(_lastVelocity.normalized, collision.contacts[0].normal);
        Vector3 roundedVector = new Vector3(Mathf.RoundToInt(direction.x), Mathf.RoundToInt(direction.y), 0);
        print(roundedVector);
        _rb.velocity = Vector2.zero;
        _rb.velocity = roundedVector * Mathf.Max(speed, 0f);
        print(_rb.velocity);
    }
}
