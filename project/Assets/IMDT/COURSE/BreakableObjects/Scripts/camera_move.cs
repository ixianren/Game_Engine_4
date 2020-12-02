using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_move : MonoBehaviour
{
    public Transform ball;
    private Vector3 offset;
    private float smoothing = 2;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - ball.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 targetPosition = ball.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothing);

    }
}
