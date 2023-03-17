using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = System.Random;

public class EnemyMovement : MonoBehaviour
{
    private CharacterAnimation enemyAnim;
    private Rigidbody myBody;
    public float speed = 5f;

    private Transform playerTarget;

    public float attack_Distance = 1f;

    private float chase_Player_After_Attack = 1f;

    private float current_Attack_Time;
    private float defualt_Attack_Time = 2f;

    private bool followPlayer, attackPlayer;

    private void Awake()
    {
        enemyAnim = GetComponentInChildren<CharacterAnimation>();
        myBody = GetComponent<Rigidbody>();

        playerTarget = GameObject.FindWithTag("Player").transform;
        
       

    }

    void Start()
    {
        followPlayer = true;
        current_Attack_Time = defualt_Attack_Time;
    }

    // Update is called once per frame
    void Update()
    {
       Attack();
    }

    private void FixedUpdate()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        if (!followPlayer)
        {
            return;
        }

        if (Vector3.Distance(transform.position,playerTarget.position) > attack_Distance)
        {
            transform.LookAt(playerTarget);
            myBody.velocity = transform.forward * speed;

            if (myBody.velocity.sqrMagnitude != 0)
            {
                enemyAnim.Walk(true);
            }
        }else if (Vector3.Distance(transform.position, playerTarget.position) <= attack_Distance)
        {
            myBody.velocity = Vector3.zero;
            enemyAnim.Walk(false);

            followPlayer = false;
            attackPlayer = true;

        }
    }

    void Attack()
    {
        if (!attackPlayer)
        {
            return;
        }
        
        current_Attack_Time += Time.deltaTime;

        if (current_Attack_Time > defualt_Attack_Time){}
        {
            enemyAnim.EnemyAttack(UnityEngine.Random.Range(0, 3));

            current_Attack_Time = 0f;
        }

        if (Vector3.Distance(transform.position, playerTarget.position) > attack_Distance + chase_Player_After_Attack)
        {
            attackPlayer = false;
            followPlayer = true;
            
        }
    }
}
