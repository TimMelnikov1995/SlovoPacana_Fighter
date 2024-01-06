using UnityEngine;

public class CFSM_CCC_State : CFSM_BaseState
{
    protected readonly CharacterController _characterController;
    protected readonly Transform _characterTransform;

    public CFSM_CCC_State(Character_FSM state_machine, CharacterController character_controller, Transform character_transform) : base(state_machine)
    {
        _characterController = character_controller;
        _characterTransform = character_transform;
    }
}