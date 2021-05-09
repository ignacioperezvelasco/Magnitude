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
    [SerializeField] float speedBridgeFalling;
    bool moving = false;
    bool isImanted = false;
    

    // Update is called once per frame
    void Update()
    {
        if (penduloIman.myPole == iman.NEGATIVE && !moving && !isImanted)
        {
            isImanted = true;
            moving = true;
            float amountRotation = angleToRotate * penduloIman.GetCharges();

            var sequence = DOTween.Sequence();

            this.transform.DORotate(new Vector3(amountRotation, 0, 0), speedInitialMove).SetEase(Ease.OutCubic);

            Invoke("GoRight", speedInitialMove);
        }

        if (isImanted && penduloIman.myPole == iman.NONE)
        {
            isImanted = false;
        }
    }

    void GoRight()
    {
        float amountRotation = angleToRotate * penduloIman.GetCharges();

        this.transform.DORotate(new Vector3(-amountRotation, 0, 0), speedInitialMove*1.5f).SetEase(Ease.InBack);

        Invoke("StopPenduloMovement", speedInitialMove * 1.5f);

    }

    void StopPenduloMovement()
    {
        this.transform.DORotate(new Vector3(0, 0, 0), speedInitialMove).SetEase(Ease.OutCubic);
        moving = false;

        if (penduloIman.GetCharges() == 3)
        {
            bridge.DORotate(new Vector3(0, 0, 0), speedBridgeFalling).SetEase(Ease.OutBounce);
        }
    }
}
