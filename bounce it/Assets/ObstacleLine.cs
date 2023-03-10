using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleLine : MonoBehaviour
{
    [SerializeField] BoxCollider2D _BoxCollider;


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
            _BoxCollider.size = new Vector2(1f, 0.14f);
            _didStart = true;
        }
        #endregion
    }
}
