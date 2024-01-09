using UnityEngine;

public class CS_Jumping : CS_InAir
{
    protected readonly float _jumpHeight;

    public CS_Jumping(Character_FSM state_machine, float gravity_value, float jump_height) : base(state_machine, gravity_value)
    {
        _jumpHeight = jump_height;

        _stateMachine.AddState(new CS_InAir (state_machine, gravity_value));
    }



    //public override void Enter()
    //{
        //Debug.Log("Jump state: [ENTER]");

        //if (_stateMachine.characterController.isGrounded)//!IsOnGround())
            //Jump();

        //_stateMachine.SetState<CS_InAir>();
    //}

    public override void Update()
    {
        Debug.Log("Jump state: [UPDATE]");

        if (_stateMachine.characterController.isGrounded)//!IsOnGround())
            Jump();

        _stateMachine.SetState<CS_InAir>();
    }



    void Jump()
    {
        Vector3 velocity = new Vector3(0, Mathf.Sqrt(_jumpHeight * _gravityValue * Time.deltaTime), 0);

        _stateMachine.characterController.Move(velocity);
    }
}
