using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using TMPro;


public class Card : MonoBehaviour
{

    public CardPrefab CardPrefab;
    public TMP_Text CountText;
    public Image ObstacleImage;
    public Color ClickColorForText;


    private int _startCount, _currentCount;
    private GameObject _obstacleType;
    private Sprite _buttonImage;
    private ButtonEffect _buttonEffect;
    private Vector3 _textStartSize;


    private bool _canClick;

    void Start()
    {

        _canClick = true;

        _startCount = CardPrefab.StartCount;
        _obstacleType = CardPrefab.ObstacleType;
        _buttonImage = CardPrefab.ButtonImage;


        _buttonEffect = GetComponent<ButtonEffect>();
        _currentCount = _startCount;
        ObstacleImage.sprite = _buttonImage;
        CountText.text = _startCount.ToString();
        _textStartSize = CountText.gameObject.transform.localScale;

        _buttonEffect._doClick = CreateObstacle;
    
    
    }

    public void CreateObstacle()
    {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       

        if (_currentCount - 1 >= 0)
        {
            Instantiate(_obstacleType, new Vector3(mousePos.x, mousePos.y, 0), Quaternion.identity);
            _currentCount--;
            CountText.text = _currentCount.ToString();

            CountText.transform.DOScale(new Vector3(_textStartSize.x * -1, _textStartSize.y, _textStartSize.z) , .15f).OnComplete(() => CountText.transform.DOScale(_textStartSize, .15f));
        }
        else
        {
            CountText.DOColor(ClickColorForText, .1f).OnComplete(() => CountText.DOColor(new Color(255, 255, 255, 1), .1f)).OnComplete(() => _canClick = true);
            _canClick = false;
        }

       
    }


}
