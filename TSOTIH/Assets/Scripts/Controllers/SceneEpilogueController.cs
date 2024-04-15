using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEpilogueController : SceneLogicController
{
    [SerializeField, Required] SceneLogicController MainMenuScene;
    public override void ResetSceneLogic()
    {
        base.ResetSceneLogic();
    }

    public override void GoRight()
    {
        base.GoRight();

        MainMenuScene.ResetSceneLogic();
        MainMenuScene.OnSceneEnter(true);
        gameObject.SetActive(false);
        ResetSceneLogic(); 
    }
}
