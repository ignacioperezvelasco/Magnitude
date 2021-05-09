using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlatformRighRoomManager : MonoBehaviour
{
    
    [SerializeField] ImanBehavior imanObject;
    public RightRoomPlatform[] platforms;
    [SerializeField] Transform turretFloor;
    [SerializeField] TurretEnemy turret;
    iman currentPole;
    bool isActivated = false;

    private void Start()
    {
        currentPole = imanObject.myPole;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated)
        {
            if (currentPole != imanObject.myPole)
            {
                currentPole = imanObject.myPole;

                ChangePlatformPosition();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivateRoom();
        }
    }

    void ChangePlatformPosition()
    {
        foreach (RightRoomPlatform platform in platforms)
        {
            //Llamamos la funcion de cambiar de posicion
            platform.ChangePosition();
        }
    }

    void ActivatePlatforms()
    {
        foreach (RightRoomPlatform platform in platforms)
        {
            //Llamamos la funcion de cambiar de posicion
            if (platform.type == RightRoomPlatform.PlatformType.NEGATIVE)
            {
                platform.ChangePosition();
            }
        }
    }

    public void ActivateRoom()
    {
        turret.DeactivateTurretAnimation();
        turretFloor.DOMove( new Vector3(turretFloor.position.x, -100 ,turretFloor.position.z),3).SetEase(Ease.InCubic);

        isActivated = true;

        ActivatePlatforms();
    }
}
