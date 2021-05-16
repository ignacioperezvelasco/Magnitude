using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour
{
    [SerializeField]string newScene;
    [SerializeField] Animator fadeAnimator;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            fadeAnimator.SetTrigger("Active");

            Invoke("LoadScene", 3);
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(newScene);
    }
}
