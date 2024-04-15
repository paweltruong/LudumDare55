using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotsUIController : MonoBehaviour
{
    [SerializeField, Required] GameObject ItemSlotPrefab;

    List<ItemSlotUIController> items = new List<ItemSlotUIController>();

    private void Awake()
    {
        GameInstance.Instance.GameLogic.OnNewGameRequested.AddListener(GameLogic_OnNewGameRequested);
        GameInstance.Instance.GameLogic.OnActiveSceneChanged.AddListener(GameLogic_OnActiveSceneChanged);
    }

    void GameLogic_OnNewGameRequested()
    {
        //Clear all children
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        items.Clear();

        int slotIndex = 0;
        foreach(var item in GameInstance.Instance.GameState.Items)
        {
            var createdObject = Instantiate(ItemSlotPrefab, this.transform);
            var slot = createdObject.GetComponent<ItemSlotUIController>();
            slot.SetIndex(slotIndex);
            slot.SetItem(item);
            ++slotIndex;
            items.Add(slot);
        }
    }

    void GameLogic_OnActiveSceneChanged(SceneLogicController scene)
    {
        foreach(var item in items) 
        {
            item.gameObject.SetActive(scene.bShowItems);
        }
        
    }
}
