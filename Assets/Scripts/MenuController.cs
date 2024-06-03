using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject startCanvas;
    public GameObject scoreboardCanvas;
    // Start is called before the first frame update
    void Start()
    {
        startCanvas.SetActive(true);
        scoreboardCanvas.SetActive(false);
    }

    public void StartGame() {
        startCanvas.SetActive(false);
        scoreboardCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
