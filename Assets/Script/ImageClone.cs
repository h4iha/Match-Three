using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ImageClone : MonoBehaviour
{
    public bool isCanMove;
    public Vector3 destination;
    private void Start()
    {
        isCanMove = false;
    }
    private void Update()
    {
        if (transform.position == destination)
        {
            isCanMove = false;
        }
        if (isCanMove)
        {
            //transform.position = Vector3.Lerp();
            transform.position = Vector3.MoveTowards(transform.position, destination, 0.001f * Time.deltaTime);
        }
    }
}
