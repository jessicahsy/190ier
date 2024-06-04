using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class sceneswitcher2 : MonoBehaviour
{
    public string hi;

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
