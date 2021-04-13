using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public int fuel;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        Renderer feBullet = bullet.GetComponent<Renderer>();
        feBullet.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Renderer feBullet = bullet.GetComponent<Renderer>();
        if (Input.GetKey(KeyCode.Mouse0) && fuel > 0)
        {
            // if (Input.GetMouseButton(0))
            // {
            //if (feBullet.enabled)
            //{
            //    feBullet.enabled = false;
            //}
            //else
            feBullet.enabled = true;
            fuel--;
        }
        else 
            feBullet.enabled = false;
        
    }
}
