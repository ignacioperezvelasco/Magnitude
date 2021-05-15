using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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


    [Header("CAMERAS TRANSITION")]
    [SerializeField] GameObject toDeactivate;
    [SerializeField] GameObject toActivate;

    [SerializeField] GameObject rightLight;
    [SerializeField] GameObject leftLight;
    [SerializeField] GameObject downLight;

    [SerializeField] GameObject elevatorLight;

    [Header("CINEMATIC CAMERAS")]
    [SerializeField] Animator fadeAnimator;
    [SerializeField] GameObject doorCamera;
    [SerializeField] GameObject leftRoomCamera;
    [SerializeField] GameObject elevatorCamera;

    bool isPlayerInside = false;
    bool isActivated = false;

    rvMovementPers player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<rvMovementPers>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerInside && !isActivated)
        {
            isActivated = true;

            centerManager.ActivateSwitch((int)type);
            if (type == SwitchType.RIGHT)
            {
                toDeactivate.SetActive(false);
                toActivate.SetActive(true);

                

                this.transform.DOMove(new Vector3(  this.transform.position.x,
                                                    this.transform.position.y,
                                                    this.transform.position.z + 1),0.75f).SetEase(Ease.InOutBack);

                player.StopMovement();

                ActivateFade();

                Invoke("ActivateCameraDoor", 1.25f);
                Invoke("ActivateLight", 3f);

            }
            else if (type == SwitchType.LEFT)
            {
                player.StopMovement();

                this.transform.DOMove(new Vector3(this.transform.position.x - 1,
                                                    this.transform.position.y,
                                                    this.transform.position.z ), 0.75f).SetEase(Ease.InOutBack);

                ActivateFade();

                Invoke("ActivateCameraDoor", 1.25f);
                Invoke("ActivateLight", 3f);
            }

        }
    }


    void ActivateFade()
    {
        fadeAnimator.SetTrigger("Active");
    }

    void ActivateLight()
    {
        switch (type)
        {
            case SwitchType.RIGHT:
                {
                    rightLight.SetActive(true);
                    break;
                }
            case SwitchType.LEFT:
                {
                    leftLight.SetActive(true);
                    break;
                }
            case SwitchType.DOWN:
                {
                    downLight.SetActive(true);
                    break;
                }
            default:
                break;
        }
    }

    void ActivateCameraDoor()
    {
        doorCamera.SetActive(true);

        if (type == SwitchType.RIGHT)
        {

            Invoke("ActivateFade", 3.5f);
            Invoke("ActivateCameraLeftRoom", 4.5f);
        }
        else if (type == SwitchType.LEFT)
        {

            Invoke("ActivateFade", 3);
            Invoke("ActivateCameraElevator", 4f);
        }
    }

    void DeactivateCameraDoor()
    {
        doorCamera.SetActive(false);
    }

    void ActivateCameraLeftRoom()
    {
        DeactivateCameraDoor();
        leftRoomCamera.SetActive(true);

        Invoke("ActivateFade", 2f);
        Invoke("DeactivateCameraLeftRoom", 3);
    }

    void DeactivateCameraLeftRoom()

    {
        leftRoomCamera.SetActive(false);
        player.ResumeMovement();
    }

    void ActivateCameraElevator()
    {
        DeactivateCameraDoor();
        elevatorCamera.SetActive(true);

        Invoke("ActivateElevatorLight", 1.5f);
        Invoke("ActivateFade", 2.5f);
        Invoke("DeactivateCameraElevator", 4f);


    }

    void DeactivateCameraElevator()
    {
        elevatorCamera.SetActive(false);
        player.ResumeMovement();
    }

    void ActivateElevatorLight()
    {
        elevatorLight.SetActive(true);
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
