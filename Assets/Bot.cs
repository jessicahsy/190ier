using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public Transform ball; 
    public Transform opponent; // Reference to the opponent
    public float moveSpeed = 5f;
    public float hitThreshold = 1.5f; // Distance within which the opponent will hit the ball
    public float minHitForce = 10f;
    public float maxHitForce = 15f;

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
        // Calculate a random position within the opponent's court
        float randomX = Random.Range(-2.7f, 2.7f); // Random x position between the left and right court lines
        float randomZ = Random.Range(0, 7.8f); // Random z position between the net and the back court line

        Vector3 targetPosition = new Vector3(randomX, ball.position.y, randomZ);

        // Calculate the direction and force to hit the ball towards the target position
        Vector3 hitDirection = (targetPosition - ball.position).normalized;
        float hitForce = Random.Range(minHitForce, maxHitForce); // Random force within a range

        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        ballRigidbody.velocity = hitDirection * hitForce;
    }
}
