using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MenuInteraction : MonoBehaviour
{
    public GameObject confirmCube;
    public GameObject resumeCube;
    public GameObject initialMenuCube;

    public void OnMenuSelect()
    {
        confirmCube.SetActive(true);
        resumeCube.SetActive(true);
        initialMenuCube.SetActive(false);
    }
}
