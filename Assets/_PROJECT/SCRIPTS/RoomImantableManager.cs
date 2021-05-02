﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomImantableManager : MonoBehaviour
{
    #region VARIABLES
    public Animator animator;

    [Header("IMANTABLES")]
    public ImanBehavior iman1;
    public ImanBehavior iman2;
    public ImanBehavior iman3;
    public ImanBehavior iman4;
    public ImanBehavior iman5;
    public ImanBehavior iman6;
    bool imanActive1;
    bool imanActive2;
    bool imanActive3;
    bool imanActive4;
    bool imanActive5;
    bool imanActive6;
    bool isOpen = false;
    #endregion

    #region VARIABLES
    void Update()
    {
        if (!isOpen)
        {
            //IMAN 1
            if (iman1.myPole == iman.NEGATIVE || iman1.myPole == iman.POSITIVE)
            {
                imanActive1 = true;
            }
            //IMAN 2
            if (iman2.myPole == iman.NEGATIVE || iman2.myPole == iman.POSITIVE)
            {
                imanActive2 = true;
            }
            //IMAN 3
            if (iman3.myPole == iman.NEGATIVE || iman3.myPole == iman.POSITIVE)
            {
                imanActive3 = true;
            }
            //IMAN 4
            if (iman4.myPole == iman.NEGATIVE || iman4.myPole == iman.POSITIVE)
            {
                imanActive4 = true;
            }
            //IMAN 5
            if (iman5.myPole == iman.NEGATIVE || iman5.myPole == iman.POSITIVE)
            {
                imanActive5 = true;
            }
            //IMAN 6
            if (iman6.myPole == iman.NEGATIVE || iman6.myPole == iman.POSITIVE)
            {
                imanActive6 = true;
            }


            //COMPROBAMOS SI ABRIMOS LA PUERTA
            if (imanActive1 && imanActive2 && imanActive3 && imanActive4 && imanActive5 && imanActive6)
            {
                isOpen = true;
                animator.SetBool("Active", true);
            }
        }       

    }
    #endregion
}
