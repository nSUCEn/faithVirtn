using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUIs : MonoBehaviour
{
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
        yield return new WaitForSeconds(10);
        Destroy(uiObject);
        Destroy(gameObject);
    }
}
