using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Renderer feBullet = bullet.GetComponent<Renderer>();
            if (Input.GetMouseButton(0))
            {
                if (feBullet.enabled)
                {
                    feBullet.enabled = false;
                }
                else
                    feBullet.enabled = true;

            }
        }
    }
}
