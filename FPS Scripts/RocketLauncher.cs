using UnityEngine;
public class RocketLauncher : Weapons
{
    public RocketLauncher()
    {
        damage = 100;
        maxBullets = 1;
        currentBullets = maxBullets;
        name = "Rocket Launcher";
    }
}
