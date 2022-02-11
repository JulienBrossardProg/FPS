using UnityEngine;

public class Pistol : Weapons
{
    public Pistol()
    {
        damage = 10;
        maxBullets = 15;
        currentBullets = maxBullets;
        name = "Pistol";
    }
}
