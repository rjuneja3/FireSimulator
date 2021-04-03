using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public GameObject burn;
    private MeshRenderer fireMeshRenderer;
    public int burnTime = 30;
    public bool otherOnFire = false;
    public bool onFire = false;
    public bool burnOthers = false;

    // Start is called before the first frame update
    void Start()
    {        
        fireMeshRenderer = this.GetComponent<MeshRenderer>();
        if (onFire == true)
        {
            Invoke("Prefire", burnTime/2);
        }        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void Prefire()
    {
        StartFire();
    }

    void StartFire()
    {
        fireMeshRenderer.enabled = true;
        Invoke("EndFire", burnTime);
        Invoke("Burn", burnTime/2);
    }

    void EndFire()
    {
        fireMeshRenderer.enabled = false;        
    }

    // Shows burn shader
    void Burn()
    {
        burn.SetActive(true);
        burnOthers = true;
    }

    public bool BurnOthersStatus()
    {
        return burnOthers;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Fire")
        {
            // checks if other is on fire
            if (otherOnFire = other.GetComponent<FireController>().BurnOthersStatus() == true && onFire == false)
            {
                onFire = true;
                Invoke("Prefire", burnTime/2);
            }
            //Debug.Log("Fire");
        }        
    }
}
