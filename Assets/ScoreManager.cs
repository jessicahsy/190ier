using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText; // Reference to the TMP text component
    private int player1Score = 0;
    private int player2Score = 0;
    private readonly int[] points = { 0, 15, 30, 40 }; // Tennis point system

    void Start()
    {
        UpdateScoreText();
    }

    public void AddPointToPlayer1()
    {
        if (player1Score < 3)
        {
            player1Score++;
            UpdateScoreText();
        }
        else
        {
            // Player 1 wins the game
            Debug.Log("Player 1 wins the game!");
            ResetScores();
        }
    }

    public void AddPointToPlayer2()
    {
        if (player2Score < 3)
        {
            player2Score++;
            UpdateScoreText();
        }
        else
        {
            // Player 2 wins the game
            Debug.Log("Player 2 wins the game!");
            ResetScores();
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"{points[player1Score]} - {points[player2Score]}";
    }

    private void GameText()
    {
        scoreText.text = "GAME";
        
    }

    private void ResetScores()
    {
        player1Score = 0;
        player2Score = 0;
        UpdateScoreText();
    }
}
