using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EventScript : MonoBehaviour
{

    public delegate void MyEventHandler();  // Определение делегата события
    public event MyEventHandler OnEvent;    // Объявление события

    public bool isPickedUp = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPickedUp)
        {
            isPickedUp = true;
            if (OnEvent != null)
            {
                OnEvent(); // Вызов события
            }
            Destroy(gameObject);
        }
    }
}
