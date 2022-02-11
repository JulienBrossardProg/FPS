using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRecharge : MonoBehaviour
{
    public Animation anim;
    public static GunRecharge instance;

    private void Awake()
    {
        instance = this;
    }

    public void PlayAnim()
    {
        anim.Play();
    }
}
