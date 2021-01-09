using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterAnimation : MonoBehaviour
{
    public GameObject leftArmAttackPoint, rightArmAttackPoint;
    public GameObject leftLegAttackPoint, rightLegAttackPoint;

    public float standUpTime = 2f;
    private PlayerAnimation player;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip hitSound, fallSound, groundSound, deadSound;

    private EnemyMovement enemyMovement;

    void Awake()
    {
        player = GetComponent<PlayerAnimation>();
        audioSource = GetComponent<AudioSource>();

        if (gameObject.CompareTag(Tags.ENEMY))
        {
            enemyMovement = GetComponent<EnemyMovement>();
        }

    }

    void LeftArmAttackOn()
    {
        leftArmAttackPoint.SetActive(true);
    }
    void LeftArmAttackOff()
    {
        if (leftArmAttackPoint.activeInHierarchy)
        {
            leftArmAttackPoint.SetActive(false);
        }
    }
    void RightArmAttackOn()
    {
        rightArmAttackPoint.SetActive(true);
    }
    void RightArmAttackOff()
    {
        if (rightArmAttackPoint.activeInHierarchy)
        {
            rightArmAttackPoint.SetActive(false);
        }
    }

    void LeftLegAttackOn()
    {
        leftLegAttackPoint.SetActive(true);
    }
    void LeftLegAttackOff()
    {
        if (leftLegAttackPoint.activeInHierarchy)
        {
            leftLegAttackPoint.SetActive(false);
        }
    }
    void RightLegAttackOn()
    {
        rightLegAttackPoint.SetActive(true);
    }
    void RightLegAttackOff()
    {
        if (rightLegAttackPoint.activeInHierarchy)
        {
            rightLegAttackPoint.SetActive(false);
        }
    }

    void TagLeftArm()
    {
        leftArmAttackPoint.tag = Tags.LEFTARM;
    }
    void UnTagLeftArm()
    {
        leftArmAttackPoint.tag = Tags.UNTAGGED;
    }
    void TagRightLeg()
    {
        leftLegAttackPoint.tag = Tags.RIGHTLEG;
    }
    void UnTagRightLeg()
    {
        leftLegAttackPoint.tag = Tags.UNTAGGED;
    }
    void EnemyStandUp()
    {
        StartCoroutine(StandUpAfterTime());

    }
    IEnumerator StandUpAfterTime()
    {
        yield return new WaitForSeconds(standUpTime);
        player.StandUp();
    }

    public void AttackFX()
    {
        audioSource.volume = 0.2f;
        audioSource.clip = hitSound;
        audioSource.Play();
    }
    void CharacterDied()
    {
        audioSource.volume = 0.8f;
        audioSource.clip = deadSound;
        audioSource.Play();
    }
    void EnemyKnocksDown()
    {
        audioSource.clip = fallSound;
        audioSource.Play();
    }
    void EnemyHitGround()
    {
        audioSource.clip = groundSound;
        audioSource.Play();
    }

    void DisableMovment()
    {
        enemyMovement.enabled = false;
        transform.gameObject.layer = 0;
    }

    void EnableMovement()
    {
        enemyMovement.enabled = true;
        transform.gameObject.layer = 9;
    }

    void PlayerDied()
    {
        Invoke("DeactivatedGameObject", 2f);
    }
    void DeactivatedGameObject()
    {
        EnemyManager.instance.SpawnEnemy();
        gameObject.SetActive(false);
    }
}
