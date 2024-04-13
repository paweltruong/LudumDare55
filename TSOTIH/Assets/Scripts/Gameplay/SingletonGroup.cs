using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonGroup : SingletonMonoBehaviour<SingletonGroup>
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
