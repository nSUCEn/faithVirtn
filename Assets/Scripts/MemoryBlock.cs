using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryBlock : MonoBehaviour
{
    [SerializeField] public int health = 100;
    [SerializeField] private int damage = 50;
    private GameObject bullet;
    private void OnTriggerEnter (Collider other)
    {
        if (other != null)
        {
            bullet = other.gameObject;
            if (bullet.tag == "Bullet") 
            { 
                health -= damage;
                Destroy(bullet);
            }
        }
    }
    private void LateUpdate()
    {
        if (health <= 0)
            Destroy(gameObject);
    }
}
