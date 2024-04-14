using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameLogic : MonoBehaviour
{
    public UnityEvent OnNewGameRequested = new UnityEvent();
    public UnityEvent<int,InteractableObject> OnItemSlotChanged = new UnityEvent<int, InteractableObject>();

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

    public void StartNewGame()
    {        


        var initialItemsAndSlots = new List<ItemTypes>();
        initialItemsAndSlots.Add(ItemTypes.None);
        initialItemsAndSlots.Add(ItemTypes.None);
        initialItemsAndSlots.Add(ItemTypes.None);
        GameInstance.Instance.GameState.Items = initialItemsAndSlots;


        OnNewGameRequested.Invoke();
    }

    internal void NotifyIteracted(InteractableObject interactableObject)
    {
        switch(interactableObject.ItemType) 
        {
            case ItemTypes.Stick:

                Debug.Log("Stick clicked");
                AddItemToAvailableSlot(interactableObject);

                break;
            default:
                break;
        }
    }

    bool AddItemToAvailableSlot(InteractableObject interactableObject)
    {
        for(int i = 0; i < GameInstance.Instance.GameState.Items.Count;++i) 
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
}
