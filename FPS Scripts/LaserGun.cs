using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    [SerializeField] private float maxDistance = 100;
    [SerializeField] private int maxBounce = 20;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private List<Vector3> points = new List<Vector3>();
    void Update()
    {
        points.Clear();
        points.Add(transform.position);
        DoRay(transform.position, transform.right, maxBounce);
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
    }

    void DoRay(Vector3 origin, Vector3 direction, int bounceLeft)
    {
        if (bounceLeft>0)
        {
            RaycastHit hit;

            if (Physics.Raycast(origin, direction, out hit, maxDistance)) 
            {

                Debug.Log(bounceLeft);
                
                if (bounceLeft>1)
                {
                    Debug.DrawRay(origin, direction*hit.distance, Color.green);
                    points.Add(hit.point);
                }

                else
                {
                    Debug.DrawRay(origin, direction*hit.distance, Color.magenta);
                }
                
                bounceLeft--;
                
                DoRay(hit.point, Vector3.Reflect(direction, hit.normal), bounceLeft);
            }


            else
            {
                points.Add(origin + direction*maxDistance);
                Debug.DrawRay(origin, direction, Color.red);
            } 
        }
    }
}
