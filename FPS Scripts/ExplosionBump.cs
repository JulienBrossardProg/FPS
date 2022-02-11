using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExplosionBump : MonoBehaviour
{
    public bool isExplose;
    [SerializeField] private Vector3 distance;
    [SerializeField] private float explosionForce;
    [SerializeField] private float distanceForce;

    private void OnTriggerStay(Collider other)
    {
        if (isExplose)
        {
            distance = other.gameObject.transform.position - gameObject.transform.position;
            distanceForce = distance.x + distance.y + distance.z;
            if (distanceForce<0)
            {
                distanceForce = -distanceForce;
            }
            
            other.gameObject.GetComponent<Rigidbody>().AddForce(distance*explosionForce*1/distanceForce);
        }
    }
}
