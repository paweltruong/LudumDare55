using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    public SceneLogicController ActiveScene;
    public List<ItemTypes> Items = new List<ItemTypes>();


    public bool HasItem(ItemTypes item)
    {

        for (int i = 0; i < Items.Count; i++)
        {
            if (GameInstance.Instance.GameState.Items[i] == item)
            {
                return true;
            }
        }

        return false;
    }

}
