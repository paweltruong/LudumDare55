using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStandardController : SceneLogicController
{
    [SerializeField, Required] SceneLogicController LeftScene;
    [SerializeField, Required] SceneLogicController RightScene;

    [SerializeField] InteractableObject[] ObjectsVisibleAtStart;

    public const string AnimTrigger_MoveLeft = "MoveLeft";
    public const string AnimTrigger_MoveRight = "MoveRight";
    public const string AnimTrigger_FromLeft = "FromLeft";
    public const string AnimTrigger_FromRight = "FromRight";
    bool isTransitioning = true;

    public override void OnSceneEnter(bool fromLeft)
    {
        base.OnSceneEnter(fromLeft);

        if(fromLeft) 
        {
            animator.SetTrigger(AnimTrigger_FromLeft);
        }
        else
        {
            animator.SetTrigger(AnimTrigger_FromRight);
        }
    }

    public void ResetIsTransitioning()
    {
        isTransitioning = false;
    }

    public override void ResetSceneLogic()
    {
        base.ResetSceneLogic();

        foreach (var obj in ObjectsVisibleAtStart) 
        {
            obj.ResetItem();
        }
    }


    public void TriggerTravelLeft()
    {
        if (isTransitioning) return;

        animator.SetTrigger(AnimTrigger_MoveLeft);
        isTransitioning = true;
    }
    public void TriggerTravelRight()
    {
        if (isTransitioning) return;

        animator.SetTrigger(AnimTrigger_MoveRight);
        isTransitioning = true;
    }


    public void FadeIntoLeft()
    {
        FadeOut();
        Invoke(nameof(GoLeft), 1f);
    }

    public override void GoLeft()
    {
        base.GoLeft();

        isTransitioning = false;

        LeftScene.OnSceneEnter(false);

        gameObject.SetActive(false);
    }

    public void FadeIntoRight()
    {
        FadeOut();
        Invoke(nameof(GoRight), 1f);
    }

    public override void GoRight()
    {
        base.GoRight();
        isTransitioning = false;

        RightScene.OnSceneEnter(true);

        gameObject.SetActive(false);
    }
}
