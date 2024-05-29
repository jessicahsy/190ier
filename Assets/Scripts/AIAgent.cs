using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAgent : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] audioClips;

    private int currentClipIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (audioClips.Length > 0)
        {
            // Start playing the first audio clip
            StartCoroutine(PlayAudioClipsSequentially());
        }
    }

    IEnumerator PlayAudioClipsSequentially()
    {
        while (currentClipIndex < audioClips.Length)
        {
            source.clip = audioClips[currentClipIndex];
            source.Play();

            // Wait until the current clip finishes playing
            yield return new WaitForSeconds(source.clip.length);

            currentClipIndex++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
