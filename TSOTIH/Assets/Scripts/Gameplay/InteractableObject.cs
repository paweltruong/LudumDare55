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

    

    private void Awake()
    {
        outlineObject.SetActive(false);
    }

    private void OnMouseOver()
    {
        outlineObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        outlineObject.SetActive(false);
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
