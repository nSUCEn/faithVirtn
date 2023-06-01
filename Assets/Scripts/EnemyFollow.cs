using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform Player;


    private Animator animator;
    // Start is called before the first frame update
        public void Start()
    {
        animator = GetComponent<Animator>();
        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(Player.position);

        if (enemy != null)
        {
            animator.SetBool("isMoving", enemy.remainingDistance > enemy.stoppingDistance);
        }

    }
    

        
}
