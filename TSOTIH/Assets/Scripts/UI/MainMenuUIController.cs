using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
    [SerializeField, Required] GameObject goCredits;
    [SerializeField, Required] Button btnNewGame;
    [SerializeField, Required] Button btnIntro;
    [SerializeField, Required] Button btnCredits;
    [SerializeField, Required] Button btnBackToMenu;

    private void Awake()
    {
        GameInstance.Instance.GameLogic.OnNewGameRequested.AddListener(GameLogic_OnNewGameRequested);

        btnNewGame.onClick.AddListener(BtnNewGame_OnClicked);
    }    

    void GameLogic_OnNewGameRequested()
    {

    }

    void BtnNewGame_OnClicked()
    {
        GameInstance.Instance.GameLogic.StartNewGame();
    }
}
