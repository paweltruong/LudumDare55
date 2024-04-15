using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorCharacterController : MonoBehaviour
{
    [SerializeField, Required] Animator animator;


    const string AnimParam_IsWalking = "IsWalking";
    const string AnimTrigger_Pickup = "Pickup";
    const string AnimTrigger_Smile = "Smile";
    const string AnimTrigger_Sad = "Sad";
    const string AnimTrigger_Speak = "Speak";

    public void StartWalking()
    {
        animator.SetBool(AnimParam_IsWalking, true);
    }

    public void StopWalking()
    {
        animator.SetBool(AnimParam_IsWalking, false);
    }

    public void TriggerPickup()
    {
        animator.SetTrigger(AnimTrigger_Pickup);
    }
    public void TriggerSmile()
    {
        animator.SetTrigger(AnimTrigger_Smile);
    }
    public void TriggerSad()
    {
        animator.SetTrigger(AnimTrigger_Sad);
    }
    public void TriggerSpeak()
    {
        animator.SetTrigger(AnimTrigger_Speak);
    }

}
