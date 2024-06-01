using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public Transform ball; 
    public Transform opponent; // Reference to the opponent
    public float moveSpeed = 5f;
    public float hitThreshold = 1.5f; // Distance within which the opponent will hit the ball

    void Update()
    {
        if (ball != null)
        {
            Vector3 targetPosition = new Vector3(ball.position.x, opponent.position.y, opponent.position.z);
            opponent.position = Vector3.MoveTowards(opponent.position, targetPosition, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(opponent.position, ball.position) < hitThreshold)
            {
                HitBall();
            }
        }
    }

    void HitBall()
    {
        // Implement ball hitting logic here
        // For example, apply force to the ball to send it back
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        Vector3 hitDirection = (ball.position - opponent.position).normalized;
        ballRigidbody.velocity = hitDirection * 10f; // Adjust the force as needed
    }
}
