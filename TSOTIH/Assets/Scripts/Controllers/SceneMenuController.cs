using Newtonsoft.Json.Bson;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMenuController : SceneLogicController
{
    [SerializeField, Required] ScenePrologueController prologueScene;
    [SerializeField, Required] SceneLogicController startLevelScene;
    const string AnimTrigger_ShowMenu = "ShowMenu";
    const string AnimTrigger_ShowCredits = "ShowCredits";

    public override void ResetSceneLogic()
    {
        base.ResetSceneLogic();

    }

    public void ShowMenu()
    {
        animator.SetTrigger(AnimTrigger_ShowMenu);
    }

    public void ShowCredits()
    {
        animator.SetTrigger(AnimTrigger_ShowCredits);
    }

    public void HideCredits()
    {
        animator.SetTrigger(AnimTrigger_ShowMenu);
    }

    public void NewGameRequested()
    {
        FadeOut();
        Invoke(nameof(GoRight), 1f);
    }

    public void IntroRequested()
    {
        
        FadeOut();
        Invoke(nameof(GoLeft), 1f);
    }

    public override void GoLeft()
    {
        base.GoLeft();

        prologueScene.ResetSceneLogic();
        prologueScene.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
