using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDash : MonoBehaviour
{
    public GameObject BlackPanel;
    public GameObject CanvasTutorialDash;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            BlackPanel.SetActive(true);
            CanvasTutorialDash.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            BlackPanel.SetActive(false);
            CanvasTutorialDash.SetActive(false);
        }
    }
}
