using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    public int fuel;
    public int fuelTotal;
    public Text fuelText;
    public Text fuelTotalText;
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
        fuelText.text = fuel.ToString("0");
        fuelTotalText.text = "/" + fuelTotal.ToString("0");
        if (fuel <= 1500 && fuel >= 500)
        {
            fuelText.color = Color.yellow;
        }
        if (fuel <= 500)
        {
            fuelText.color = Color.red;
        }
    }
}
