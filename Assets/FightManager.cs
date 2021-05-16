using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightManager : MonoBehaviour
{
    [SerializeField] BossLogic boss;

    [SerializeField] GameObject HUD;
    [SerializeField] GameObject lastMessage;

    [Header("TIMES")]
    [SerializeField] float timeToShowMessage = 5;
    [SerializeField] float timeDisplayingMessage = 15;

    [SerializeField] Animator fadeAnimator;

    
    void Update()
    {
        if (boss.isKilled)
        {
            Invoke("DisplayMessage", timeToShowMessage);
        }    
    }

    void DisplayMessage()
    {
        fadeAnimator.SetTrigger("Active");

        Invoke("GoToLevel2", timeDisplayingMessage);
    }

    void GoToLevel2()
    {
        SceneManager.LoadScene("Level_2");
    }
}
