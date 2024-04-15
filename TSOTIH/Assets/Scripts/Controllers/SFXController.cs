using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : SingletonMonoBehaviour<SFXController>
{
    [SerializeField, Required] AudioClip AweSFX;

    AudioSource audioSource;



    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    public void PlayAwe()
    {
        audioSource.PlayOneShot(AweSFX);
    }
}
