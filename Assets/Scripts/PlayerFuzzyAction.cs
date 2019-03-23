using General;

public abstract class PlayerFuzzyAction : FuSMState
{
    protected PlayerController playerController = null;


    public PlayerFuzzyAction(PlayerController playerController, bool IsTriggerable) : base(IsTriggerable)
    {
        this.playerController = playerController;


        this.resetActivation();
    }
}