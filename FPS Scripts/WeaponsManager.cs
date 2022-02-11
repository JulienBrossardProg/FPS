using System.Collections;
using TMPro;
using UnityEngine;


public class WeaponsManager : MonoBehaviour
{
    [SerializeField] private Shoot shoot;
    public int currentWeaponIteration;
    private Weapons currentWeapon;
    public Weapons[] weapon;
    [SerializeField] private TMP_Text weaponText;
    [SerializeField] private TMP_Text bulletText;
    [SerializeField] private bool isRecharge;
    public static WeaponsManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        weapon = new Weapons[4];
        weapon[0] = new Pistol();
        weapon[1] = new AK47();
        weapon[2] = new RocketLauncher();
        weapon[3] = new Shotgun();
        currentWeaponIteration = 0;
        currentWeapon = weapon[currentWeaponIteration];
        weaponText.text = currentWeapon.name;
        bulletText.text = currentWeapon.currentBullets + "/" + currentWeapon.maxBullets;
        shoot.weaponName = currentWeapon.name;
    }

    private void Update()
    {
        ChangeWeapon();
        UpdateWeapon();
    }

    void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isRecharge = false;
            currentWeaponIteration++;
            if (currentWeaponIteration >weapon.Length-1)
            {
                currentWeaponIteration = 0;
                currentWeapon = weapon[currentWeaponIteration];
                weaponText.text = currentWeapon.name;
                shoot.weaponName = currentWeapon.name;
            }
            else
            {
                currentWeapon = weapon[currentWeaponIteration];
                weaponText.text = currentWeapon.name;
                shoot.weaponName = currentWeapon.name;
            }
            if (currentWeapon.currentBullets>0)
            {
                shoot.isCanShoot = true;
            }
        }
    }

    void UpdateWeapon()
    {
        bulletText.text = currentWeapon.currentBullets + "/" + currentWeapon.maxBullets;
        if (shoot.isShoot)
        {
            currentWeapon.currentBullets--;
        }
        
        if (AmmoBox.instance.anim.isPlaying == true)
        {
            StartCoroutine("Recharge");
        }

        if (currentWeapon.currentBullets<1 || isRecharge )
        {
            shoot.isCanShoot = false;
        }
    }

    IEnumerator Recharge()
    {
        isRecharge = true;
        shoot.isCanShoot = false;
        GunRecharge.instance.PlayAnim();
        yield return new WaitForSeconds(3);
        currentWeapon.Recharge();
        shoot.isCanShoot = true;
        isRecharge = false;
        StopAllCoroutines();
    }
}
