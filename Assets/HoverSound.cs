using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HoverSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip fx_hover;
    public AudioClip fx_click;

    private void Start()
    {
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(OnHoverEnter);
        interactable.selectEntered.AddListener(OnSelectEnter);
    }

    private void OnDestroy()
    {
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.RemoveListener(OnHoverEnter);
        interactable.selectEntered.RemoveListener(OnSelectEnter);
    }

    private void OnHoverEnter(HoverEnterEventArgs args)
    {
        audioSource.clip = fx_hover;
        audioSource.Play();
    }

    private void OnSelectEnter(SelectEnterEventArgs args)
    {
        audioSource.clip = fx_click;
        audioSource.Play();
    }
}
