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
        //Debug.Log("In Air state: [ENTER]");
        
        _skipFirstFrame = true;
        _velocity = _controller.velocity.y;
    }

    public override void FixedUpdate()
    {
        Debug.Log("In Air state: [FIXED UPDATE]");

        if (_skipFirstFrame)
        {
            _skipFirstFrame = false;

            return;
        }

        if (_controller.isGrounded)//IsOnGround())
            Land();

        _velocity -= _gravityValue * Mathf.Pow(Time.fixedDeltaTime, 2);
        _controller.Move(new Vector3(0, _velocity, 0)); // _stateMachine.characterTransform.position + 
    }



    protected void Land()
    {
        //if (_velocity > _gravityValue * 5)
            //_stateMachine.SetState<CS_Death>();
        //else
        //{
            //_animation.SetOnFloor(true);
            //_animation.VerticalMove(0);
            _animation.Land();
            _stateMachine.SetState<CS_Idle>();
            _velocity = 0f;
        //}
    }
}