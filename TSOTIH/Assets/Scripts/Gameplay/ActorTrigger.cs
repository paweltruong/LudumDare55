using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ActorTrigger : MonoBehaviour
{
    public UnityEvent OnTriggerClicked;

    [SerializeField] string TravelAllowedDescription;
    [SerializeField] string TravelBlockedDescription;
    [SerializeField] ItemTypes RequiredItem = ItemTypes.None;


    private void OnMouseOver()
    {
        if (RequiredItem == ItemTypes.None || GameInstance.Instance.GameState.HasItem(RequiredItem))
        {
            GameInstance.Instance.GameLogic.UpdateTooltip(TravelAllowedDescription);
        }
        else
        {
            GameInstance.Instance.GameLogic.UpdateTooltip(TravelBlockedDescription);
        }
    }

    private void OnMouseExit()
    {
        GameInstance.Instance.GameLogic.UpdateTooltip(string.Empty);
    }


    private void OnMouseUp()
    {
        Debug.Log(name + " clicked");
        OnTriggerClicked.Invoke();
        GameInstance.Instance.GameLogic.UpdateTooltip(string.Empty);
    }
}
