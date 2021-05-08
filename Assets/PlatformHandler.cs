using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlatformHandler : MonoBehaviour
{
    public bool isActivated;
    public float movementY_UP;
    public float movementY_DOWN;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (isActivated)
        {
            isActivated = false;
            GoUp();
        }
    }

    void GoUp()
    {
        Vector3 newPositon = new Vector3(this.transform.position.x, movementY_UP, this.transform.position.z);

        this.transform.DOMove(newPositon, speed);

        Invoke("GoDown", speed);
    }

    void GoDown()
    {
        Vector3 newPositon = new Vector3(this.transform.position.x, movementY_DOWN, this.transform.position.z);

        this.transform.DOMove(newPositon, speed);

        Invoke("GoUp", speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(this.transform);
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}
