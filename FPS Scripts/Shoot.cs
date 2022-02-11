using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bulletParent;
    public float bulletSpeed;
    public bool isShoot;
    public bool isCanShoot = true;
    public string weaponName;
    [SerializeField] private GameObject lastBullet;
    [SerializeField] private float timeShoot;

    private void Start()
    {
        bulletParent = new GameObject();
        bulletParent.name = "Bullet Parent";
    }

    void Update()
    {
        Fire();
    }
    

    void Fire()
    {
        if (Input.GetButton("Fire1") && isCanShoot && WeaponsManager.instance.weapon[WeaponsManager.instance.currentWeaponIteration].currentBullets>0)
        {
            if (weaponName == "Ak47")
            {
                lastBullet = Pooler.instance.Pop("Bullet");
                lastBullet.transform.position = transform.position;
                //lastBullet = Instantiate(bullet, transform.position, quaternion.identity, bulletParent.transform);
                lastBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
                isShoot = true;
                timeShoot = 0.2f;
                StartCoroutine(WaitShoot());
            }
        }
        
        else if (Input.GetButtonUp("Fire1") && isCanShoot)
        {
            if (weaponName == "Pistol")
            {
                lastBullet = Pooler.instance.Pop("Bullet");
                lastBullet.transform.position = transform.position;
                //lastBullet = Instantiate(bullet, transform.position, quaternion.identity, bulletParent.transform);
                lastBullet.GetComponent<Rigidbody>().AddForce(transform.forward* bulletSpeed);
                isShoot = true;
            }
        
            else if (weaponName == "Rocket Launcher")
            {
                Debug.Log("rocket");
                lastBullet = Pooler.instance.Pop("Bullet");
                lastBullet.transform.position = transform.position;
                //lastBullet = Instantiate(bullet, transform.position, quaternion.identity, bulletParent.transform);
                lastBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
                lastBullet.tag = "Rocket";
                isShoot = true;
            }
        
            else if (weaponName == "Shotgun")
            {

                for (int i = 0; i < 8; i++)
                {
                    lastBullet = Pooler.instance.Pop("Bullet");
                    lastBullet.transform.position = transform.position;
                    //lastBullet = Instantiate(bullet, transform.position, quaternion.identity, bulletParent.transform);
                    lastBullet.GetComponent<Rigidbody>().AddForce( (transform.forward + transform.right*Random.Range(-0.1f,0.1f) + transform.up*Random.Range(-0.1f,0.1f)) * bulletSpeed);
                    isShoot = true;
                }
            }
        }
        else
        {
            isShoot = false;
        }
    }

        IEnumerator WaitShoot()
        {
            isCanShoot = false;
            yield return new WaitForSeconds(timeShoot);
            isCanShoot = true;
        }
}