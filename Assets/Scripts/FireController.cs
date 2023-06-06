using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootPoint;
    public GameObject child;

    public float shootDelay;
    private float timeBetweenShots;
    private void Update()
    {
        if (timeBetweenShots > 0)
        {
            timeBetweenShots -= Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0) && timeBetweenShots <= 0)
        {
            Rigidbody rb = Instantiate(bullet, shootPoint.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(child.transform.forward * 16f, ForceMode.Impulse);
            timeBetweenShots = shootDelay;
        }
    }
}
