using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemie : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Elemental")
        {
            other.GetComponent<Enemy>().life = 0;
        }
    }
}
