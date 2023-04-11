using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hit : MonoBehaviour
{
    public Color HitColor;
    public float HitColorTimeIn, HitColorTimeOut;

    [SerializeField] private ParticleSystem _Effect;

    private Color _startColor;
    private SpriteRenderer _spriteR;
    private LevelStateManager _levelStateManager => FindAnyObjectByType<LevelStateManager>();
    


    void Start()
    {
        _startColor = GetComponent<SpriteRenderer>().color;
        _spriteR = GetComponent<SpriteRenderer>();
        GetComponent<SpriteRenderer>().color = (_levelStateManager.Market == false) ? _levelStateManager.whiteColor : _levelStateManager.grayColor;
        _levelStateManager.ToGray.Add(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        _spriteR.DOColor(HitColor, HitColorTimeIn).OnComplete(()=>_spriteR.DOColor(_startColor, HitColorTimeOut));
        ParticleSystem a = Instantiate(_Effect, transform.position, transform.rotation);

        ParticleSystem.MainModule b = a.main;

        b.startRotation = Quaternion.ToEulerAngles(transform.rotation).z * -1;
        a.textureSheetAnimation.SetSprite(0, GetComponent<SpriteRenderer>().sprite);

    }


}
