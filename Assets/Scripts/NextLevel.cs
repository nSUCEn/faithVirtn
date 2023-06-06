using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.Events;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private EventScript eventSystem;
    public bool isObjectPickedUp = false;
    public string sceneName;
    void Start()
    {
        eventSystem.OnEvent += HandleEvent;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isObjectPickedUp)
            SceneManager.LoadScene(sceneName);
    }
    private void HandleEvent()
    {
        //Debug.Log("Event triggered!");
        isObjectPickedUp = true;
    }
    private void OnDisable()
    {
        eventSystem.OnEvent -= HandleEvent;
    }
}
