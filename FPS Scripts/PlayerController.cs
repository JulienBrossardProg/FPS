using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpPower = 1;
    private Rigidbody rb;
    [SerializeField] private bool grounded = false;
    [SerializeField] private float rayDistance = 0.75f;
    [SerializeField] private LayerMask layers;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        GroundDetection();
        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            }
        }
        
    }

    void GroundDetection()
    {
        RaycastHit hit;
        Vector3 origin = transform.position;
        Vector3 dir = Vector3.down;
        
        

        if (Physics.Raycast(origin,dir,out hit,rayDistance,layers))
        {
            grounded = true;
            Debug.DrawRay(origin, dir * hit.distance, Color.blue);
        }

        else
        {
            grounded = false;
            Debug.DrawRay(origin, dir * rayDistance, Color.red);
        }
    }
}
