using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side : MonoBehaviour
{
    public GameObject Stock;

    private void OnTriggerExit2D(Collider2D collision)
    {
        Stock = null;
    }
}
