using UnityEngine;

public class CS_Jumping : CS_InAir
{
    protected readonly float _jumpHeight;

    public CS_Jumping(Character_FSM state_machine, float gravity_value, float jump_height) : base(state_machine, gravity_value)
    {
        _jumpHeight = jump_height; // сменить на другую функцию

        _stateMachine.AddState(new CS_InAir(state_machine, gravity_value));
    }



    public override void Enter()
    {
        Debug.Log("Jump state: [ENTER]");

        if (IsOnGround())
            Jump();

        _stateMachine.SetState<CS_InAir>();
    }

    //public override void Update()
    //{
        //Debug.Log("Jump state: [UPDATE]");

        //if (_stateMachine.characterController.isGrounded)//!IsOnGround())
            //Jump();

        //_stateMachine.SetState<CS_InAir>();
    //}



    void Jump()
    {
        _velocity = Mathf.Sqrt(_jumpHeight * _gravityValue);

        _controller.Move(Vector3.up * _velocity);// * Time.fixedDeltaTime);
        //_animation.VerticalMove(1);
        _animation.Jump();
        //_animation.SetOnFloor(false);
    }
}
