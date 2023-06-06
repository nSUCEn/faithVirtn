using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletTimer : MonoBehaviour
{
    [SerializeField] private float WeaponLifeTime = 5f;
    public void Update()
    {
        Destroy(gameObject, WeaponLifeTime);
    }
}
