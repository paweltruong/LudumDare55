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

    public void ResetState()
    {
        var anim = GetComponent<Animator>();
        if (anim != null)
        {
            anim.Rebind();
            anim.Update(0f);
        }
    }
}
