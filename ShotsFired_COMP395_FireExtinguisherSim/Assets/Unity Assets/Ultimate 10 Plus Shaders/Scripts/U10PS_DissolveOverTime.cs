using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class U10PS_DissolveOverTime : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    public float speed = .5f;

    private void Start()
    {
        meshRenderer = this.GetComponent<MeshRenderer>();
    }

    private float t = 20.0f;
    private void Update()
    {
        Material[] mats = meshRenderer.materials;


        if (Mathf.Sin(t * speed) < 0)
        {
            t = 20.0f;
        }

        //Debug.Log(Mathf.Sin(t * speed));
        //Debug.Log(t);

        mats[0].SetFloat("_Cutoff", Mathf.Sin(t * speed));
        t += Time.deltaTime;

        // Unity does not allow meshRenderer.materials[0]...
        meshRenderer.materials = mats;
    }
}
