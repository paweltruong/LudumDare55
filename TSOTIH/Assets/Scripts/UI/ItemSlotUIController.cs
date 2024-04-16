using Newtonsoft.Json.Bson;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlotUIController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    internal ItemTypes ItemType = ItemTypes.None;
    [SerializeField, Required] GameObject ImgStick;
    [SerializeField, Required] GameObject ImgNut;
    [SerializeField, Required] GameObject ImgHoney;
    [SerializeField, Required] GameObject ImgId;
    [SerializeField, ReadOnly] internal int SlotIndex;
    [SerializeField, ReadOnly] internal string ItemName;
    [SerializeField, ReadOnly] internal string ItemDescription;
    [SerializeField] string EmptyItemSlotText = "Empty item slot";

    Button mainButton;

    private void Awake()
    {
        UpdateDisplay();
        GameInstance.Instance.GameLogic.OnItemSlotChanged.AddListener(GameLogic_OnItemSlotChanged);
        mainButton = GetComponent<Button>();
        mainButton.onClick.AddListener(MainButton_OnClick);
    }

    void MainButton_OnClick()
    {
        GameInstance.Instance.GameLogic.NotifySlotItemInteracted(SlotIndex);
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
                ImgNut.SetActive(false);
                ImgId.SetActive(false);
                ImgHoney.SetActive(false);
                break;
            case ItemTypes.Nut:
                ImgStick.SetActive(false);
                ImgNut.SetActive(true);
                ImgId.SetActive(false);
                ImgHoney.SetActive(false);
                break;
            case ItemTypes.Papers:
                ImgStick.SetActive(false);
                ImgNut.SetActive(false);
                ImgId.SetActive(true);
                ImgHoney.SetActive(false);
                break;
            case ItemTypes.Honey:
                ImgStick.SetActive(false);
                ImgNut.SetActive(false);
                ImgId.SetActive(false);
                ImgHoney.SetActive(true);
                break;
            default:
                ImgStick.SetActive(false);
                ImgNut.SetActive(false);
                ImgId.SetActive(false);
                ImgHoney.SetActive(false);
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

        UpdateDisplay();
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


    public void OnPointerEnter(PointerEventData eventData)
    {
        GameInstance.Instance.GameLogic.UpdateTooltip(String.Format("{0} - {1}", ItemName, ItemDescription));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameInstance.Instance.GameLogic.UpdateTooltip(string.Empty);
    }
}
