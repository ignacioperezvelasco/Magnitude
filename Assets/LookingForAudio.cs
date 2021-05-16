using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingForAudio : MonoBehaviour
{
    AudioSource[] go;
    // Start is called before the first frame update
    void Start()
    {
        go = FindObjectsOfType<AudioSource>();

        foreach (AudioSource item in go)
        {
            Debug.Log( "AUDIOSOURCE --->   " + item.gameObject.name);
        }
    }

    
}
