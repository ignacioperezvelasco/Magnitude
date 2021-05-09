using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RightRoomPlatform : MonoBehaviour
{
    public enum PlatformType
    {
        POSITIVE,
        NEGATIVE
    };

    public enum AxisMovement
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    };

    Vector3 initialPosition;
    Vector3 closedPosition;

    public PlatformType type;
    [SerializeField] AxisMovement axis;
    [SerializeField] float speed;
    float amountToMove = 6;
    bool active = true;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = this.transform.position;
                
        switch (axis)
        {
            case AxisMovement.LEFT:
                {
                    closedPosition = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z - amountToMove);
                    break;
                }

            case AxisMovement.RIGHT:
                {
                    closedPosition = new Vector3( initialPosition.x , initialPosition.y , initialPosition.z + amountToMove );
                    break;
                }
            case AxisMovement.UP:
                {
                    closedPosition = new Vector3( initialPosition.x - amountToMove , initialPosition.y , initialPosition.z );
                    break;
                }
            case AxisMovement.DOWN:
                {
                    closedPosition = new Vector3 ( initialPosition.x + amountToMove , initialPosition.y , initialPosition.z );
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    public void ChangePosition()
    {
        if (active)
        {
            active = false;

            this.transform.DOMove(closedPosition, speed).SetEase(Ease.InOutBack);
        }
        else
        {
            active = true;
            this.transform.DOMove(initialPosition, speed).SetEase(Ease.InOutBack);           
        }
    }
}
