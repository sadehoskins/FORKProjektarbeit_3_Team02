using UnityEngine;

public class Grounded : BaseState
{
    public Grounded(StateManager currentContext, StateFactory stateFactory): base (currentContext, stateFactory) 
    {
        InitializeSubState();
        isRootState = true;
    }

    public BaseState GetCurrentSubState()
    {
        return currentSubState; 
    }
    override public void EnterState()
    {
        Debug.Log("Entering Grounded State");
        context.inputActions.Test.Jump.Enable();
    }

    override public void UpdateState()
    {
        CheckSwitchStates();
    }

    public override void InitializeSubState()
    {
        if(context.playerControls.Walk.IsPressed())
        {
            SetSubState(factory.Walking());
        }
        else if(context.playerControls.Roll.triggered)
        {
            SetSubState(factory.Rolling());
        }
        else if(context.playerControls.Block.triggered)
        {
            SetSubState(factory.Blocking());
        }
        else if (context.playerControls.Counter.triggered)
        {
            SetSubState(factory.Countering());
        }
        else if(!context.playerControls.Walk.IsPressed())
        {
            SetSubState(factory.Idleing());
        }
    }

    public override void CheckSwitchStates()
    {
        if(context.playerControls.Jump.phase == UnityEngine.InputSystem.InputActionPhase.Performed || !context.isGrounded )
        {
            SwitchState(factory.Air());
        }
    }
    override public void ExitState()
    {

    }

}
