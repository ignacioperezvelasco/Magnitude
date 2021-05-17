using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour
{
    [SerializeField]string newScene;
    [SerializeField] Animator fadeAnimator;

    StopAudioSources stopAudios;

    private void Start()
    {
        stopAudios = GameObject.FindGameObjectWithTag("StopAudio").GetComponent<StopAudioSources>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            fadeAnimator.SetTrigger("Active");

            Invoke("LoadScene", 4);
        }
    }

    void LoadScene()
    {
        stopAudios.StopAllAudio();
        SceneManager.LoadScene(newScene);
    }
}
