using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using System.Collections;

public class menucontroller_scene : MonoBehaviour
{
    public AudioSource MusicAudio;
    public AudioSource FXAudio;
    public AudioClip open_music;
    public AudioClip fx_hover;
    public AudioClip fx_click;
    public AudioClip enter_game;

    private XRBaseInteractable interactable;

    void Start()
    {
        MusicAudio.clip = open_music;
        MusicAudio.loop = true;
        MusicAudio.Play();

        interactable = GetComponent<XRBaseInteractable>();

        interactable.hoverEntered.AddListener(OnHoverEnter);
        interactable.selectEntered.AddListener(OnSelectEnter);
    }

    void OnDestroy()
    {
        // Remove event listeners to avoid memory leaks
        interactable.hoverEntered.RemoveListener(OnHoverEnter);
        interactable.selectEntered.RemoveListener(OnSelectEnter);
    }

    private void OnHoverEnter(HoverEnterEventArgs args)
    {
        //FX_HOVER
        FXAudio.clip = fx_hover;
        FXAudio.Play();
    }

    private void OnSelectEnter(SelectEnterEventArgs args)
    {
        //click sounds and switch scene
        StartCoroutine(OnButtonClick());
    }

    private IEnumerator OnButtonClick()
    {
        FXAudio.clip = fx_click;
        FXAudio.Play();
        yield return new WaitForSeconds(FXAudio.clip.length);

        FXAudio.clip = enter_game;
        FXAudio.Play();
        yield return new WaitForSeconds(FXAudio.clip.length);

        SceneManager.LoadScene("Tennis");
    }
}
