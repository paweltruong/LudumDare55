using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TooltipController : MonoBehaviour
{
    [SerializeField, Required] TextMeshProUGUI txtTooltip;

    private void Awake()
    {
        GameInstance.Instance.GameLogic.OnTooltipRequested.AddListener(GameLogic_OnTooltipRequested);
    }

    void GameLogic_OnTooltipRequested(string text)
    {
        txtTooltip.text = text;
    }
}
