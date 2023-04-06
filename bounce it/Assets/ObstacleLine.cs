using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleLine : MonoBehaviour
{
    [SerializeField] BoxCollider2D _BoxCollider;
    [SerializeField] bool _IsPolygon;

    private BallBounce _ballBounce;
    private bool _didStart;




    void Start()
    {
        _ballBounce = GameObject.FindGameObjectWithTag("Player").GetComponent<BallBounce>();

    }

    void Update()
    {
        #region boxcollider size
        if (_ballBounce._didPush && !_didStart)
        {
            if (!_IsPolygon)
            {
                _BoxCollider.size = new Vector2(1.09163f, 0.14f);
                _didStart = true;
            }
            else
            {
                _BoxCollider.enabled = false;
            }
        }
        #endregion
    }
}
