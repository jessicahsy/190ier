using UnityEngine;

public class ResumeInteraction : MonoBehaviour
{
    public GameObject confirmCube;
    public GameObject resumeCube;
    public GameObject initialMenuCube;

    public void OnResumeSelect()
    {
        confirmCube.SetActive(false);
        resumeCube.SetActive(false);
        initialMenuCube.SetActive(true);
    }
}
