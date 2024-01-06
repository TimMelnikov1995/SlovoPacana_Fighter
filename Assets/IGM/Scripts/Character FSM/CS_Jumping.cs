using UnityEngine;

public class CS_Jumping : CS_InAir
{
    protected readonly float _jumpHeight;

    public CS_Jumping(Character_FSM state_machine, CharacterController character_controller, Transform character_transform, float gravity_value, float jump_height) : base(state_machine, character_controller, character_transform, gravity_value)
    {
        _jumpHeight = jump_height;
    }



    public override void Enter()
    {
        if (!IsOnGround())
            return;
        
        Jump();

        _stateMachine.SetState<CS_InAir>();
    }

    void Jump()
    {
        Mathf.Sqrt(_jumpHeight * _gravityValue * Time.deltaTime);
    }
}
