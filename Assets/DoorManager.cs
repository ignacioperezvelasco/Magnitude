using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class DoorManager : MonoBehaviour
{
    enum DoorType
    {
        NORMAL,
        SLIDER
    };

    [SerializeField] DoorType doorType;
    public bool isActivated;

    [Header("LEFT DOOR")]
    [SerializeField] ImanBehavior leftIman;
    [SerializeField] Transform leftPivot;

    [Header("RIGHT DOOR")]
    [SerializeField] ImanBehavior rightIman;
    [SerializeField] Transform rightPivot;

    [Header("ANIMATION")]
    [SerializeField] float speedAnimation;
    [SerializeField] float angleToOpen;
    [SerializeField] float distanceToOpen;

    bool isMoving = false;
    bool opened = false;
    

    

    // Update is called once per frame
    void Update()
    {
        if (isActivated)
        {
            if (leftIman.myPole != iman.NONE && rightIman.myPole != iman.NONE)
            {
                switch (doorType)
                {
                    case DoorType.NORMAL:
                        {
                            //ABRIMOS LA PUERTA
                            if (leftIman.myPole == rightIman.myPole)
                            {
                                OpenDoor();
                            }
                            //CERRAMOS LA PUERTA
                            else if (leftIman.myPole != rightIman.myPole)
                            {
                                CloseDoor();
                            }
                            break;
                        }
                    case DoorType.SLIDER:
                        {
                            
                            if (leftIman.myPole == iman.NEGATIVE && rightIman.myPole == iman.POSITIVE)
                            {
                                if (!opened)
                                {
                                    opened = true;

                                    OpenDoor();
                                }
                            }
                                break;
                        }
                    default:
                        {
                            break;
                        }
                }
                

            }
        }
        
    }

    public void OpenDoor()
    {
        if (!isMoving)
        {
            isMoving = true;

            switch (doorType)
            {
                case DoorType.NORMAL:
                    {

                        rightPivot.DORotate(new Vector3(0, angleToOpen, 0), speedAnimation).SetEase(Ease.OutBounce);

                        leftPivot.DORotate(new Vector3(0, -angleToOpen, 0), speedAnimation).SetEase(Ease.OutBounce);

                        Invoke("StopMoving", speedAnimation);
                        break;
                    }
                case DoorType.SLIDER:
                    {
                        rightPivot.DOMove(new Vector3(rightPivot.position.x + distanceToOpen, rightPivot.position.y, rightPivot.position.z), speedAnimation).SetEase(Ease.OutBounce);

                        leftPivot.DOMove(new Vector3(leftPivot.position.x - distanceToOpen, leftPivot.position.y, leftPivot.position.z), speedAnimation).SetEase(Ease.OutBounce);

                        Invoke("StopMoving", speedAnimation);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            
        }
       
    }

    public void CloseDoor()
    {
        if (!isMoving)
        {
            isMoving = true;

            rightPivot.DORotate(new Vector3(0, 0, 0), speedAnimation).SetEase(Ease.OutBounce);

            leftPivot.DORotate(new Vector3(0, 0, 0), speedAnimation).SetEase(Ease.OutBounce);

            Invoke("StopMoving", speedAnimation);
        }

            
    }


    void StopMoving()
    {
        isMoving = false;
    }
}
