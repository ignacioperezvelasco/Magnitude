using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportHandler : MonoBehaviour
{

    [SerializeField] Transform TP_01;
    [SerializeField] Transform TP_02;
    [SerializeField] Transform TP_03;
    [SerializeField] Transform TP_04;
    [SerializeField] Transform TP_05;
    [SerializeField] Transform TP_06;

    Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            player.position = TP_01.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player.position = TP_02.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            player.position = TP_03.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            player.position = TP_04.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            player.position = TP_05.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            player.position = TP_06.position;
        }

    }
}
