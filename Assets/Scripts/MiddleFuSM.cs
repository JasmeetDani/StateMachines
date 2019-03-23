using General;
using System;

public class MiddleFuSM : FuSMachine<Actions>
{
    protected PlayerController playerController = null;


    public MiddleFuSM(PlayerController playerController)
    {
        this.playerController = playerController;
    }


    public override Enum getID()
    {
        return Actions.STATE_GREEN;
    }


    // This may need to changed, TODO : (revisit)
    public override Enum getFallbackID()
    {
        return Actions.STATE_RED;
    }
}