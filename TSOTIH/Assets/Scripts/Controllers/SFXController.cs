using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : SingletonMonoBehaviour<SFXController>
{
    [SerializeField, Required] AudioClip AweSFX;
    [SerializeField, Required] AudioClip PickUpSFX;


    AudioSource audioSource;



    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    public void PlayAwe()
    {
        audioSource.PlayOneShot(AweSFX);
    }
    public void PlayPickup()
    {
        audioSource.PlayOneShot(PickUpSFX);
    }
}
