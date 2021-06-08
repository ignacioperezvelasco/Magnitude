using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPositiveCharge : MonoBehaviour
{
    public GameObject BlackPanel;
    public GameObject CanvasPositiveCharge;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            BlackPanel.SetActive(true);
            CanvasPositiveCharge.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            BlackPanel.SetActive(false);
            CanvasPositiveCharge.SetActive(false);
        }
    }
}
