using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonologueActive : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 10f)] private float secondsToWait;
    public GameObject monologue;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            monologue.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(WaitForSec());
    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(secondsToWait);
        monologue?.SetActive(false);
    }
}
