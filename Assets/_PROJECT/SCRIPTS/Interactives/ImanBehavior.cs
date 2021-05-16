﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum mobilityType { MOBILE, STATIC, NONE, SEMIMOVIBLE, JUSTPOLE };
public enum iman { POSITIVE, NEGATIVE, NONE };
public enum forceType { ATRACT, REPULSE, NONE };


public class ImanBehavior : MonoBehaviour
{
    [SerializeField] private List<GameObject> nearImantableObjects;

    [Header("CHECKING CHARGES")]
    [SerializeField] SphereCollider mysphereCollider;
    public Transform aimHere;
    [Header("ELEMENT TYPE")]
    public mobilityType mobility = mobilityType.NONE;
    public bool alwaysSamePole=false;
    public iman myPole = iman.NONE;
    public LayerMask whatCanBeImanted;
    private Rigidbody myRB;
    public bool creaCarga = true;
    

    [Header("FORCES")]
    [SerializeField] float force = 15;
    [SerializeField] float forceBase = 25;
    [SerializeField] float timerImanted = 8f;
    [SerializeField] float timerActive = 3f;
    [SerializeField] float timeImanted = 8f;
    [SerializeField] float timeActive = 3f;
    public float sizeSphereOneCharge = 7;
    public float sizeSphereTwoCharge = 9;
    public float sizeSphereThreeCharge = 16;
    bool applyForce = false;
    Vector3 directionForce;
    Collider[] others;
    GameObject otherGO;
    forceType myForceType = forceType.NONE;
    [SerializeField]int numChargesAdded = 0;
    // Start is called before the first frame update
    public bool imEnemy = false;
    private NavMeshAgent myNavMeshScript;
    //OUTLINE
    public Outline outline;

    //Explosion
    bool hasToExplote = false;
    int otherCharges = 0;
    Vector3 midlePoint = new Vector3(0, 0, 0);
    [SerializeField] float explosionForce = 1500;
    [SerializeField] GameObject explosionVFX;
    [SerializeField] Enemy myEnemyScript;

    private void Awake()
    {
        //OUTLINE SET
        outline = this.GetComponent<Outline>();
        outline.enabled = false;
    }

    void Start()
    {
        myRB = this.GetComponent<Rigidbody>();

        if (mobility != mobilityType.JUSTPOLE)
        {
            //mysphereCollider = this.GetComponentInChildren<SphereCollider>();
            mysphereCollider.radius = 0.5f;
        }
        else
        {            
            switch (numChargesAdded)
            {
                case 1:
                    mysphereCollider.enabled = true;
                    mysphereCollider.radius = sizeSphereOneCharge;
                    break;
                case 2:
                    mysphereCollider.enabled = true;
                    mysphereCollider.radius = sizeSphereTwoCharge;
                    break;
                case 3:
                    mysphereCollider.enabled = true;
                    mysphereCollider.radius = sizeSphereThreeCharge;
                    break;
                default:
                    break;
            }
            if (myPole != iman.NONE)
            {
                ActivateOutline(myPole);
            }
        }

        if (imEnemy)
        {
            myNavMeshScript = this.GetComponent<NavMeshAgent>();
        }

        nearImantableObjects = new List<GameObject>();
        timerActive = timeActive;
        timerImanted = timeImanted;

    }

    private void Update()
    {
        if (mobility != mobilityType.JUSTPOLE)
        {
            //if (myPole != iman.NONE)
                
        }
    }

    private void FixedUpdate()
    {
        if (mobility != mobilityType.JUSTPOLE)
        {
            CalculateDirectionForce();
            if (myPole != iman.NONE)
            {
                if (applyForce && mobility == mobilityType.MOBILE)
                {
                    //Debug.Log("ha de palicart la fuerza : " + directionForce * force);
                    myRB.AddForce(directionForce * force, ForceMode.Force);
                    directionForce = new Vector3(0, 0, 0);
                    timerActive -= Time.fixedDeltaTime;
                    if (timerActive <= 0)
                    {
                        if (hasToExplote)
                            Explode();
                        ResetObject();
                    }
                }
                else
                    timerImanted -= Time.fixedDeltaTime;
                if (timerImanted <= 0)
                    ResetObject();
            }
        }
    }

    #region UPDATING ELEMENTS NEAR
    private void OnTriggerEnter(Collider other)
    {
        if (mobility == mobilityType.MOBILE || mobility == mobilityType.STATIC)
        {
            if (myPole != iman.NONE)
            {
                if (other.gameObject.transform.parent != null)
                {
                    if ((other.gameObject.layer == 9) && (other.gameObject.transform.parent.GetComponent<ImanBehavior>().myPole!=iman.NONE))
                        if (!nearImantableObjects.Contains(other.gameObject.transform.parent.gameObject))
                        {
                            if (other.gameObject.transform.parent.GetComponent<ImanBehavior>().creaCarga)
                                    nearImantableObjects.Add(other.gameObject.transform.parent.gameObject);
                        }
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (mobility == mobilityType.MOBILE || mobility == mobilityType.STATIC)
        {
            if (myPole != iman.NONE)
            {
                if (other.gameObject.transform.parent != null)
                {
                    if ((other.gameObject.layer == 9) && (other.gameObject.transform.parent.GetComponent<ImanBehavior>().myPole != iman.NONE))
                        if (!nearImantableObjects.Contains(other.gameObject.transform.parent.gameObject))
                        {
                            if (other.gameObject.transform.parent.GetComponent<ImanBehavior>().creaCarga)
                                    nearImantableObjects.Add(other.gameObject.transform.parent.gameObject);
                        }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (mobility == mobilityType.MOBILE || mobility == mobilityType.STATIC)
        {
            if (other.gameObject.layer == 9)
            {
                if (myPole != iman.NONE)
                    nearImantableObjects.Remove(other.gameObject.transform.parent.gameObject);
            }
        }
    }
    #endregion

    #region HANDLEEXPLOSION
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "CanBeHitted")
        {
            if ((mobility != mobilityType.JUSTPOLE) && (collision.collider.GetComponent<ImanBehavior>().mobility != mobilityType.JUSTPOLE))
            {
                if ((collision.collider.GetComponent<ImanBehavior>().myPole != iman.NONE))
                {
                    if (!imEnemy)
                        timerActive = 0;
                    if (myPole == iman.POSITIVE)
                    {
                        hasToExplote = true;
                        midlePoint = (collision.collider.transform.position + this.transform.position) / 2;
                        Debug.Log("HA entrado explsion");
                    }
                    otherCharges = collision.collider.GetComponent<ImanBehavior>().GetCharges();
                    if (imEnemy)
                        Explode();
                }
            }
        }
    }
    
    void Explode()
    {        
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, (otherCharges + numChargesAdded + 5));
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                
                rb.AddExplosionForce((otherCharges + numChargesAdded) * explosionForce, midlePoint, (otherCharges + numChargesAdded + 5),1,ForceMode.Force);

                if (myPole==iman.POSITIVE)
                    Instantiate(explosionVFX, midlePoint, Quaternion.identity);
            }
        }
        if (imEnemy)
        {
            //Daño a enemigo
            myEnemyScript.GetDamage(otherCharges + numChargesAdded);
            Invoke("ResetObject",0.5f);
        }
        hasToExplote = false;
    }
    #endregion

    #region calculate Forces

    void CalculateDirectionForce()
    {
        bool hay = false;
        foreach (GameObject obj in nearImantableObjects)
        {
            //comprobamos q se tenga q calcular
            if (obj.GetComponent<ImanBehavior>().myPole != iman.NONE)
            {
                if (obj.GetComponent<ImanBehavior>().myPole == myPole)
                {
                    //Repulsion
                    directionForce += CalculateOneForce(this.gameObject, obj, forceType.REPULSE);
                }
                else if (obj.GetComponent<ImanBehavior>().myPole != myPole)
                {
                    //atraccion
                    directionForce += CalculateOneForce(this.gameObject, obj, forceType.ATRACT);
                }
                hay = true;
            }
        }
        if (hay)
        {
            applyForce = true;
            if (imEnemy)
            {
                myNavMeshScript.enabled = false;
                myRB.isKinematic = false;
            }
        }
    }

    private Vector3 CalculateOneForce(GameObject myGO, GameObject otherGO, forceType typeOfForce)
    {
        Vector3 finalForce = new Vector3(0, 0, 0);
        //Suma de cargas
        float numChargesSum = (numChargesAdded + otherGO.GetComponent<ImanBehavior>().numChargesAdded) * 2f;

        switch (typeOfForce)
        {
            case forceType.ATRACT:
                finalForce = CalculateVectorAB(myGO.transform.position, otherGO.transform.position);
                break;
            case forceType.REPULSE:
                finalForce = CalculateVectorAB(otherGO.transform.position, myGO.transform.position);
                break;
            case forceType.NONE:
                break;
            default:
                break;
        }
        float invertedDistance = (1f / finalForce.magnitude);

        float factor = ((invertedDistance * numChargesSum * force) - 8.5f) / 25.5f;

        finalForce = finalForce.normalized * (forceBase + (forceBase * factor));
        //Debug.Log(finalForce);

        return finalForce;
    }

    private Vector3 CalculateVectorAB(Vector3 A, Vector3 B)
    {
        Vector3 result = new Vector3(B.x - A.x, B.y - A.y, B.z - A.z);
        return result;
    }

    #endregion

    public void AddCharge(iman typeIman, int numCharge, Rigidbody bullet)
    {
        if ((numCharge >= 1) && !alwaysSamePole)
        {
            //Activamos Outline
            ActivateOutline(typeIman);            

            if (mobility != mobilityType.JUSTPOLE)
            {

                numChargesAdded = numCharge;

                //En caso de tener los radius hardcoded aqui. SINO Cambiarlo a las dos lineas del switch
                switch (numCharge)
                {
                    case 1:
                        mysphereCollider.enabled = true;
                        mysphereCollider.radius = sizeSphereOneCharge;
                        break;
                    case 2:
                        mysphereCollider.enabled = true;
                        mysphereCollider.radius = sizeSphereTwoCharge;
                        break;
                    case 3:
                        mysphereCollider.enabled = true;
                        mysphereCollider.radius = sizeSphereThreeCharge;
                        break;
                    default:
                        break;
                }
                //Reset timers
                timerActive = timeActive;
                timerImanted = timeImanted;
            }
        }
        else
        {
            //Behavior if is no charge bullet
            myRB.AddForce(bullet.velocity.normalized * 10, ForceMode.Impulse);
        }
    }

    void ActivateOutline(iman type)
    {
        //Primero asignamos polo para que no haya problemas en otra parte del codigo
        if (type == iman.POSITIVE)
        {
            myPole = iman.POSITIVE;
            outline.OutlineColor = new Color32(255, 0, 0, 255);
        }
        else
        {
            myPole = iman.NEGATIVE;
            outline.OutlineColor = new Color32(0, 0, 255, 255);
        }

        //ACTIVAMOS SCRIPT OUTLINE
        outline.enabled = true;
    }


    #region GETTERS

    public bool GetApplyForce()
    {
        return applyForce;
    }

    public int GetCharges()
    {
        return numChargesAdded;
    }



    #endregion

    public void ResetObject()
    {
        this.gameObject.tag = "CanBeHitted";
        nearImantableObjects.Clear();
        myPole = iman.NONE;
        applyForce = false;
        timerActive = timeActive;
        timerImanted = timeImanted;
        mysphereCollider.radius = 0.5f;
        mysphereCollider.enabled = false;
        if (imEnemy)
        {
            myNavMeshScript.enabled = true;
            myRB.isKinematic = true;
        }
        //OUTLINE
        outline.OutlineColor = new Color32(0, 0, 0, 0);
        outline.enabled = false;
    }
}