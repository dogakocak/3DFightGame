using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject left_Arm, right_Arm, left_Leg, right_Leg;

    public float stand_Up_Timer = 1f;

    private CharacterAnimation animationScript;

    private AudioSource audioSource;

    [SerializeField] [CanBeNull] 
    private AudioClip whoosh_Sound, fall_Sound, ground_Hit_Sound, dead_Sound, hit_Sound;

    private EnemyMovement enemy_Movement;

    private void Awake()
    {
        animationScript = GetComponent<CharacterAnimation>();

        audioSource = GetComponent<AudioSource>();

        if (gameObject.CompareTag("Enemy"))
        {
            enemy_Movement = GetComponentInParent<EnemyMovement>();
        }
    }


    void Left_Arm_Attack_On()
    {
        left_Arm.SetActive(true);
    }
    void Left_Arm_Attack_Off()
    {
        if (left_Arm.activeInHierarchy)
        {
            left_Arm.SetActive(false);
        }
    }
    
    void Right_Arm_Attack_On()
    {
        left_Arm.SetActive(true);
    }
    void Right_Arm_Attack_Off()
    {
        if (right_Arm.activeInHierarchy)
        {
            right_Arm.SetActive(false);
        }
    }

    void Left_Leg_Attack_On()
    {
        left_Leg.SetActive(true);
    }

    void Left_Leg_Attack_Off()
    {
        if (left_Leg.activeInHierarchy)
        {
            left_Leg.SetActive(false);
        }
    }
    
    void Right_Leg_Attack_On()
    {
        right_Leg.SetActive(true);
    }

    void Right_Leg_Attack_Off()
    {
        if (right_Leg.activeInHierarchy)
        {
            right_Leg.SetActive(false);
        }
    }

    void TagLeft_Arm()
    {
        left_Arm.tag = "LeftArm";
    }

    void UnTagLeft_Arm()
    {
        left_Arm.tag = "Untagged";
    }

    void TagLeft_Leg()
    {
        left_Leg.tag = "LeftLeg";
    }

    void UntagLeft_Leg()
    {
        left_Leg.tag = "Untagged";
    }

    void Enemy_StandUp()
    {
        StartCoroutine(StandUpAfterTime());
    }

    IEnumerator StandUpAfterTime()
    {
        yield return new WaitForSeconds(stand_Up_Timer);
        animationScript.StandUp();
    }

    public void Attack_FX_Sound()
    {
        audioSource.volume = 0.4f;
        audioSource.clip = whoosh_Sound;
        audioSource.Play();
    }

    void CharacterDiedSound()
    {
        audioSource.volume = 1f;
        audioSource.clip = dead_Sound;
        audioSource.Play();
    }

    void Enemy_KnockedDown()
    {
        audioSource.clip = fall_Sound;
        audioSource.Play();
    }

    void Enemy_HitGround()
    {
        audioSource.clip = ground_Hit_Sound;
        audioSource.Play();
    }

    void DisableMovement()
    {
        enemy_Movement.enabled = false;
        
    }

    void EnableMovement()
    {
        enemy_Movement.enabled = true;
        
    }

    public void hit_Sound_FX()
    {
        audioSource.clip = hit_Sound;
        audioSource.Play();
    }
}
