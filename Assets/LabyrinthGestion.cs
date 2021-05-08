using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthGestion : MonoBehaviour
{
    public WallGestion[] walls;

    [SerializeField] ImanBehavior myIman;
    iman currentPole;

    private void Start()
    {
        myIman.myPole = global::iman.POSITIVE;
        currentPole = global::iman.POSITIVE;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (currentPole != myIman.myPole)
        {
            currentPole = myIman.myPole;

            foreach (WallGestion wall in walls)
            {
                wall.ChangePositioon();
            }
        }
    }
}
