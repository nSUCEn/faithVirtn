using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionDelay : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DestroyPlayerAfterDelay(other.gameObject, 5f));
        }
    }

    private System.Collections.IEnumerator DestroyPlayerAfterDelay(GameObject playerObject, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(playerObject);
    }
}
