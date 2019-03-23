using UnityEngine;

public class FuzzyState_Green : PlayerFuzzyAction
{
    public FuzzyState_Green(PlayerController playerController, bool IsTriggerable) : base(playerController, IsTriggerable)
    {
    }


    public override void enter()
    {
        playerController.gameObject.GetComponent<MeshRenderer>().material = playerController.mats[1];
    }


    public override void FixedUpdate()
    {
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentTransition = Actions.STATE_BLUE;

            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentTransition = Actions.STATE_RED;

            return;
        }
    }
}