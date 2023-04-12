using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using DG.Tweening;

public class Side : MonoBehaviour
{
    public GameObject Stock;
    public LayerMask layer;

    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        FullIt();
    }
    
    private void FullIt()
    {
        if (Physics2D.OverlapBox(transform.position, Vector2.one / 2, 0, layer))
        {
            Stock = Physics2D.OverlapBox(transform.position, Vector2.one / 2, 0, layer).gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Stock = null;
    }
}
