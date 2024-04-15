using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelController : MonoBehaviour
{
    [SerializeField, Required] InteractableObject papers;

    public void AddPapersToInventory()
    {
        papers.availableForPickup = true;
        GameInstance.Instance.GameLogic.AddItemToAvailableSlot(papers);
        SFXController.Instance.PlayPickup();
    }
}
