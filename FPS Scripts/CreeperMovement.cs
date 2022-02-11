using UnityEngine;
using Random = UnityEngine.Random;

public class CreeperMovement : MonoBehaviour
{
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject pathPoint;
    private Vector2 randomPointOnCircle;
    private Rigidbody creeperRigidbody;
    [SerializeField] private float speed;
    public bool isCloseX;
    public bool isCloseZ;
    public bool isClosePlayerZ;
    public bool isClosePlayerX;
    [SerializeField] private GameObject player;
    [SerializeField] private float radiusDetection;
    [SerializeField] private bool isExplosing;
    [SerializeField] private CreeperExplosion creeperExplosion;
    public Animation anim;
    public AnimationClip creeperMovementAnim;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        spawner = GameObject.FindWithTag("Spawner");
    }

    void Start()
    {
        SpawnRandomPathPoint();
        creeperRigidbody = gameObject.GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (Mathf.Abs(transform.position.x - player.transform.position.x) > radiusDetection || Mathf.Abs(transform.position.z - player.transform.position.z) > radiusDetection)
        {
            if (Mathf.Abs(transform.position.x - pathPoint.transform.position.x) > 0.5f )
            {
                //creeperRigidbody.AddForce(Vector3.right*speed*Mathf.Sign((pathPoint.transform.position-transform.position).x));
                creeperRigidbody.velocity = new Vector3(speed*Mathf.Sign((pathPoint.transform.position-transform.position).x),creeperRigidbody.velocity.y,creeperRigidbody.velocity.z);
                transform.LookAt(pathPoint.transform);
                isCloseX = false;
            }
            else
            {
                isCloseX = true;
            }
            if (Mathf.Abs(transform.position.z - pathPoint.transform.position.z) > 0.5f)
            {
                //creeperRigidbody.AddForce(Vector3.forward*speed*Mathf.Sign((pathPoint.transform.position-transform.position).z));
                creeperRigidbody.velocity = new Vector3(creeperRigidbody.velocity.x,creeperRigidbody.velocity.y,speed*Mathf.Sign((pathPoint.transform.position-transform.position).z));
                transform.LookAt(pathPoint.transform);
                isCloseZ = false;
            }
            else
            {
                isCloseZ = true;
            }

            if (isCloseX && isCloseZ)
            {
                isCloseX = false;
                isCloseZ = false;
                Destroy(pathPoint);
                SpawnRandomPathPoint();
            }
        }
        else
        {
            if (Mathf.Abs(transform.position.x - player.transform.position.x) > 3 && !isExplosing)
            {
                //creeperRigidbody.AddForce(Vector3.right*speed*Mathf.Sign((player.transform.position-transform.position).x));
                creeperRigidbody.velocity = new Vector3(speed*Mathf.Sign((player.transform.position-transform.position).x),creeperRigidbody.velocity.y,creeperRigidbody.velocity.z);
                transform.LookAt(player.transform);
                isClosePlayerX = false;
            }
            else
            {
                isClosePlayerX = true;
            }
            if (Mathf.Abs(transform.position.z - player.transform.position.z) > 3 && !isExplosing)
            {
                //creeperRigidbody.AddForce(Vector3.forward*speed*Mathf.Sign((player.transform.position-transform.position).z));
                creeperRigidbody.velocity = new Vector3(creeperRigidbody.velocity.x,creeperRigidbody.velocity.y,speed*Mathf.Sign((player.transform.position-transform.position).z));
                transform.LookAt(player.transform);
                isClosePlayerZ = false;
            }
            else
            {
                isClosePlayerZ = true;
            }

            if (isClosePlayerX && isClosePlayerZ)
            {
                creeperRigidbody.velocity = new Vector3(0,creeperRigidbody.velocity.y,0);
                isExplosing = true;
                StartCoroutine(creeperExplosion.Explose());
            }
        }
    }

    void SpawnRandomPathPoint()
    {
        pathPoint = new GameObject();
        pathPoint.name = "pathPoint";
        randomPointOnCircle = Random.insideUnitCircle * CreeperSpawner.instance.spawnRange;
        pathPoint.transform.position = spawner.transform.position + new Vector3(randomPointOnCircle.x, -2.5f, randomPointOnCircle.y);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusDetection);
    }
    
}
