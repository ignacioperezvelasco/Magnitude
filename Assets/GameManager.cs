﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] Transform initialCheckpoint;

    [Header("CHECK POINTS")]
    [SerializeField] Transform checkPoint_1;
    [SerializeField] Transform checkPoint_2;
    [SerializeField] Transform checkPoint_3;
    [SerializeField] Transform checkPoint_4;
    Transform player;
    #endregion

    #region AWAKE
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        switch (PlayerPrefs.GetInt("CHECKPOINT"))
        {
            case 0:
                player.transform.position = initialCheckpoint.transform.position;
                break;
            case 1:
                player.transform.position = checkPoint_1.transform.position;
                break;
            case 2:
                player.transform.position = checkPoint_2.transform.position;
                break;
            case 3:
                player.transform.position = checkPoint_3.transform.position;
                break;
            case 4:
                player.transform.position = checkPoint_4.transform.position;    
                break;
            case 5:
                player.transform.position = initialCheckpoint.transform.position;
                break;
            default:
                break;
        }
        
    }
    #endregion
    
    #region UPDATE
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            player.transform.position = initialCheckpoint.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            player.transform.position = checkPoint_1.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player.transform.position = checkPoint_2.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            player.transform.position = checkPoint_3.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            player.transform.position = checkPoint_4.position;
        }
    }
    #endregion

}
