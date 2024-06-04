using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public AudioSource source;
    public AudioClip fx_start;
    public GameObject restartButton;
    public ScoreManager scoreManager;

    void Start()
    {
        restartButton.SetActive(false);
    }

    public void OnButtonClick()
    {
        ScoreManager.isGameOn = true;
        scoreManager.ResetScores();
        restartButton.SetActive(false);
        source.clip=fx_start;
        source.Play();
        
    }
}
