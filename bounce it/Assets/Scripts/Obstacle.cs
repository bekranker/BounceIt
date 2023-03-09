using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



public class Obstacle : MonoBehaviour
{
    public bool _didPut, _canHold, _canChange;
    public LayerMask ObstacleLayer, SideLayer;


    private GridManager _gridManager;
    private GameObject _holdingObject;
    private Vector3 _currentPosition;
    private GameObject _capturedSide;




    void Start()
    {
        _canHold = true;
        _gridManager = FindObjectOfType<GridManager>();
        _currentPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsAnObstacle())
        {
            _capturedSide = SideO().gameObject;
            _holdingObject = ObstacleO().gameObject;
            _canChange = true;
        }


        if (Input.GetMouseButton(0) && _canChange)
        {
            ChangePosition();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _canChange = false;
            _holdingObject = null;
        }
    }

    
    private void ChangePosition()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePosZ = new Vector3(mousePos.x, mousePos.y, 0);

        if(SideO() != null)
        {
            Vector3 a = SideO().gameObject.transform.position;
            if(SideO().gameObject.GetComponent<Side>().Stock == null)
            {
                _holdingObject.gameObject.transform.DOMove(new Vector3(a.x, a.y, 0), .15f);
                SideO().gameObject.GetComponent<Side>().Stock = _holdingObject.gameObject;
                if(_capturedSide != null)
                {
                    if(_capturedSide != SideO().gameObject)
                    {
                        _capturedSide.GetComponent<Side>().Stock = null;
                        _capturedSide = null;
                        _capturedSide = SideO().gameObject;
                    }
                }
            }
        }
    }

    private bool IsAnObstacle()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePosZ = new Vector3(mousePos.x, mousePos.y, 0);
        RaycastHit2D hit = Physics2D.Raycast(mousePosZ, Vector3.forward, Mathf.Infinity, ObstacleLayer);

        if (hit.collider != null) return true;
        else return false;
    }

    private Collider2D SideO()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePosZ = new Vector3(mousePos.x, mousePos.y, 0);
        RaycastHit2D hit = Physics2D.Raycast(mousePosZ, Vector3.forward, Mathf.Infinity, SideLayer);
        return hit.collider;
    }
    private Collider2D ObstacleO()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePosZ = new Vector3(mousePos.x, mousePos.y, 0);
        RaycastHit2D hit = Physics2D.Raycast(mousePosZ, Vector3.forward, Mathf.Infinity, ObstacleLayer);
        return hit.collider;
    }
}