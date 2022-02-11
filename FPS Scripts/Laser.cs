using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public static float maxDistance = 100;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private List<Vector3> points = new List<Vector3>();
    public static Vector3 direction = Vector3.forward;
    void Update()
    {
        points.Clear();
        points.Add(transform.position + Vector3.left*0.2f + Vector3.down*0.2f);
        DoRay(transform.position + Vector3.left*0.2f + Vector3.down*0.2f, direction);
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
    }

    void DoRay(Vector3 origin, Vector3 direction )
    {
        RaycastHit hit;

        if (Physics.Raycast(origin, direction, out hit, maxDistance)) 
        {
            Debug.DrawRay(origin, direction*hit.distance, Color.green);
            points.Add(hit.point);
        }
        else
        {
            points.Add(origin + direction*maxDistance);
            Debug.DrawRay(origin, direction, Color.red);
        } 
    }
}
