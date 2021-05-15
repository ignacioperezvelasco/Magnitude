using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBridge : MonoBehaviour
{
    [SerializeField] BridgeManager bridgeManager;
    bool alreadyPressed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CanBeHitted"))
        {
            if (alreadyPressed == false)
            {
                bridgeManager.PressButton();
                alreadyPressed = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CanBeHitted"))
        {
            if (alreadyPressed == true)
            {
                bridgeManager.UnPressButton();
                alreadyPressed = false;
            }
        }
    }

}
