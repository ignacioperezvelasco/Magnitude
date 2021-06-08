using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTakeObjects : MonoBehaviour
{
    public GameObject BlackPanel;
    public GameObject CanvasTutorialTakeObjects;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            BlackPanel.SetActive(true);
            CanvasTutorialTakeObjects.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            BlackPanel.SetActive(false);
            CanvasTutorialTakeObjects.SetActive(false);
        }
    }
}
