using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameLogic : MonoBehaviour
{
    public UnityEvent OnNewGameRequested = new UnityEvent();

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
        OnNewGameRequested.Invoke();
    }
}
