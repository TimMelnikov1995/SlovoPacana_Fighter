public class ToMoving : Transition
{
    CharacterInput _input;



    public ToMoving(CharacterInput input, Character_FSM state_machine) :base (state_machine)
    {
        _input = input;
    }



    public override void Update()
    {
        if (_input.Horizontal_Move != 0)
            _stateMachine.SetState<CS_Moving>();
    }
}
