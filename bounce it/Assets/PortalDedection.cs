using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



public class PortalDedection : MonoBehaviour
{
    [SerializeField, Range(0.05f, 1)] private float _OutTime;
    [SerializeField] private ParticleSystem _Effect;
    [SerializeField] private Transform _ToPos;


    private Vector2 _lastVelocity;
    private GameObject _ball;

    private void Start()
    {
        _ToPos.GetComponent<SpriteRenderer>().DOFade(.1f, _OutTime / 3);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CreateAudio.PlayAudio("Portal", .25f, "General", "Sound");
            _ball = collision.gameObject;
            _lastVelocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            GetComponent<Collider2D>().enabled = false;
            transform.DOScale(new Vector3(.5f, .5f, .5f), _OutTime / 3).OnComplete(() => transform.DOScale(Vector3.one, _OutTime / 3));
            _ToPos.GetComponent<SpriteRenderer>().DOFade(1, _OutTime / 3);


            Instantiate(_Effect, transform.position, Quaternion.identity);
            
            
            _ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            _ball.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(BallExit(_ball));
        }
    }


    IEnumerator BallExit(GameObject _ball)
    {
        yield return new WaitForSeconds(_OutTime);
        CreateAudio.PlayAudio("Portal", .25f, "General", "Sound");
        GetComponent<Collider2D>().enabled = true;
        _ToPos.transform.DOScale(new Vector3(.5f, .5f, .5f), _OutTime / 2).OnComplete(() => _ToPos.transform.DOScale(Vector3.one, _OutTime / 2));
        
        
        Instantiate(_Effect, _ToPos.position, Quaternion.identity);
        
        
        _ball.transform.position = _ToPos.position;
        _ball.GetComponent<Rigidbody2D>().velocity = _lastVelocity;
        _ball.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;

        _ToPos.GetComponent<SpriteRenderer>().DOFade(.1f, _OutTime / 3);
    }


}
