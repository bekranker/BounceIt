using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side : MonoBehaviour
{
    public GameObject Stock;

    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Stock = null;
    }
}
