using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePrologueController : SceneLogicController
{
    const string AnimTrigger_ShowTitle = "ShowTitle";

    bool _titleIsShowing = false;

    public override void ResetSceneLogic()
    {
        base.ResetSceneLogic();

        _titleIsShowing = false;
    }

    public void SkipIntro()
    {
        if(_titleIsShowing) return;

        FadeOut();
        ShowTitle();
        Invoke(nameof(GoRight), 2f);
    }

    public void ShowTitle()
    {
        if (_titleIsShowing) return;
        animator.SetTrigger(AnimTrigger_ShowTitle);
        SFXController.Instance.PlayAwe();
        _titleIsShowing = true;
    }

    private void Start()
    {
        OnSceneEnter(true);
    }
}
