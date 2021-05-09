using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PenduloManager : MonoBehaviour
{
    public ImanBehavior penduloIman;
    [SerializeField] Transform bridge;
    [SerializeField] float speedInitialMove;
    [SerializeField] float angleToRotate;
    bool moving = false;

    

    // Update is called once per frame
    void Update()
    {
        if (penduloIman.myPole == iman.NEGATIVE && !moving)
        {
            moving = true;
            float amountRotation = angleToRotate * penduloIman.GetCharges();

            this.transform.DORotate(new Vector3(amountRotation, 0, 0), speedInitialMove);
        }
    }
}
