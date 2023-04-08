using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Line : MonoBehaviour
{

    
    [SerializeField] GameObject _RotatePanel;
    
    
    private Obstacle _obstacleManager;
    private bool _canOpen;

    private void Start()
    {
        _canOpen = true;
        _obstacleManager = GetComponent<Obstacle>();
        ClosePanel();
    }


    void Update()
    {
        if (_obstacleManager.ObstacleType() != null)
        {
            if (_obstacleManager.ObstacleType().gameObject.CompareTag("LineObstacle") && _canOpen)
            {
                OpenPanel();
            }
            else
                ClosePanel();
        }
        else
            ClosePanel();

        if (!_canOpen)
            ClosePanel();


        if (_obstacleManager.ObstacleType() != null)
        {
            if (_obstacleManager.ObstacleType().gameObject.CompareTag("LineObstacle"))
            {
                if (Input.GetMouseButton(0))
                    _canOpen = false;
                if (Input.GetMouseButtonUp(0))
                    _canOpen = true;
            }
            else
                _canOpen = true;
        }

    }

    private void OpenPanel()
    {
        _RotatePanel = _obstacleManager.ObstacleType().gameObject.transform.GetChild(0).gameObject;
        _RotatePanel.SetActive(true);
        _RotatePanel.GetComponent<CanvasGroup>().DOFade(1, .2f);
    }

    private void ClosePanel()
    {
        if(_RotatePanel != null)
        {
            _RotatePanel.GetComponent<CanvasGroup>().DOFade(0, .2f);
            _RotatePanel.SetActive(false);
        }
        _RotatePanel = null;
    }
}
