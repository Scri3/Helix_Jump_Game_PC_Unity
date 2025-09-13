using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMove2 : MonoBehaviour
{
    public float rotatespeed;
    private float moveX;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Mouse X");

        if (Input.GetMouseButton(0))
        {
            transform.Rotate(0f , 0f, rotatespeed * moveX * Time.deltaTime);
        }
    }
}
