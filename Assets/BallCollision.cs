using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public ScoreManager scoreManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("P1-add"))
        {
            scoreManager.AddPointToPlayer1();
        }
        else if (collision.gameObject.CompareTag("P2-add"))
        {
            scoreManager.AddPointToPlayer2();
        }
    }
}
