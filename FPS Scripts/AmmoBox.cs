using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour, iUsable
{
    public Animation anim;
    public static AmmoBox instance;

    private void Awake()
    {
        instance = this;
    }

    void PlayAnim()
    {
        anim.Play();
    }


    public void Use()
    {
        PlayAnim();
    }
}
