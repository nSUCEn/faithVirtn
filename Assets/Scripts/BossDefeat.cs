using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossDefeat : MonoBehaviour
{
    [SerializeField] private float seconds = 8;
    [SerializeField] private GameObject monologue;
    MemoryBlock block;
    private void Start()
    {
        block = GetComponent<MemoryBlock>();
    }
    private void Update()
    {
        if (block.health <= 0)
        {
            monologue.SetActive(true);
        }
    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(seconds);
        monologue?.SetActive(false);
    }
}
