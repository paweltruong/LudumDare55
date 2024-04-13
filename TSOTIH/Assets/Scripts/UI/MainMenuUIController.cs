using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
    [SerializeField, Required] GameObject imgBackground;
    [SerializeField, Required] GameObject txtTitle;
    [SerializeField, Required] GameObject goMenu;
    [SerializeField, Required] Button btnNewGame;

    private void Awake()
    {
        GameInstance.Instance.GameLogic.OnNewGameRequested.AddListener(GameLogic_OnNewGameRequested);

        btnNewGame.onClick.AddListener(BtnNewGame_OnClicked);
    }    

    void GameLogic_OnNewGameRequested()
    {
        imgBackground.SetActive(false);
        txtTitle.SetActive(false);
        goMenu.SetActive(false);
    }

    void BtnNewGame_OnClicked()
    {
        GameInstance.Instance.GameLogic.StartNewGame();
    }
}
