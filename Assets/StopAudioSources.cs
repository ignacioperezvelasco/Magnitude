using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAudioSources : MonoBehaviour
{
    private AudioSource[] audioSources;

    private void Awake()
    {
        audioSources = GameObject.FindObjectsOfType(typeof( AudioSource)) as AudioSource[];
    }

    public void StopAllAudio()
    {
        foreach (AudioSource  audioS in audioSources)
        {
            audioS.Stop();
        }
    }
}
