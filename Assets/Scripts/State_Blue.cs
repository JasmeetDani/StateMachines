using System;
using UnityEngine;

public class State_Blue : PlayerAction
{
    public bool bMoveToPrev = false;


    public State_Blue(PlayerController playerController) : base(playerController)
    {
        ID = Actions.STATE_BLUE;
    }


    public override Enum checkTransitions()
    {
        if (bMoveToPrev)
        {
            return Actions.STATE_GREEN;
        }

        return ID;
    }


    public override void enter()
    {
        bMoveToPrev = false;


        playerController.gameObject.GetComponent<MeshRenderer>().material = playerController.mats[2];
    }


    public override void FixedUpdate()
    {
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            bMoveToPrev = true;
        }
    }
}