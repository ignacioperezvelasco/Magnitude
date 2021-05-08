using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthGestion : MonoBehaviour
{
    public WallGestion[] walls;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (WallGestion wall in walls)
            {
                wall.ChangePositioon();
            }
        }
    }
}
