using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class NextLevelTrigger : MonoBehaviour
{
    public static Action OnNextLevel;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            OnNextLevel?.Invoke();
        }
    }
}
