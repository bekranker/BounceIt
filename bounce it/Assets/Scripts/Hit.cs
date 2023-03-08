using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hit : MonoBehaviour
{
    public Color HitColor;
    public float HitColorTimeIn, HitColorTimeOut;

    private Color _startColor;
    private SpriteRenderer _spriteR;
    
    
    
    void Start()
    {
        _startColor = GetComponent<SpriteRenderer>().color;
        _spriteR = GetComponent<SpriteRenderer>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        _spriteR.DOColor(HitColor, HitColorTimeIn).OnComplete(()=>_spriteR.DOColor(_startColor, HitColorTimeOut));
    }


}
