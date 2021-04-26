using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource grappoUseSource;
    public AudioClip grappoUseClip;
    public static SoundManager instance;

    private void Awake()
    {
        instance = this;
    }
    

    public void UseGrappo()
    {
        grappoUseSource.clip = grappoUseClip;
        grappoUseSource.Play();
    }
}
