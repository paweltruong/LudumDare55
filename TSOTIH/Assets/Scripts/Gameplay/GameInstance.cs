using Sirenix.OdinInspector;
using System;
using System.Linq;
using UnityEngine;

public class GameInstance : SingletonMonoBehaviour<GameInstance>
{
    public GameState GameState;
    [SerializeField, Required] internal GameLogic GameLogic;


}