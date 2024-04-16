using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveController : MonoBehaviour
{
    [SerializeField, Required] InteractableObject honey;

    public void AddHoneyToInventory()
    {
        honey.availableForPickup = true;
        GameInstance.Instance.GameLogic.AddItemToAvailableSlot(honey);
        SFXController.Instance.PlayPickup();
    }
}
