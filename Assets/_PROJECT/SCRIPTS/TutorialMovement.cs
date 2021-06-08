using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMovement : MonoBehaviour
{
    public GameObject BlackPanel;
    public GameObject CanvasTutorialMovement;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            BlackPanel.SetActive(true);
            CanvasTutorialMovement.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            BlackPanel.SetActive(false);
            CanvasTutorialMovement.SetActive(false);
        }
    }
}
