using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public float range;
    public LayerMask layermask;
    public Transform startpoint;
    public bool canHitSomething;
    public Vector3 hitPosition;
    public GameObject hitParticles;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;


        if (Physics.Raycast(startpoint.position, startpoint.forward, out hit, range, layermask))
        {
            canHitSomething = true;
            hitPosition = hit.point;
        }
        else
        {
            canHitSomething = false;
        }

        if (Input.GetMouseButtonDown(0) && canHitSomething)
        {
            Instantiate(hitParticles, hitPosition, hitParticles.transform.rotation);
        }


    }
}
