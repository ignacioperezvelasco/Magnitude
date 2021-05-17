using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class commands : MonoBehaviour
{
    public AudioSource audioData;
    [SerializeField] Animator fadeAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        PlayerPrefs.SetInt("CHECKPOINT", 0);
        //HAY QUE AÑADIR LA ESCENA AL BUILDEAR
        fadeAnimator.SetTrigger("Active");

        Invoke("LoadScene", 3);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void HoverSound()
    {
        audioData.Play(0);
    }

    public void PressSound()
    {
        audioData.Play(1);
    }
}
