using General;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerFSM playerFSM = new PlayerFSM();


    public Material[] mats;


    [SerializeField]
    private bool MiddleStateIsFuzzy = false;


    void Start()
    {
        if(MiddleStateIsFuzzy)
        {
            IState red = new State_Red(this);


            MiddleFuSM middle = new MiddleFuSM(this);

            FuSMState green = new FuzzyState_Green(this, false);
            FuSMState rotateAboutY = new FuzzyState_RotateAboutY(this, false);

            middle.addState(green);
            middle.addState(rotateAboutY);


            IState blue = new State_Blue(this);

            playerFSM.addState(red);
            playerFSM.addState(middle);
            playerFSM.addState(blue);

            playerFSM.setStartState(red);

        }
        else
        {
            IState red = new State_Red(this);

            IState green = new State_Green(this);

            IState blue = new State_Blue(this);

            playerFSM.addState(red);
            playerFSM.addState(green);
            playerFSM.addState(blue);

            playerFSM.setStartState(red);
        }

        playerFSM.startMachine();
    }


    void Update()
    {
        playerFSM.Update();    
    }
}