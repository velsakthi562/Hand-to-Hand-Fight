using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public LayerMask collisionMask;
    public float radius = 1f;
    public float damage = 2f;

    public bool isPlayer, isEnemy;

    public GameObject hitEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectCollision();
    }
    void DetectCollision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionMask);

        if(hit.Length > 0)
        {
            if (isPlayer)
            {
                Vector3 hitPos = hit[0].transform.position;
                hitPos.y += 1.3f;
                if(hit[0].transform.forward.x > 0)
                {
                    hitPos.x += 0.3f;
                }else if(hit[0].transform.forward.x < 0)
                {
                    hitPos.x -= 0.3f;
                }
                Instantiate(hitEffect, hitPos, Quaternion.identity);

                if(gameObject.CompareTag(Tags.LEFTARM) || gameObject.CompareTag(Tags.RIGHTLEG))
                {
                    hit[0].GetComponent<Health>().ApplyDamage(damage, true);
                }
                else
                {
                    hit[0].GetComponent<Health>().ApplyDamage(damage, false);
                }
            }
        }
        if (isEnemy)
        {
            hit[0].GetComponent<Health>().ApplyDamage(damage, false);
        }

        gameObject.SetActive(false);
    }
}
