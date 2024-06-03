using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDetection : MonoBehaviour
{
    public GameObject ball;

    void Update()
    {
        if (ball == null)
        {
            ball = GameObject.FindWithTag("TennisBall");
        }
    }
}

