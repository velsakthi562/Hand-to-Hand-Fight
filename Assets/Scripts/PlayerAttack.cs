using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public enum ComboState
    {
        NONE,
        PUNCH,
        PUNCH2,
        PUNCH3,
        KICK1,
        KICK2,
        //KICK3
    }

    PlayerAnimation playerAnimation;

    private bool activateToTimerReset;
    private float defaultComboTime = 0.4f;
    private float currentComboTime;

    private ComboState currentComboState;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        currentComboTime = defaultComboTime;
        currentComboState = ComboState.NONE;
    }

    // Update is called once per frame
    void Update()
    {
        Attacks();
        ResetComboState();
    }
    void Attacks()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(currentComboState == ComboState.PUNCH3 ||
                currentComboState == ComboState.KICK1 || 
                currentComboState== ComboState.KICK2)
                return;
          
            currentComboState++;
            activateToTimerReset = true;
            currentComboTime = defaultComboTime;


            if (currentComboState == ComboState.PUNCH)
            {
                playerAnimation.Punch();
            }
            if (currentComboState == ComboState.PUNCH2)
            {
                playerAnimation.Punch2();
            }
            if (currentComboState == ComboState.PUNCH3)
            {
                playerAnimation.Punch3();
            }
        }


        if (Input.GetMouseButtonDown(1))
        {
            if (currentComboState == ComboState.KICK2 ||
                currentComboState == ComboState.PUNCH3)
                return;

            if (currentComboState == ComboState.NONE ||
                currentComboState == ComboState.PUNCH ||
                currentComboState == ComboState.PUNCH2)
            {
                currentComboState = ComboState.KICK1;
            }

            else if (currentComboState == ComboState.KICK1)
            {
                currentComboState++;
            }

            activateToTimerReset = true;
            currentComboTime = defaultComboTime;

            if(currentComboState == ComboState.KICK1)
            {
                playerAnimation.Kick1();
            }

            if (currentComboState == ComboState.KICK2)
            {
                playerAnimation.Kick2();
            }
            //if (currentComboState == ComboState.KICK3)
            //{
                //playerAnimation.Kick3();
            //}

        }
    }
    void ResetComboState()
    {
        if (activateToTimerReset)
        {
            currentComboTime -= Time.deltaTime;

            if(currentComboTime <= 0f)
            {
                currentComboState = ComboState.NONE;

                activateToTimerReset = false;
                currentComboTime = defaultComboTime;
            }
        }
        
    }
}
