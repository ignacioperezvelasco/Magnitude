using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class countdown : MonoBehaviour
{
    // Start is called before the first frame update

    public float targetTime = 8.0f;
    [SerializeField] Animator fadeAnimator;

    // Update is called once per frame


    private void Start()
    {
        Invoke("FadeOut", targetTime-5f);

        Invoke("timerEnded", targetTime);
    }

    void FadeOut()
    {
        fadeAnimator.SetTrigger("Active");
    }

    void timerEnded()
    {
        SceneManager.LoadScene("MainMenuCorrect");
    }
}
