using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class countdown : MonoBehaviour
{
    // Start is called before the first frame update

    public float targetTime = 5.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f)
        {
            timerEnded();
        }
    }

    void timerEnded()
    {
        SceneManager.LoadScene("MainMenuCorrect");
    }
}
