using General;
using System;

public abstract class PlayerAction : FSMState<Actions>
{
    protected PlayerController playerController = null;


    public PlayerAction(PlayerController playerController)
    {
        this.playerController = playerController;
    }


    public override Enum getID()
    {
        return ID;
    }
}