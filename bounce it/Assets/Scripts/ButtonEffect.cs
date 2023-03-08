using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
{

    [Space(15)]
    [Header("-----Enter-----")]
    [Space(5)]
    [SerializeField] float _EnterTime;
    [SerializeField] Vector2 _OnEnterSize;
    [SerializeField] Color _OnEnterColor;

    [Space(15)]
    [Header("-----Exit-----")]
    [Space(5)]
    [SerializeField] float _ExitTime;
    [SerializeField] Color _OnExitColor;


    [Space(15)]
    [Header("-----Click-----")]
    [Space(5)]
    [SerializeField] float _ClickTime;
    [SerializeField] Color _ClickColor;
    [SerializeField] Vector2 _OnClickSize;




    [HideInInspector] public delegate void doClick();
    [HideInInspector] public doClick _doClick;


    private Image _image;
    private Vector2 _startSize;
    private Color _startColor;
    private Vector2 _currentSize;
    private bool _isEnter, _canChange;


    private void Start()
    {
        _isEnter = false;
        _canChange = true;
        _image = GetComponent<Image>();
        _startColor = GetComponent<Image>().color;
        _startSize = transform.localScale;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        _isEnter = true;
        _image.DOColor(_OnEnterColor, _EnterTime);
        _image.gameObject.transform.DOScale(_OnEnterSize, _EnterTime).OnComplete(() => _canChange = true);
        _canChange = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isEnter = false;
        _image.DOColor(_OnExitColor, _ExitTime);
        _image.gameObject.transform.DOScale(_startSize, _ExitTime).OnComplete(() => _canChange = true);
        _canChange = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }
    private void complateState()
    {
        _image.gameObject.transform.DOScale(_currentSize, _ClickTime).OnComplete(()=> _canChange = true);

        if (_doClick == null) return;
        _doClick();
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        _currentSize = _image.gameObject.transform.localScale;

        if (!_isEnter) return;
        if (_canChange)
        {
            _image.gameObject.transform.DOScale(_OnClickSize, _ClickTime).OnComplete(
                () => complateState());
            _canChange = false;
        }
    }
}
