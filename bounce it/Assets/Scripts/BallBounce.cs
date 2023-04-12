using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallBounce : MonoBehaviour
{
    public Vector2 StartWay;
    public ButtonEffect _ButtonEffect;
    public ButtonEffect OpenLayer;

    [SerializeField] private Transform _Arrow;


    private Rigidbody2D _rb;
    public Collider2D _collider;
    private Vector3 _lastVelocity;
    public bool _didPush;

    void Start()
    {
        _didPush = false;
        _rb = GetComponent<Rigidbody2D>();
        _ButtonEffect._doClick += Push;


        if (StartWay.x > 0)
        {
            _Arrow.transform.rotation = Quaternion.Euler(0,0,180);
        }
        if (StartWay.y > 0)
        {
            _Arrow.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        if (StartWay.y < 0)
        {
            _Arrow.transform.rotation = Quaternion.Euler(0, 0, 90);
        }


    }

    private void Push()
    {
        if (_didPush) return;

        _collider.enabled = true;
        _rb.velocity = StartWay * 200 * Time.fixedDeltaTime;
        _didPush = true;
        _Arrow.GetComponent<SpriteRenderer>().enabled = false;
    }


    void Update()
    {
        _lastVelocity = _rb.velocity;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        float speed = _lastVelocity.magnitude;
        Vector3 direction = Vector3.Reflect(_lastVelocity.normalized, collision.contacts[0].normal);

        Vector3 roundedVector = new Vector3(Mathf.RoundToInt(direction.x), Mathf.RoundToInt(direction.y), 0);
        
        print(roundedVector);
        _rb.velocity = Vector2.zero;
        _rb.velocity = roundedVector * Mathf.Max(Mathf.Round(speed), 0f);

        print($"Velocity: {_rb.velocity}");

    }

}
