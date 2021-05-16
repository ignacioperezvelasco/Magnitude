using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadLastScreen : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke("LoadScene", 3);
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
           
    }
}
