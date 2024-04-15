using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField, Required] GameObject outlineObject;
    [SerializeField] internal string ItemName;
    [SerializeField] internal string Description;
    [SerializeField,Required] internal ItemTypes ItemType;
    [SerializeField, Required] internal bool availableForPickup = true;

    

    private void Awake()
    {
        outlineObject.SetActive(false);
    }

    private void OnMouseOver()
    {
        outlineObject.SetActive(true);
        GameInstance.Instance.GameLogic.UpdateTooltip(String.Format("{0} - {1}", ItemName, Description));
    }

    private void OnMouseExit()
    {
        outlineObject.SetActive(false);
        GameInstance.Instance.GameLogic.UpdateTooltip(string.Empty);
    }

    private void OnMouseUp()
    {
        GameInstance.Instance.GameLogic.NotifyIteracted(this);
    }

    internal void MarkAsCollected()
    {
        this.gameObject.SetActive(false);
    }

    public void ResetItem()
    {
        this.gameObject.SetActive(true);
    }
}
