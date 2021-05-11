using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLevel2 : MonoBehaviour
{
    public enum SwitchType
    {
        RIGHT,
        LEFT,
        DOWN
    };

    [SerializeField] RoomCentreManager centerManager;
    [SerializeField] SwitchType type;

    bool isPlayerInside = false;
    bool isActivated = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerInside && !isActivated)
        {
            isActivated = true;

            centerManager.ActivateSwitch((int)type);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
        }
    }
}
