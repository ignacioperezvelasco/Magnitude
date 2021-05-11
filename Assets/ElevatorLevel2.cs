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

    [Header("DEBUG")]
    public bool isMoving = false;
    public bool exitWhileMoving = false;
    [SerializeField] Position postion = Position.UP;


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

                if (!isMoving)
                {
                    isMoving = true;

                    switch (postion)
                    {
                        case Position.UP:
                            {
                                GoDown();
                                break;
                            }
                        case Position.DOWN:
                            {
                                GoUp();
                                break;
                            }
                        default:
                            break;
                    }
                }

            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {

        if (IsActivated)
        {
            if (other.CompareTag("Player"))
            {
                if (isMoving)
                {
                    exitWhileMoving = true;
                }

                other.transform.SetParent(null);
            }
        }
        
    }

    void GoUp()
    {
        postion = Position.UP;
        this.transform.DOMove(new Vector3(this.transform.position.x, 0 , this.transform.position.z) , elevatorSpeed).SetEase(Ease.InQuint);

        Invoke("DeactivateMoving", elevatorSpeed);
    }

    void GoDown()
    {
        postion = Position.DOWN;
        this.transform.DOMove(new Vector3(this.transform.position.x, -25, this.transform.position.z), elevatorSpeed).SetEase(Ease.InQuint);

        Invoke("DeactivateMoving", elevatorSpeed);
    }

    void DeactivateMoving()
    {
        if (exitWhileMoving)
        {
            exitWhileMoving = false;

            switch (postion)
            {
                case Position.DOWN:
                    {
                        GoUp();
                        break;
                    }
                case Position.UP:
                    {
                        GoDown();
                        break;
                    }
                default:
                    break;
            }
        }
        else
        {
            switch (postion)
            {
                case Position.UP:
                    {
                        isMoving = false;
                        break;
                    }
                case Position.DOWN:
                    {
                        isMoving = false;
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
