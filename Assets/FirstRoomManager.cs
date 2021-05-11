using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstRoomManager : MonoBehaviour
{
    [SerializeField] DoorManager doorManager;
    [SerializeField] Enemy enemy;

    [Header("DOOR MAGNETS")]
    [SerializeField] GameObject leftFakeIman;
    [SerializeField] GameObject leftRealIman;
    [SerializeField] GameObject rightFakeIman;
    [SerializeField] GameObject rightRealIman;



    
    // Update is called once per frame
    void Update()
    {
        if (enemy.life <= 0)
        {
            //Desactivamos los imanes falsos
            leftFakeIman.SetActive(false);
            rightFakeIman.SetActive(false);

            //Activamos los imanes reales
            leftRealIman.SetActive(true);
            rightRealIman.SetActive(true);

            //Activamos la puerta
            doorManager.isActivated = true;
        }
    }
}
