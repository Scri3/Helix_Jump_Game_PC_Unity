using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerController : MonoBehaviour
{
    public Transform ball;
    private Vector3 offset;

    public float Lerpspeed;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - ball.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = Vector3.Lerp(ball.position + offset, transform.position , Lerpspeed);
        transform.position = newPos;
    }
}
