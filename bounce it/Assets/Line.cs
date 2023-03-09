using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{

    public bool OnMe;



    void Update()
    {
        
    }


    private void OnMouseEnter()
    {
        OnMe = true;
    }
    private void OnMouseExit()
    {
        OnMe = false;
    }
}
