using System;
using UnityEngine;

public class State_Green : PlayerAction
{
    public bool bMoveToNext = false;
    public bool bMoveToPrev = false;


    public State_Green(PlayerController playerController) : base(playerController)
    {
        ID = Actions.STATE_GREEN;
    }


    public override Enum checkTransitions()
    {
        if (bMoveToNext)
        {
            return Actions.STATE_BLUE;
        }

        if (bMoveToPrev)
        {
            return Actions.STATE_RED;
        }

        return ID;
    }


    public override void enter()
    {
        bMoveToNext = false;
        bMoveToPrev = false;


        playerController.gameObject.GetComponent<MeshRenderer>().material = playerController.mats[1];
    }


    public override void FixedUpdate()
    {
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            bMoveToNext = true;

            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            bMoveToPrev = true;

            return;
        }
    }
}