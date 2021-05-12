using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCentreManager : MonoBehaviour
{
    

    bool rightSwitchActivated;

    [Header("MANAGERS")] 
    [SerializeField] PlatformHandler[] platforms;
    [SerializeField] PlatformRighRoomManager rightRoomManager;
    [SerializeField] ElevatorLevel2 elevator;
    [SerializeField] DoorManager door;

    [Header("TURRET")]
    [SerializeField] TurretEnemy turret;
    [SerializeField] GameObject transitionDoor;
    bool transitionActivated = false;

    [Header("TO DEACTIVATE")]    
    [SerializeField] GameObject transitionRoom1_D;
    [SerializeField] GameObject transitionRoom2_D;
    [SerializeField] GameObject transitionRoom3_D;

    [Header("TO ACTIVATE")]
    [SerializeField] GameObject transitionRoom1_A;
    [SerializeField] GameObject transitionRoom2_A;
    [SerializeField] GameObject transitionRoom3_A;

    private void Update()
    {
        if (!turret.headActivate && !transitionActivated)
        {
            transitionActivated = true;
            transitionDoor.SetActive(true);

            //Cambiamos las transiciones de cámara
            transitionRoom1_D.SetActive(false);
            transitionRoom2_D.SetActive(false);
            transitionRoom3_D.SetActive(false);

            transitionRoom1_A.SetActive(true);
            transitionRoom2_A.SetActive(true);
            transitionRoom3_A.SetActive(true);
        }
    }

    public void ActivateSwitch(int _numswitch)
    {
        switch (_numswitch)
        {
            case 0:
                {

                    rightRoomManager.ActivateRoom();

                    foreach (PlatformHandler platform in platforms)
                    {
                        platform.isActivated = true;
                    }

                    break;
                }
            case 1:
                {
                    elevator.IsActivated = true;
                    break;
                }
            case 2:
                {
                    door.automaticActivated = true;
                    break;
                }
            default:
                break;
        }
    }
}
