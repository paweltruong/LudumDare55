using Newtonsoft.Json.Bson;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotUIController : MonoBehaviour
{
    internal ItemTypes ItemType = ItemTypes.None;
    [SerializeField, Required] GameObject ImgStick;
    [SerializeField, ReadOnly] internal int SlotIndex;
    [SerializeField, ReadOnly] internal string ItemName;
    [SerializeField, ReadOnly] internal string ItemDescription;
    [SerializeField] string EmptyItemSlotText = "Empty item slot";

    private void Awake()
    {
        UpdateDisplay();
        GameInstance.Instance.GameLogic.OnItemSlotChanged.AddListener(GameLogic_OnItemSlotChanged);
    }

    public void SetIndex(int index)
    {
        SlotIndex = index;
    }

    void UpdateDisplay()
    {
        switch (ItemType) 
        {
            case ItemTypes.Stick:
                ImgStick.SetActive(true);
                break;
            default:
                ImgStick.SetActive(false);
                break;
        }
    }

    public void SetItem(InteractableObject item)
    {
        ItemType = item.ItemType;
        ItemName = item.ItemName;
        ItemDescription = item.Description;
        UpdateDisplay();
        item.MarkAsCollected();
    }

    public void SetItem(ItemTypes itemType)
    {
        ItemType = itemType;
        ItemName = EmptyItemSlotText;
        ItemDescription = string.Empty;

    }
    
    void GameLogic_OnItemSlotChanged(int inSlotIndex, InteractableObject inItem)
    {
        if (inSlotIndex == SlotIndex)
        {
            if(inItem != null) 
            {
                SetItem(inItem);
            }
            else
            {
                SetItem(ItemTypes.None);
            }
        }
    }
}
