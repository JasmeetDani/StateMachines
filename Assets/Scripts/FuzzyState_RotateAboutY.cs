using UnityEngine;

public class FuzzyState_RotateAboutY : PlayerFuzzyAction
{
    public FuzzyState_RotateAboutY(PlayerController playerController, bool IsTriggerable) : base(playerController, IsTriggerable)
    {
    }


    public override void FixedUpdate()
    {
    }

    public override void Update()
    {
        playerController.transform.Rotate(Vector3.up, 60 * Time.deltaTime);
    }
}