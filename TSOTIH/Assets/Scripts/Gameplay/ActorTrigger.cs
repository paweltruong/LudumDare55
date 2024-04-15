using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActorTrigger : MonoBehaviour
{
    public UnityEvent OnTriggerClicked;

    private void OnMouseUp()
    {
        Debug.Log(name + " clicked");
        OnTriggerClicked.Invoke();
    }
}
