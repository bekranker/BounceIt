using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System.Linq;

public class BlocksSelectionManager : MonoBehaviour
{
    public List<GameObject> CardPrefab;
    public ButtonEffect OpenLayer;
    public GameObject CardPanel;

    public Transform To;
    public float GoTime;

    private bool _didOpen, _canGo;
    private Vector2 _startPosition;

    [SerializeField] private Image _BlackBackground, _StartButton, _PausedImage, _MarketButton;
    [SerializeField] private SpriteRenderer _PlayerSprite;
    [SerializeField] private TMP_Text _LevelText, _LevelTextShadow;
    [SerializeField] private SpriteRenderer[] _Pluses;

    [SerializeField] private Color _GrayColor, _WhiteColor, _TextColorFrom, _TextColorTo;

    private List<GameObject> _obstacleSpriteRenderers = new List<GameObject>();

    private void Start()
    {
        OpenLayer._doClick = OpenCardPanel;
        _canGo = true;
        _startPosition = CardPanel.transform.position;
        RefreshObstacles();
    }

    public void OpenCardPanel()
    {
        if (_canGo)
        {
            if (!_didOpen)
            {
                RefreshObstacles();
                OpenLayer.transform.DORotate(new Vector3(0,0,180), GoTime);
                CardPanel.transform.DOMove(To.position, GoTime).OnComplete(()=> _canGo = true);
            }
            else
            {
                RefreshObstacles();
                CardPanel.transform.DOMove(_startPosition, GoTime).OnComplete(() => _canGo = true);
            }

            fadePluses(_didOpen);

            _didOpen = !_didOpen;
            _canGo = false;
        }

    }


    private void fadePluses(bool a)
    {
        if (!a)
        {
            for (int i = 0; i < _Pluses.Length; i++)
            {
                _BlackBackground.DOFade(0, GoTime);
                
                _PlayerSprite.DOColor(_GrayColor, GoTime);
                _MarketButton.DOColor(_GrayColor, GoTime);
                _LevelText.DOColor(_GrayColor, GoTime);
                _LevelTextShadow.DOColor(_TextColorTo, GoTime);
                _StartButton.DOFade(0, GoTime);
                _PausedImage.DOFade(1, GoTime);
                _Pluses[i].DOFade(1, GoTime);
            }
        }
        else
            for (int i = 0; i < _Pluses.Length; i++)
            {
                _BlackBackground.DOFade(1, GoTime);
                _StartButton.DOFade(1, GoTime);
                _PausedImage.DOFade(0, GoTime);
                _PlayerSprite.DOColor(_WhiteColor, GoTime);
                _MarketButton.DOColor(_WhiteColor, GoTime);
                _LevelText.DOColor(_WhiteColor, GoTime);
                _LevelTextShadow.DOColor(_TextColorFrom, GoTime);
                OpenLayer.transform.DORotate(new Vector3(0, 0, 0), GoTime);
                _Pluses[i].DOFade(0, GoTime);
            }
    }

    private void RefreshObstacles()
    {
        _obstacleSpriteRenderers.Clear();
        _obstacleSpriteRenderers = GameObject.FindGameObjectsWithTag("Obstacle").ToList();
    }
}
