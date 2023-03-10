using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



public class Obstacle : MonoBehaviour
{
    public bool _didPut, _canHold, _canChange;
    public LayerMask ObstacleLayer, SideLayer;
    public GameObject _holdingObject;


    private GridManager _gridManager;
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
            _capturedSide = SideType().gameObject;
            _holdingObject = ObstacleType().gameObject;
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

    
    //Changing position with grid system
    private void ChangePosition()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePosZ = new Vector3(mousePos.x, mousePos.y, 0);


        //if there is have a Side Rectangle
        if(SideType() != null)
        {

            Vector3 a = SideType().gameObject.transform.position;
            
            //if the Side Rectangle has no rectangle
            if(SideType().gameObject.GetComponent<Side>().Stock == null)
            {

                _holdingObject.gameObject.transform.DOMove(new Vector3(a.x, a.y, 0), .15f);

                //set Side Rectangle's "_holdingObject" variable to what we are holding.
                SideType().gameObject.GetComponent<Side>().Stock = _holdingObject.gameObject;
                
                //if _capturedSide {its mean captured Side Rectangle when we on}
                if(_capturedSide != null)
                {

                    //if _capturedSide is not current side, its mean we want the before captured side.
                    if (_capturedSide != SideType().gameObject)
                    {

                        _capturedSide.GetComponent<Side>().Stock = null;
                        _capturedSide = null;
                        _capturedSide = SideType().gameObject;
                    }
                }
            }
        }
    }

    //For holding obstacles
    public bool IsAnObstacle()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePosZ = new Vector3(mousePos.x, mousePos.y, 0);
        RaycastHit2D hit = Physics2D.Raycast(mousePosZ, Vector3.forward, Mathf.Infinity, ObstacleLayer);

        if (hit.collider != null) return true;
        else return false;
    }

    //For understand which Side Rectangle we are on
    private Collider2D SideType()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePosZ = new Vector3(mousePos.x, mousePos.y, 0);
        RaycastHit2D hit = Physics2D.Raycast(mousePosZ, Vector3.forward, Mathf.Infinity, SideLayer);
        return hit.collider;
    }

    //For understand which holding obstacles is this
    public Collider2D ObstacleType()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePosZ = new Vector3(mousePos.x, mousePos.y, 0);
        RaycastHit2D hit = Physics2D.Raycast(mousePosZ, Vector3.forward, Mathf.Infinity, ObstacleLayer);
        return hit.collider;
    }
}
