using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu"); // Replace "MenuScene" with the actual name of your Menu scene
    }
}
