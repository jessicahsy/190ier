using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmInteraction : MonoBehaviour
{
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
