using UnityEngine;

public class CS_InAir : CS_Moving
{
    public CS_InAir(Character_FSM state_machine, float speed) : base(state_machine, speed) { }



    public override void Enter() { _animation.Fall(); }

    public override void Update()
    {
        if (_script.IsOnGround())
            Land();

        Vector2 input_direction = ReadInput();

        if (input_direction.sqrMagnitude != 0)
            Move(input_direction);
    }



    protected void Land()
    {
        //if (_velocity > _gravityValue * 5)
            //_stateMachine.SetState<CS_Death>();
        //else
        //{
            //_animation.SetOnFloor(true);
            //_animation.VerticalMove(0);
            _animation.Land();
            _stateMachine.SetState<CS_Idle>();
        //}
    }
}