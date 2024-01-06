using UnityEngine;

public class CS_InAir : CFSM_CCC_State
{
    protected readonly float _gravityValue;

    protected float _velocity = 0f;



    public CS_InAir(Character_FSM state_machine, CharacterController character_controller, Transform character_transform, float gravity_value) : base(state_machine, character_controller, character_transform)
    {
        _gravityValue = gravity_value;
    }



    public override void Update()
    {
        if (IsOnGround())

        _velocity -= _gravityValue * Time.deltaTime;
        _characterController.Move(_characterTransform.position + new Vector3(0, _velocity, 0));
    }
}