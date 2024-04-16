using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class SceneLogicController : MonoBehaviour
{
    [SerializeField, Required] ActorCharacterController girl1;
    [SerializeField, Required] ActorCharacterController girl2;
    [SerializeField, Required] ActorCharacterController grandpa;
    [SerializeField, Required] CanvasGroup sceneFader;
    [SerializeField, Required] protected Animator animator;
    [SerializeField, Required] internal bool bShowItems;

    [SerializeField, Required] internal bool CanUseNut = false;
    [SerializeField, Required] internal bool CanUseStick = false;

    public const string AnimTrigger_FadeOut = "FadeOut";

    public UnityEvent OnLeftRequested = new UnityEvent();
    public UnityEvent OnRightRequested = new UnityEvent();

    public UnityEvent OnUseNut = new UnityEvent();
    public UnityEvent OnUseStick = new UnityEvent();



    internal bool TryUseNut()
    {
        if (!CanUseNut) return false;

        OnUseNut.Invoke();
        return true;
    }

    internal bool TryUseStick()
    {
        if (!CanUseStick) return false;

        OnUseStick.Invoke();
        return true;
    }


    public virtual void ResetSceneLogic()
    {
        
    }

    public virtual void OnSceneEnter(bool fromLeft)
    {
        gameObject.SetActive(true);
        GameInstance.Instance.GameLogic.UpdateActiveScene(this);
        
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
        if (grandpa == null)
        {
            Debug.LogWarning("No grandpa in the scene");
            return;
        }
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

