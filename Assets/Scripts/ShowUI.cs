using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 30f)] private float secondsToWait;
    public GameObject uiObject;
    private void Start()
    {
        uiObject.SetActive(false);
    }
    //Update is called once per frame
    private void OnTriggerEnter(Collider player)
    {
      if (player.gameObject.tag == "Player") 
        { 
            uiObject.SetActive(true);
            StartCoroutine("WaitForSec");
        }  
    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(secondsToWait);
        Destroy(uiObject);
        Destroy(gameObject);
    }
}
