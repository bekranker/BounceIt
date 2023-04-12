using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hit : MonoBehaviour
{
    public Color HitColor;
    public float HitColorTimeIn, HitColorTimeOut;

    [SerializeField] private ParticleSystem _Effect;
    [SerializeField] private SpriteRenderer _Sp;

    private Color _startColor => Color.white;
    private LevelStateManager _levelStateManager => FindAnyObjectByType<LevelStateManager>();
    


    void Start()
    {
        _Sp.color = (_levelStateManager.Market == false) ? _levelStateManager.whiteColor : _levelStateManager.grayColor;
        _levelStateManager.ToGray.Add(_Sp.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        _Sp.DOColor(HitColor, HitColorTimeIn).OnComplete(()=> _Sp.DOColor(_startColor, HitColorTimeOut));
        ParticleSystem a = Instantiate(_Effect, _Sp.transform.position, _Sp.transform.rotation);

        ParticleSystem.MainModule b = a.main;

        b.startRotation = Quaternion.ToEulerAngles(_Sp.gameObject.transform.rotation).z * -1;
        a.textureSheetAnimation.SetSprite(0, _Sp.sprite);

    }


}
