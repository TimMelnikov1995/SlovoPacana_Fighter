using UnityEngine;

public class CS_InAir : CFSM_BaseState
{
    protected readonly float _gravityValue;

    protected float _velocity = 0f;

    bool _skipFirstFrame = false;



    public CS_InAir(Character_FSM state_machine, float gravity_value) : base(state_machine)
    {
        _gravityValue = gravity_value;
    }



    public override void Enter()
    {
        Debug.Log("In Air state: [ENTER]");
        
        _skipFirstFrame = true;
    }

    public override void Update()
    {
        Debug.Log("In Air state: [UPDATE]");

        if (_skipFirstFrame)
        {
            _skipFirstFrame = false;

            return;
        }
            
        if (_stateMachine.characterController.isGrounded)//IsOnGround())
            Land();

        _velocity += -_gravityValue * Time.deltaTime;
        _stateMachine.characterController.Move(new Vector3(0, _velocity * Time.deltaTime, 0)); // _stateMachine.characterTransform.position + 
    }



    protected void Land()
    {
        //if (_velocity > _gravityValue * 5)
            //_stateMachine.SetState<CS_Death>();
        //else
        //{
            //_stateMachine.characterAnimation.Land();
            _stateMachine.SetState<CS_Idle>();
        //}
    }
}