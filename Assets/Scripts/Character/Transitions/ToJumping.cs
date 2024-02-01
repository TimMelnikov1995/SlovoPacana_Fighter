public class ToJumping : Transition
{
    CharacterInput _input;

    public ToJumping(CharacterInput input, Character_FSM state_machine) : base(state_machine)
    {
        _input = input;
    }



    public override void Update()
    {
        if (_input.Jump)
            _stateMachine.SetState<CS_Jumping>();
    }
}
