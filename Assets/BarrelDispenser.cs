using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BarrelDispenser : MonoBehaviour
{
    bool isActive = false;
    [Header("SPAWNERS")]
    [SerializeField] Transform openPosition;
    [SerializeField] Transform closePosition;
    [SerializeField] Transform spawner;
    [SerializeField] Transform finalBarrelPosition;

    [Header("ELEMENTS")]
    [SerializeField] Transform top;
    [SerializeField] GameObject barrel;


    [Header("ELEMENTS")]
    [SerializeField] float topSpeed;
    [SerializeField] float spawnSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float jumpTime;

    GameObject auxGO;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isActive)
        {
            isActive = true;
            OpenTop();
        }
    }

    void OpenTop()
    {
        top.DOMove(openPosition.position, topSpeed);

        auxGO =  Instantiate(barrel, spawner.position, spawner.rotation) as GameObject;

        Invoke("LaunchBarrel", topSpeed);
    }

    void LaunchBarrel()
    {
        auxGO.transform.DOJump(finalBarrelPosition.position, jumpForce, 1, jumpTime).SetEase(Ease.OutExpo);
        auxGO.transform.Rotate(new Vector3(Random.Range(0,359), Random.Range(0, 359), Random.Range(0, 359)), jumpTime);

        Invoke("CloseTop", jumpTime/2);
    }


    void CloseTop()
    {
        top.DOMove(closePosition.position, topSpeed);

        Invoke("Finish", topSpeed);
    }

    void Finish()
    {
        isActive = false;
        auxGO = null;
    }
}
