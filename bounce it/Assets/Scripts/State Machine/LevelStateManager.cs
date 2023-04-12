using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;


public class LevelStateManager : MonoBehaviour
{


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
    public ButtonEffect OpenLayer, PlayButton, HomeButton, RestartButton;
    private bool _didOpen, _canGo;
    private Vector2 _startPosition;
    public bool OnPlay;

    [Space(10)]
    [SerializeField] private Transform _To, _Start, Area;
    [SerializeField] private TMP_Text LevelText, LevelTextShadow;












    private void Start()
    {
        _canGo = true;
        _didOpen = false;
        if(OpenLayer != null)
            OpenLayer._doClick += OpenCardPanel;
        if (PlayButton != null)
            PlayButton._doClick += PlayButtonF;
        if(CardPanel != null)
            _startPosition = CardPanel.transform.position;
        if (HomeButton != null)
            HomeButton._doClick = ReturnHome;
        if (RestartButton != null)
            RestartButton._doClick = RestartLevel;


        if(SceneManager.GetActiveScene().buildIndex > 0)
        {
            LevelText.text = $"Level - {SceneManager.GetActiveScene().buildIndex}";
            LevelTextShadow.text = $"Level - {SceneManager.GetActiveScene().buildIndex}";
        }


        if(ToGray != null)
        {
            ToGray.ForEach((togray) =>
            {
                if (togray.gameObject.GetComponent<Image>() != null)
                {
                    togray.gameObject.GetComponent<Image>().DOFade(0, 0).OnComplete(() =>
                    {
                        togray.gameObject.GetComponent<Image>().DOFade(1, Speed);
                    });
                }
                if (togray.gameObject.GetComponent<SpriteRenderer>() != null)
                {
                    togray.gameObject.GetComponent<SpriteRenderer>().DOFade(0, 0).OnComplete(() =>
                    {
                        togray.gameObject.GetComponent<SpriteRenderer>().DOFade(1, Speed);
                    });
                }
                if (togray.gameObject.GetComponent<TMP_Text>() != null)
                {
                    togray.gameObject.GetComponent<TMP_Text>().DOFade(0, 0).OnComplete(() =>
                    {
                        togray.gameObject.GetComponent<TMP_Text>().DOFade(1, Speed);
                    });
                }
            });
        }
    }
    private void ReturnHome() => SceneManager.LoadScene(0);
    private void RestartLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        PlayButton.enabled = false;
        OpenLayer.GetComponent<Image>().DOFade(0, Speed / 2).OnComplete(()=>PlayButton.GetComponent<Image>().DOFade(0, Speed / 2));
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
                Area.transform.DOMove(_To.position, Speed);
                PlayButton.enabled = false;
                Market = true;
                MarketOpen();
            }
            else
            {
                OpenLayer.transform.DORotate(new Vector3(0, 0, 0), Speed);
                CardPanel.transform.DOMove(_startPosition, Speed).OnComplete(() => _canGo = true);
                Area.transform.DOMove(_Start.position, Speed);
                PlayButton.enabled = true;
                Market = false;
                MarketClose();
            }


            _didOpen = !_didOpen;
            _canGo = false;
        }

    }
}
