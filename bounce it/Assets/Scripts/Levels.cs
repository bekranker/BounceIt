using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class Levels : MonoBehaviour
{
    [SerializeField] private ButtonEffect[] _LevelButtons;
    [SerializeField] private RectTransform _Transform;
    [SerializeField] private ButtonEffect _RightButton, _LeftButton;
    [SerializeField, Range(0.1f, 10)] private float _Speed;
    [SerializeField] private Sprite _UnlockSprite;

    private MainMenu _mainMenu => GetComponent<MainMenu>();
    int _index = 0;
    bool _canClick = true;


    void Start()
    {
        _canClick = true;
        for (int i = 1; i < _LevelButtons.Length; i++)
        {
            if(!PlayerPrefs.HasKey($"Level: {i} is Unlocked"))
            {
                _LevelButtons[i].GetComponent<Image>().sprite = _UnlockSprite;
                _LevelButtons[i].enabled = false;
                _LevelButtons[i].GetComponent<Button>().interactable = false;
            }
            else
            {
                _LevelButtons[i].GetComponent<Button>().interactable = true;
                _LevelButtons[i].enabled = true;
            }
            _LevelButtons[i].transform.GetChild(0).GetComponent<TMP_Text>().text = (i + 1).ToString();
            _LevelButtons[i].transform.GetChild(0).name = (i + 1).ToString();
        }

        _RightButton._doClick = Right;
        _LeftButton._doClick = Left;
    }


    public void Right()
    {
        if (!_canClick) return;
        _index++;
        

        if(_index <= 6)
        {
            Vector3 a = new Vector3(5f, 0, 0);
            _Transform.DOMoveX(_Transform.position.x - a.x, _Speed).SetEase(Ease.OutBounce).OnComplete(()=> 
            {
                _mainMenu.CanClick = true;
                _canClick = true;
            });
        }
        else
        {
            _index = 0;
            Vector3 a = new Vector3(30f, 0, 0);
            _Transform.DOMoveX(_Transform.position.x + a.x, _Speed).SetEase(Ease.OutBounce).OnComplete(() => 
            {
                _mainMenu.CanClick = true;
                _canClick = true;
            });
        }

        _mainMenu.CanClick = false;
        _canClick = false;
    }
    public void Left()
    {
        if (!_canClick) return;
        _index--;


        if (_index >= 0)
        {
            Vector3 a = new Vector3(5f, 0, 0);
            _Transform.DOMoveX(_Transform.position.x + a.x, _Speed).SetEase(Ease.OutBounce).OnComplete(() => 
            {
                _canClick = true;
                _mainMenu.CanClick = true;
            });
        }
        else
        {
            _index = 6;
            Vector3 a = new Vector3(30f, 0, 0);
            _Transform.DOMoveX(_Transform.position.x - a.x, _Speed).SetEase(Ease.OutBounce).OnComplete(() => 
            {
                _mainMenu.CanClick = true;
                _canClick = true;
            });
        }
        _mainMenu.CanClick = false;
        _canClick = false;
    }

}
