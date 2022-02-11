using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapons
{
    public Shotgun()
    {
        damage = 10;
        maxBullets = 8;
        currentBullets = maxBullets;
        name = "Shotgun";
    }
}
