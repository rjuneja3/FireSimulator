using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectFireController : MonoBehaviour
{
    //public GameObject burn;
    public Material fireMaterial;
    public Material burntMaterial;
    //private MeshRenderer fireMeshRenderer;
    //private Collider fireCollider;

    public int timeToExtinguishFire = 300;
    public int timeExtinguishingFire;
    public int burnTime = 15;
    public bool otherOnFire = false;
    public bool onFire = false;
    public bool burnOthers = false;
    public bool isExtinguished = false;
    public bool isExtinguishing = false;

    public Text timeToExtinguishTxt;
    public Text timeExtinguishingTxt;
    public Text objectNameTxt;


    // Start is called before the first frame update
    void Start()
    {
        //fireMeshRenderer = this.GetComponent<MeshRenderer>();
        //fireCollider = this.GetComponent<Collider>();
        if (onFire == true)
        {
            StartFire();
        }
    }

    // Fire
    void StartFire()
    {
        if (isExtinguished == false)
        {
            this.GetComponent<MeshRenderer>().material = fireMaterial;
            //fireMeshRenderer.enabled = true;
            Invoke("EndFire", burnTime);
            Invoke("Burn", burnTime / 2);
        }
    }

    void EndFire()
    {
        isExtinguished = true;
        onFire = false;
        burnOthers = false;
        this.GetComponent<MeshRenderer>().material = burntMaterial;
        this.GetComponent<MeshCollider>().enabled = false;
        //fireMeshRenderer.enabled = false;      
        //fireCollider.enabled = false;
    }

    // Shows burn shader
    void Burn()
    {
        if (isExtinguished == false)
        {
            //burn.SetActive(true);
            burnOthers = true;
        }
    }

    public bool BurnOthersStatus()
    {
        return burnOthers;
    }

    public void FireExtinguished()
    {
        isExtinguished = true;
        onFire = false;
        burnOthers = false;
        this.GetComponent<MeshRenderer>().material = burntMaterial;
        this.GetComponent<MeshCollider>().enabled = false;
        //burn.GetComponent<U10PS_DissolveOverTime>().enabled = false;
        //burn.GetComponent<MeshRenderer>().material = burntMaterial;
        //burn.SetActive(true);
        //fireMeshRenderer.enabled = false;
        //fireCollider.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Fire")
        {
            // checks if other is on fire
            if (otherOnFire = other.GetComponent<FireController>().BurnOthersStatus() == true && onFire == false && isExtinguished == false && isExtinguishing == false)
            {
                onFire = true;
                StartFire();
            }
        }

        if (other.tag == "ObjectFire")
        {
            if (otherOnFire = other.GetComponent<ObjectFireController>().BurnOthersStatus() == true && onFire == false && isExtinguished == false && isExtinguishing == false)
            {
                onFire = true;
                StartFire();
            }
        }

        if (other.tag == "FE")
        {   
            isExtinguishing = true;
            objectNameTxt.text = gameObject.name;
            timeToExtinguishTxt.text = timeToExtinguishFire.ToString();
            if (timeExtinguishingFire >= timeToExtinguishFire && onFire == true && isExtinguished == false)
            {
                FireExtinguished();
            }
            else if (timeExtinguishingFire < timeToExtinguishFire && onFire == true && isExtinguished == false)
            {
                timeExtinguishingFire++;
                timeExtinguishingTxt.text = timeExtinguishingFire.ToString();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "FE")
        {
            isExtinguishing = false;
        }
    }
}
