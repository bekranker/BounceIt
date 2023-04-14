using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallBounce : MonoBehaviour
{
    public Vector2 StartWay;
    public ButtonEffect _ButtonEffect;
    public ButtonEffect OpenLayer;
    public Collider2D _collider;
    public bool _didPush;

    
    [SerializeField] private Transform _Arrow;


    private List<string> _soundEffects = new List<string> { "Sekme2", "Sekme" };
    private int _soundEffectIndex = 0;
    private Rigidbody2D _rb;
    private Vector3 _lastVelocity;


    void Start()
    {
        _didPush = false;
        _rb = GetComponent<Rigidbody2D>();
        _ButtonEffect._doClick += Push;
        _collider.isTrigger = true;

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

        _collider.isTrigger = false;
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
        if (collision.gameObject.CompareTag("Respawn"))
        {
            CreateAudio.PlayAudio("kaybet", .25f, "General", "Sound");
            return;
        }
        float speed = _lastVelocity.magnitude;
        Vector3 direction = Vector3.Reflect(_lastVelocity.normalized, collision.contacts[0].normal);

        Vector3 roundedVector = new Vector3(Mathf.RoundToInt(direction.x), Mathf.RoundToInt(direction.y), 0);
        
        print(roundedVector);
        _rb.velocity = Vector2.zero;
        _rb.velocity = roundedVector * Mathf.Max(Mathf.Round(speed), 0f);


        _soundEffectIndex = (_soundEffectIndex == 1) ? 0 : 1;
        CreateAudio.PlayAudio($"{_soundEffects[_soundEffectIndex]}", .25f, "General", "Sound");

       

        print($"Velocity: {_rb.velocity}");

    }

}
