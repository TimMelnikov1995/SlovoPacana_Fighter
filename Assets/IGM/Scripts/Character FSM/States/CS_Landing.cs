using UnityEngine;

class CS_Landing : CS_InAir
{
    public CS_Landing(Character_FSM state_machine, float gravity_value) : base(state_machine, gravity_value) { }



    public override void Enter()
    {
        //_stateMachine.characterAnimation.Land();

        if (_velocity > _gravityValue * 5)
            _stateMachine.SetState<CS_Death>();
        else
            _stateMachine.SetState<CS_Idle>();
    }
}