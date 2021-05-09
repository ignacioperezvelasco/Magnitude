using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WallGestion : MonoBehaviour
{
    public enum WallType
    {
        POSITIVE,
        NEGATIVE
    };

    enum Position
    {
        UP,
        DOWN
    };

    public WallType type;

    float speedTransition = 0.25f;
    Position position;

    private void Start()
    {
        if (type == WallType.POSITIVE)
        {
            position = Position.UP;

            this.transform.position =new Vector3(this.transform.position.x, 1.5f, this.transform.position.z);
        }
        else
        {
            position = Position.DOWN;

            this.transform.position = new Vector3(this.transform.position.x, -1.5f, this.transform.position.z);
        }
    }


    public void ChangePositioon()
    {
        if (position == Position.UP)
        {
            position = Position.DOWN;

            Vector3 newPositon = new Vector3(this.transform.position.x, -1.5f, this.transform.position.z);
            this.transform.DOMove( newPositon, speedTransition);
        }
        else
        {
            position = Position.UP;

            Vector3 newPositon = new Vector3(this.transform.position.x, 1.5f, this.transform.position.z);
            this.transform.DOMove(newPositon, speedTransition);
        }
    }
}
