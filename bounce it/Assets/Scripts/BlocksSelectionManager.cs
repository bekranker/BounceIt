using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class BlocksSelectionManager : MonoBehaviour
{
    public List<GameObject> CardPrefab;
    public ButtonEffect OpenLayer;
    public GameObject CardPanel;

    public Transform To;
    public float GoTime;

    private bool _didOpen, _canGo;
    private Vector2 _startPosition;



    private void Start()
    {
        OpenLayer._doClick = OpenCardPanel;
        _canGo = true;
        _startPosition = CardPanel.transform.position;
    }

    public void OpenCardPanel()
    {
        if (_canGo)
        {
            if (!_didOpen)
            {
                OpenLayer.transform.DORotate(new Vector3(0,0,90), GoTime);
                CardPanel.transform.DOMove(To.position, GoTime).OnComplete(()=> _canGo = true);
            }
            else
            {
                OpenLayer.transform.DORotate(new Vector3(0, 0, -90), GoTime);
                CardPanel.transform.DOMove(_startPosition, GoTime).OnComplete(() => _canGo = true);
            }

            _didOpen = !_didOpen;
            _canGo = false;
        }

    }
}
