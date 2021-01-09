using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private PlayerAnimation enemyAnim;

    private Rigidbody rb;

    public float speed = 3f;
    public float attackDistance;

    private Transform player;

    public float chasePlayer =1f;
    private float currentAttackTime;
    private float defaultAttackTime = 2f;

    private bool attackPlayer;
    private bool followPlayer;


    // Start is called before the first frame update
    void Start()
    {
        enemyAnim = GetComponent<PlayerAnimation>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag(Tags.PLAYER).transform;

        followPlayer = true;
        currentAttackTime = defaultAttackTime;
    }

    // Update is called once per frame
    void Update()
    {
        
        Attack();
    }
    private void FixedUpdate()
    {
        FollowPlayer();
    }
    void FollowPlayer()
    {
        if (!followPlayer)
            return;
        
        if(Vector3.Distance(transform.position, player.position) > attackDistance)
        {
            transform.LookAt(player);
            rb.velocity = transform.forward * speed;
            if(rb.velocity.sqrMagnitude != 0)
            {
                enemyAnim.Walk(true);
            }
        }
        else if(Vector3.Distance(transform.position, player.position) <= attackDistance)
        {
            rb.velocity = Vector3.zero;
            enemyAnim.Walk(false);

            followPlayer = false;
            attackPlayer = true;
        }
    }
    void Attack()
    {
        if (!attackPlayer)
            return;

        currentAttackTime += Time.deltaTime;

        if(currentAttackTime> defaultAttackTime)
        {
            enemyAnim.EnemyAttack(Random.Range(0, 3));

            currentAttackTime = 0f;
        }
        if(Vector3.Distance(transform.position, player.position)> attackDistance + chasePlayer)
        {
            attackPlayer = false;
            followPlayer = true;
            
        }
    }
}
