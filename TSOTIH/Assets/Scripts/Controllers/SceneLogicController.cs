﻿using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class SceneLogicController : MonoBehaviour
{
    [SerializeField, Required] ActorCharacterController girl1;
    [SerializeField, Required] ActorCharacterController girl2;
    [SerializeField, Required] ActorCharacterController grandpa;
    [SerializeField, Required] CanvasGroup sceneFader;
    [SerializeField, Required] protected Animator animator;

    public const string AnimTrigger_FadeOut = "FadeOut";

    public UnityEvent OnLeftRequested = new UnityEvent();
    public UnityEvent OnRightRequested = new UnityEvent();


    public virtual void ResetSceneLogic()
    {
        
    }

    public void Girl1_StartWalking()
    {
        girl1.StartWalking();
    }
    public void Girl1_StopWalking()
    {
        girl1.StopWalking();
    }
    public void Girl2_StartWalking()
    {
        girl2.StartWalking();
    }
    public void Girl2_StopWalking()
    {
        girl2.StopWalking();
    }
    public void Grandpa_StartWalking()
    {
        grandpa.StartWalking();
    }
    public void Grandpa_StopWalking()
    {
        grandpa.StopWalking();
    }
    public void Grandpa_Pickup()
    {
        grandpa.TriggerPickup();
    }
    public void Grandpa_Smile()
    {
        grandpa.TriggerSmile();
    }
    public void Grandpa_Sad()
    {
        grandpa.TriggerSad();
    }
    public void Grandpa_Speak()
    {
        grandpa.TriggerSpeak();
    }

    public void FadeOut()
    {
        animator.SetTrigger(AnimTrigger_FadeOut);
    }

    public virtual void GoLeft()
    {
        OnLeftRequested.Invoke();
    }

    public virtual void GoRight()
    {
        OnRightRequested.Invoke();
    }
}

