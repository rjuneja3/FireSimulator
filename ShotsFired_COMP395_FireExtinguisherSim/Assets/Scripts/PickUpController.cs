using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public GunScript gunScript;
    public Rigidbody rigidbody;
    public BoxCollider boxCollider;

    //Declare transform
    public Transform player, gunContainer, fpscam;

    //Declare pick up varibles
    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    //Declare Gun Component
    private Vector3 scaleChange;
    private Vector3 positionChange;
    private Vector3 rotationChange;



    // Start is called before the first frame update
    void Start()
    {
        // setup 
        if (!equipped)
        {
            gunScript.enabled = false;
            rigidbody.isKinematic = false;
            boxCollider.isTrigger = false;
        }
        if (equipped)
        {
            gunScript.enabled = true;
            rigidbody.isKinematic = true;
            boxCollider.isTrigger = true;
            slotFull = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Check if player is in range and "E" is pressed
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
        {
            PickUp();
        }

        //Check if gun is equipped and "G" is pressed
        if ( equipped && Input.GetKeyDown(KeyCode.G))
        {
            Drop();
        }
            
    }
    private void PickUp()
    {
        equipped = true;
        slotFull = true;
        rigidbody.isKinematic = true;
        boxCollider.isTrigger = true;
        //Make weapon a child of the camera and move it to the determined position
        transform.SetParent(gunContainer);
        scaleChange = new Vector3(0.05f, 0.05f, 0.05f);
        positionChange = new Vector3(0.018225f, 0.004499644f, 1.024f);
        rotationChange = new Vector3(-39.191f, -90f, 90f);
        transform.localPosition = positionChange;
        transform.localRotation = Quaternion.Euler(rotationChange);
        transform.localScale = scaleChange;
        //Enable gun script
        gunScript.enabled = true;
    }
    private void Drop()
    {
        equipped = false;
        slotFull = false;
        //Set parent to null
        transform.SetParent(null);

        rigidbody.isKinematic = false;
        boxCollider.isTrigger = false;

        //Take momentum of player
        rigidbody.velocity = player.GetComponent<Rigidbody>().velocity;
        //Adding force 
        rigidbody.AddForce(fpscam.forward * dropForwardForce, ForceMode.Impulse);
        rigidbody.AddForce(fpscam.up * dropUpwardForce, ForceMode.Impulse);
        float random = Random.Range(-1f, 1f);
        rigidbody.AddTorque(new Vector3(random, random, random) * 10);
        gunScript.enabled = false;
    }
}
