using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ElevatorLevel2 : MonoBehaviour
{
    enum Position
    {
        UP,
        DOWN
    };

    public float elevatorSpeed;
    public bool IsActivated = false;
    bool isMoving = false;
    bool exitWhileMoving = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GoUp();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GoDown();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsActivated)
        {
            if (other.CompareTag("Player"))
            {
                other.transform.SetParent(this.transform);
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (IsActivated)
        {
            if (other.CompareTag("Player"))
            {

                other.transform.SetParent(null);
            }
        }
        
    }

    void GoUp()
    {
        this.transform.DOMove(new Vector3(this.transform.position.x, 0 , this.transform.position.z) , elevatorSpeed).SetEase(Ease.InOutBack);
    }

    void GoDown()
    {
        this.transform.DOMove(new Vector3(this.transform.position.x, -25, this.transform.position.z), elevatorSpeed).SetEase(Ease.InOutBack);
    }
}
