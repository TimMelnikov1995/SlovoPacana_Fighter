using UnityEngine;

class CS_Landing : CS_InAir
{
    public CS_Landing(Character_FSM state_machine, CharacterController character_controller, Transform character_transform, float gravity_value) : base(state_machine, character_controller, character_transform, gravity_value) { }



    public override void Enter()
    {
        // Some Animation

        if (_velocity > _gravityValue * 5)
            _stateMachine.SetState<CS_Death>();
        else
            _stateMachine.SetState<CS_Idle>();
    }
}