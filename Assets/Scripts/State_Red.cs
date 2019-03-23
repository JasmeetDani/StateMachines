using System;
using UnityEngine;

public class State_Red : PlayerAction
{
    public bool bMoveToNext = false;


    public State_Red(PlayerController playerController) : base(playerController)
    {
        ID = Actions.STATE_RED;
    }


    public override Enum checkTransitions()
    {
        if(bMoveToNext)
        {
            return Actions.STATE_GREEN;
        }

        return ID;
    }


    public override void enter()
    {
        bMoveToNext = false;
        

        playerController.gameObject.GetComponent<MeshRenderer>().material = playerController.mats[0];
    }


    public override void FixedUpdate()
    {
    }

    public override void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            bMoveToNext = true;
        }
    }
}