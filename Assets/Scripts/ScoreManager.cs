using UnityEngine;
using TMPro;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText; // Reference to the TMP text component
    private int player1Score = 0;
    private int player2Score = 0;
    private readonly int[] points = { 0, 15, 30, 40 }; // Tennis point system

    public AudioSource source;
    public AudioClip serve,fx_victory;//,fx_point;
    public AudioClip fx_zero, fx_fifteen, fx_thirty, fx_forty, fx_lose, fx_win;
    public static bool isGameOn = true;
    public GameObject restart;

    void Start()
    {
        UpdateScoreText();
        isGameOn = true;
    }

    void OnCollisionEnter(Collision collision)  {
        if (collision.gameObject.CompareTag("behind-backline")) {
            Debug.Log("Collision detected with tag: " + collision.gameObject.tag);
            source.clip = serve;
            source.Play();
        }
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
            isGameOn = false;
            StartCoroutine(GameText(1));
            // Player 1 wins the game
            Debug.Log("Player 1 wins the game!");
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
            isGameOn = false;
            StartCoroutine(GameText(2));
            // Player 2 wins the game
            Debug.Log("Player 2 wins the game!");
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"{points[player1Score]} - {points[player2Score]}";
        if (player1Score > 0 || player2Score > 0){
            StartCoroutine(PlayScoreSounds());
        }
        

    }
    private IEnumerator PlayScoreSounds()
    {
        PlayScoreSound(player1Score);
        yield return new WaitForSeconds(source.clip.length);

        PlayScoreSound(player2Score);
        yield return new WaitForSeconds(source.clip.length);
    }
    private void PlayScoreSound(int score)
    {
        switch (score)
        {
            case 0:
                source.clip = fx_zero;
                break;
            case 1:
                source.clip = fx_fifteen;
                break;
            case 2:
                source.clip = fx_thirty;
                break;
            case 3:
                source.clip = fx_forty;
                break;
        }
        source.Play();
    }


   private IEnumerator GameText(int player)
    {
        scoreText.text = "GAME";
        source.clip = fx_victory;
        source.Play();
        yield return new WaitForSeconds(3);
        restart.SetActive(true);
        if (player==1){
            scoreText.text = "YOU WON";
            source.clip=fx_win;
            source.Play();
            yield return new WaitForSeconds(source.clip.length);
        }else if (player==2){
            scoreText.text = "YOU LOST";
            source.clip=fx_lose;
            source.Play();
            yield return new WaitForSeconds(source.clip.length);
        }
        
        yield return new WaitForSeconds(source.clip.length);
        //ResetScores();
    }

    public void ResetScores()
    {
        player1Score = 0;
        player2Score = 0;
        UpdateScoreText();
        isGameOn=true;
    }
}
