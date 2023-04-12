using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



public class Obstacle : MonoBehaviour
{
    public bool _didPut, _canHold, _canChange;
    public LayerMask ObstacleLayer, SideLayer;
    public GameObject _holdingObject;
    [SerializeField] private LevelStateManager _LevelStateManager;
    [SerializeField] private List<SpriteRenderer> _Pluses = new List<SpriteRenderer>();
    [SerializeField, Range(0.05f, 1f)] private float _Speed;
    [SerializeField] private Color _GrayColor;
    private GridManager _gridManager;
    private Vector3 _currentPosition;
    private GameObject _capturedSide;
    private bool _canRotate;
    public Vector3 a;   


    void Start()
    {
        _canRotate = true;
        _canHold = true;
        _gridManager = FindObjectOfType<GridManager>();
        _currentPosition = transform.position;
    }

    void Update()
    {
        if (_LevelStateManager.OnPlay) return;
        if (Input.GetMouseButtonDown(0) && IsAnObstacle())
        {
            _capturedSide = SideType().gameObject;
            _holdingObject = ObstacleType().gameObject;
            _canChange = true;
            if (!_LevelStateManager.Market)
            {
                _Pluses.ForEach((_plus) =>
                {
                    _plus.DOFade(1, _Speed);
                });
            }
            
        }


        if (Input.GetMouseButton(0) && _canChange)
        {
            ChangePosition();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _canChange = false;
            _holdingObject = null;
            if (!_LevelStateManager.Market)
            {
                _Pluses.ForEach((_plus) =>
                {
                    _plus.DOFade(0, _Speed);
                });
            }
                
        }

        if (Input.GetMouseButtonDown(1) && IsAnObstacle())
        {
            RotateObstacle();
        }
    }

    //Rotate the Obstacle
    private void RotateObstacle()
    {
        if (!_canRotate) return;
        if (ObstacleType() != null)
        {
            a = new Vector3(0, 0, Mathf.Round(ObstacleType().transform.rotation.eulerAngles.z - 45));
            ObstacleType().gameObject.transform.DORotate(a, _Speed).OnComplete(() => _canRotate = true);
            _canRotate = false;
            print("rotated");
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
