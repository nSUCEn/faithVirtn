using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EventScript : MonoBehaviour
{

    public delegate void MyEventHandler();  // ����������� �������� �������
    public event MyEventHandler OnEvent;    // ���������� �������

    public bool isPickedUp = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPickedUp)
        {
            isPickedUp = true;
            if (OnEvent != null)
            {
                OnEvent(); // ����� �������
            }
            Destroy(gameObject);
        }
    }
}
