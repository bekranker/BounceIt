using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;


public class LevelStateManager : MonoBehaviour
{
    public LevelBaseState CurrentState;

    [Space(10)]
    public MarketState _MarketState_ = new MarketState();
    public EditState _EditState_ = new EditState();
    public PlayModeState _PlayModeState_ = new PlayModeState();
    public bool EditMode, Market;

    [Space(10)]
    public List<GameObject> ToGray = new List<GameObject>();
    public List<GameObject> ToWhite = new List<GameObject>();
    public List<GameObject> ToFadeZero = new List<GameObject>();
    public List<GameObject> ToFadeOne = new List<GameObject>();
    public Color grayColor, whiteColor;


    [Space(10)]
    [Range(0.05f, 1)] public float Speed;
    public GameObject CardPanel;
    public Transform To;
    public ButtonEffect OpenLayer, PlayButton;
    private bool _didOpen, _canGo;
    private Vector2 _startPosition;
    public bool OnPlay;


    private void Start()
    {
        _canGo = true;
        _didOpen = false;
        OpenLayer._doClick += OpenCardPanel;
        PlayButton._doClick += PlayButtonF;
        _startPosition = CardPanel.transform.position;


        CurrentState = _EditState_;
        CurrentState.OnStart(this);
    }

    private void MarketOpen()
    {
        ToGray.ForEach((_image) => 
        {
            if(_image.gameObject.GetComponent<Image>() != null)
            {
                _image.gameObject.GetComponent<Image>().DOColor(grayColor, Speed);
            }
            if (_image.gameObject.GetComponent<SpriteRenderer>() != null)
            {
                _image.gameObject.GetComponent<SpriteRenderer>().DOColor(grayColor, Speed);
            }
            if (_image.gameObject.GetComponent<TMP_Text>() != null)
            {
                _image.gameObject.GetComponent<TMP_Text>().DOColor(grayColor, Speed);
            }
        });
        ToWhite.ForEach((_image) =>
        {
            if (_image.gameObject.GetComponent<Image>() != null)
            {
                _image.gameObject.GetComponent<Image>().DOColor(whiteColor, Speed);
            }
            if (_image.gameObject.GetComponent<SpriteRenderer>() != null)
            {
                _image.gameObject.GetComponent<SpriteRenderer>().DOColor(whiteColor, Speed);
            }
            if (_image.gameObject.GetComponent<TMP_Text>() != null)
            {
                _image.gameObject.GetComponent<TMP_Text>().DOColor(whiteColor, Speed);
            }
        });
        ToFadeZero.ForEach((_fadeObjedct) => 
        {
            if (_fadeObjedct.gameObject.GetComponent<Image>() != null)
            {
                _fadeObjedct.gameObject.GetComponent<Image>().DOFade(0, Speed);
            }
            if (_fadeObjedct.gameObject.GetComponent<SpriteRenderer>() != null)
            {
                _fadeObjedct.gameObject.GetComponent<SpriteRenderer>().DOFade(0, Speed);
            }
            if (_fadeObjedct.gameObject.GetComponent<TMP_Text>() != null)
            {
                _fadeObjedct.gameObject.GetComponent<TMP_Text>().GetComponent<TMP_Text>().DOFade(0, Speed);
            }
        });
        ToFadeOne.ForEach((_fadeObjedct) =>
        {
            if (_fadeObjedct.gameObject.GetComponent<Image>() != null)
            {
                _fadeObjedct.gameObject.GetComponent<Image>().DOFade(1, Speed);
            }
            if (_fadeObjedct.gameObject.GetComponent<SpriteRenderer>() != null)
            {
                _fadeObjedct.gameObject.GetComponent<SpriteRenderer>().DOFade(1, Speed);
            }
            if (_fadeObjedct.gameObject.GetComponent<TMP_Text>() != null)
            {
                _fadeObjedct.gameObject.GetComponent<TMP_Text>().GetComponent<TMP_Text>().DOFade(1, Speed);
            }
        });
    }
    private void MarketClose()
    {
        ToGray.ForEach((_image) =>
        {
            if (_image.gameObject.GetComponent<Image>() != null)
            {
                _image.gameObject.GetComponent<Image>().DOColor(whiteColor, Speed);
            }
            if (_image.gameObject.GetComponent<SpriteRenderer>() != null)
            {
                _image.gameObject.GetComponent<SpriteRenderer>().DOColor(whiteColor, Speed);
            }
            if (_image.gameObject.GetComponent<TMP_Text>() != null)
            {
                _image.gameObject.GetComponent<TMP_Text>().DOColor(whiteColor, Speed);
            }
            else
            {
                return;
            }
        });
        ToWhite.ForEach((_image) =>
        {
            if (_image.gameObject.GetComponent<Image>() != null)
            {
                _image.gameObject.GetComponent<Image>().DOColor(grayColor, Speed);
            }
            if (_image.gameObject.GetComponent<SpriteRenderer>() != null)
            {
                _image.gameObject.GetComponent<SpriteRenderer>().DOColor(grayColor, Speed);
            }
            if (_image.gameObject.GetComponent<TMP_Text>() != null)
            {
                _image.gameObject.GetComponent<TMP_Text>().DOColor(grayColor, Speed);
            }
            else
            {
                return;
            }
        });
        ToFadeZero.ForEach((_fadeObjedct) =>
        {
            if (_fadeObjedct.gameObject.GetComponent<Image>() != null)
            {
                _fadeObjedct.gameObject.GetComponent<Image>().DOFade(1, Speed);
            }
            if (_fadeObjedct.gameObject.GetComponent<SpriteRenderer>() != null)
            {
                _fadeObjedct.gameObject.GetComponent<SpriteRenderer>().DOFade(1, Speed);
            }
            if (_fadeObjedct.gameObject.GetComponent<TMP_Text>() != null)
            {
                _fadeObjedct.gameObject.GetComponent<TMP_Text>().DOFade(1, Speed);
            }
        });
        ToFadeOne.ForEach((_fadeObjedct) =>
        {
            if (_fadeObjedct.gameObject.GetComponent<Image>() != null)
            {
                _fadeObjedct.gameObject.GetComponent<Image>().DOFade(0, Speed);
            }
            if (_fadeObjedct.gameObject.GetComponent<SpriteRenderer>() != null)
            {
                _fadeObjedct.gameObject.GetComponent<SpriteRenderer>().DOFade(0, Speed);
            }
            if (_fadeObjedct.gameObject.GetComponent<TMP_Text>() != null)
            {
                _fadeObjedct.gameObject.GetComponent<TMP_Text>().DOFade(0, Speed);
            }
        });
    }
    private void PlayButtonF()
    {
        
        OpenLayer.GetComponent<Image>().DOFade(0, Speed).OnComplete(()=> PlayButton.enabled = false).OnComplete(()=>PlayButton.GetComponent<Image>().DOFade(0, Speed));
        _canGo = false;
        Market = false;
        OnPlay = true;

        OpenLayer.enabled = false;
    }

    public void OpenCardPanel()
    {
        if (_canGo)
        {
            if (!_didOpen)
            {
                OpenLayer.transform.DORotate(new Vector3(0, 0, 180), Speed);
                CardPanel.transform.DOMove(To.position, Speed).OnComplete(() => _canGo = true);
                PlayButton.enabled = false;
                Market = true;
                MarketOpen();
            }
            else
            {
                OpenLayer.transform.DORotate(new Vector3(0, 0, 0), Speed);
                CardPanel.transform.DOMove(_startPosition, Speed).OnComplete(() => _canGo = true);
                PlayButton.enabled = true;
                Market = false;
                MarketClose();
            }


            _didOpen = !_didOpen;
            _canGo = false;
        }

    }
    public void SwitchState(LevelBaseState toState)
    {
        CurrentState = toState;
        CurrentState.OnStart(this);
    }
}
