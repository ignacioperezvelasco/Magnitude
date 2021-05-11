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
