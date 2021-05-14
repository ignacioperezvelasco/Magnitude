using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RoomDownManager : MonoBehaviour
{
    [Header("PLATFORM")]
    [SerializeField] Transform platform;
    [SerializeField] float speedAnimation;
    [SerializeField] Transform finalPosition;

    [Header("ENEMIES")]
    [SerializeField] Enemy enemy_ONE;
    [SerializeField] Enemy enemy_TWO;

    bool enemiesDead = false;

    // Update is called once per frame
    void Update()
    {
        if (enemy_ONE.life <= 0 && enemy_TWO.life <= 0  && !enemiesDead)
        {
            enemiesDead = true;

            platform.DOMove(finalPosition.position, speedAnimation).SetEase(Ease.InOutBack);
        }
    }
}
