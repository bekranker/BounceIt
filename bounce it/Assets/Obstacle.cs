using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool _didPut, _canHold;

    private GridManager _gridManager;
    private Vector3 _currentPosition;
    private float _distance;

    void Start()
    {
        _didPut = false;
        _canHold = true;
        _gridManager = FindObjectOfType<GridManager>();
        _currentPosition = transform.position;
    }

    void Update()
    {
        if (!_didPut)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 mousePosZ = new Vector3(mousePos.x, mousePos.y, 0);


            if (Input.GetMouseButton(0))
            {
                _distance = Vector3.Distance(_currentPosition, mousePosZ);
                _gridManager.IsHoldingAnObstacle = true;
                
                if(_distance >= 1f)
                {
                    print("sa");
                    transform.position = mousePosZ;
                    _currentPosition = transform.position;
                }
            }
            else if(Input.GetMouseButtonUp(0) && OnMe())
                _gridManager.IsHoldingAnObstacle = false;
        }
    }

    private bool OnMe()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePosZ = new Vector3(mousePos.x, mousePos.y, 0);
        RaycastHit2D hit = Physics2D.Raycast(mousePosZ, Vector3.forward, Mathf.Infinity);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject == gameObject)
                return true;
            else
                return false;
        }
        else return false;
    }
}
