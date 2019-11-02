using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float Speed;

    //private bool CheckRay()
    //{
    //    Ray ray = new Ray(transform.position)
    //    if()
    //    return false;
    //}

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.right, Color.red, 0.3f);
        Debug.DrawRay(transform.position, -transform.right, Color.red, 0.3f);

        
        Debug.DrawRay(transform.position, transform.up, Color.red, 0.3f);
        Debug.DrawRay(transform.position, -transform.up, Color.red, 0.3f);
    }
}
