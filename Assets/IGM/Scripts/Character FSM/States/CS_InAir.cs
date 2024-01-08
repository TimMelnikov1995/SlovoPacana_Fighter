using UnityEngine;

public class CS_InAir : CFSM_BaseState
{
    protected readonly float _gravityValue;

    protected float _velocity = 0f;



    public CS_InAir(Character_FSM state_machine, float gravity_value) : base(state_machine)
    {
        _gravityValue = gravity_value;
    }



    public override void Update()
    {
        if (IsOnGround())

        _velocity -= _gravityValue * Time.deltaTime;
        _stateMachine.characterController.Move(_stateMachine.characterTransform.position + new Vector3(0, _velocity, 0));
    }
}