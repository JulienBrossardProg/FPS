using UnityEngine;

public class RocketExplosion : MonoBehaviour
{
    public bool isExplose;
    [SerializeField] private Vector3 distance;
    [SerializeField] private float explosionForce;
    [SerializeField] private float distanceForce;

    private void OnTriggerStay(Collider other)
    {
        if (isExplose && (other.gameObject.CompareTag("Player") ||  other.gameObject.CompareTag("Creeper") || other.gameObject.CompareTag("Block")))
        {
            distance = other.gameObject.transform.position - gameObject.transform.position;
            distanceForce = distance.x + distance.y + distance.z;
            if (distanceForce<0)
            {
                distanceForce = -distanceForce;
            }
            other.gameObject.GetComponent<Rigidbody>().AddForce(distance*explosionForce*1/distanceForce);
            isExplose = false;
        }
    }
}
