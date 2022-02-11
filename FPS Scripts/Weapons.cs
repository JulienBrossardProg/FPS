using UnityEngine;

public class Weapons
{
    public int damage;
    public int maxBullets;
    public int currentBullets;
    public string name;

    public Weapons()
    {
        damage = 10;
        maxBullets = 40;
        currentBullets = maxBullets;
        name = "weapon";
    }
    

    public void Recharge()
    {
        currentBullets = maxBullets;
    }
}
