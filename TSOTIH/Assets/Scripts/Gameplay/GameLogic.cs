using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameLogic : MonoBehaviour
{
    public UnityEvent OnNewGameRequested = new UnityEvent();
    public UnityEvent<int, InteractableObject> OnItemSlotChanged = new UnityEvent<int, InteractableObject>();
    public UnityEvent<string> OnTooltipRequested = new UnityEvent<string>();
    public UnityEvent<SceneLogicController> OnActiveSceneChanged = new UnityEvent<SceneLogicController>();

    private void Awake()
    {

    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateTooltip(string text)
    {
        OnTooltipRequested.Invoke(text);
    }

    public void StartNewGame()
    {


        var initialItemsAndSlots = new List<ItemTypes>();
        initialItemsAndSlots.Add(ItemTypes.None);
        initialItemsAndSlots.Add(ItemTypes.None);
        initialItemsAndSlots.Add(ItemTypes.None);
        GameInstance.Instance.GameState.Items = initialItemsAndSlots;


        OnNewGameRequested.Invoke();
    }

    public void RemoveItem(ItemTypes item)
    {
        for (int i = 0; i < GameInstance.Instance.GameState.Items.Count; i++)
        {
            if (GameInstance.Instance.GameState.Items[i] == item)
            {
                GameInstance.Instance.GameState.Items[i] = ItemTypes.None;
                OnItemSlotChanged.Invoke(i, null);
                break;
            }
        }
    }



    internal void NotifySlotItemInteracted(int slotIndex)
    {
        if (GameInstance.Instance.GameState.ActiveScene == null) return;

        if (GameInstance.Instance.GameState.Items.Count > slotIndex)
        {
            var slot = GameInstance.Instance.GameState.Items[slotIndex];
            switch (slot)
            {
                case ItemTypes.Nut:
                    GameInstance.Instance.GameState.ActiveScene.UseNut();
                    RemoveItem(ItemTypes.Nut);
                    break;
                default:
                    break;
            }
        }

    }

    internal void NotifyIteracted(InteractableObject interactableObject)
    {
        if (!interactableObject.availableForPickup)
        {

            Debug.Log(interactableObject.name + " item not available");
            return;
        }

        switch (interactableObject.ItemType)
        {
            case ItemTypes.Stick:

                Debug.Log("Stick picked up");
                AddItemToAvailableSlot(interactableObject);
                SFXController.Instance.PlayPickup();
                if (GameInstance.Instance.GameState.ActiveScene != null)
                {
                    GameInstance.Instance.GameState.ActiveScene.Grandpa_Pickup();
                }
                GameInstance.Instance.GameLogic.UpdateTooltip(string.Empty);

                break;
            case ItemTypes.Papers:
                Debug.Log("Papers picked up");
                AddItemToAvailableSlot(interactableObject);
                SFXController.Instance.PlayPickup();
                if (GameInstance.Instance.GameState.ActiveScene != null)
                {
                    GameInstance.Instance.GameState.ActiveScene.Grandpa_Pickup();
                }
                GameInstance.Instance.GameLogic.UpdateTooltip(string.Empty);
                break;

            case ItemTypes.Nut:

                Debug.Log("Nut picked up");
                AddItemToAvailableSlot(interactableObject);
                SFXController.Instance.PlayPickup();
                if (GameInstance.Instance.GameState.ActiveScene != null)
                {
                    GameInstance.Instance.GameState.ActiveScene.Grandpa_Pickup();
                }
                GameInstance.Instance.GameLogic.UpdateTooltip(string.Empty);

                break;
            default:
                break;
        }
    }

    public bool AddItemToAvailableSlot(InteractableObject interactableObject)
    {
        for (int i = 0; i < GameInstance.Instance.GameState.Items.Count; ++i)
        {
            if (GameInstance.Instance.GameState.Items[i] == ItemTypes.None)
            {
                GameInstance.Instance.GameState.Items[i] = interactableObject.ItemType;
                OnItemSlotChanged.Invoke(i, interactableObject);
                return true;
            }
        }
        return false;
    }

    internal void UpdateActiveScene(SceneLogicController sceneLogicController)
    {
        GameInstance.Instance.GameState.ActiveScene = sceneLogicController;
        OnActiveSceneChanged.Invoke(sceneLogicController);
    }
}
