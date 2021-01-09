using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health = 100f;

    private Image healthUI;
    private PlayerAnimation playerAnimation;
    

    private bool playerDied;

    public bool isPlayer;

  
    void Awake()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        healthUI = GameObject.FindWithTag(Tags.HEALTH).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayHealth(float value)
    {
        value /= 100f;
        if (value < 0)
            value = 0f;

        healthUI.fillAmount = value;
    }

    public void ApplyDamage(float damage, bool knokDown)
    {
        if (playerDied)
            return;

        health -= damage;

        if(isPlayer)
        {
            DisplayHealth(health);
        }
        

        if(health <= 0f)
        {
            playerAnimation.Death();
            playerDied = true;

            if (isPlayer)
            {
                GameObject.FindWithTag(Tags.ENEMY).GetComponent<EnemyMovement>().enabled= false;
            }
            return;
        }
        if (!isPlayer)
        {
            if (knokDown)
            {
                if(Random.Range (0,2)> 0)
                {
                    playerAnimation.KnockDown();
                }
                else
                {
                    if(Random.Range(0,3)> 1)
                    {
                        playerAnimation.Hit();
                    }
                }
            }
        }
    }
}
