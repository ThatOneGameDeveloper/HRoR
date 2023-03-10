using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public float range;
    public LayerMask layerMask;
    public Transform startPoint;
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

        if(Input.GetMouseButtonDown(0) && canHitSomething)
        {
            Instantiate(hitParticles, hitPosition, hitParticles.transform.rotation);
        }


        if(Physics.Raycast(startPoint.position, startPoint.forward, out hit, range, layerMask))
        {
            canHitSomething = true;
            hitPosition = hit.point;
        }
        else
        {
            canHitSomething = false;
        }
    }
}
