using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool _didPut;

    private GridManager _gridManager;
    private Vector3 _currentPosition;


    void Start()
    {
        _didPut = false;
        _gridManager = FindObjectOfType<GridManager>();
    }

    void Update()
    {

        _currentPosition = transform.position;


        if (!_didPut)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 mousePosZ = new Vector3(mousePos.x, mousePos.y, 0);


            if (Input.GetMouseButton(0) && OnMe())
            {
                _gridManager.IsHoldingAnObstacle = true;
                transform.position = mousePosZ;
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
