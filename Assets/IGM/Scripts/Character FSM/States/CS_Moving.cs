using UnityEngine;

public class CS_Moving : CFSM_BaseState
{
    protected readonly float _speed;



    public CS_Moving(Character_FSM state_machine, float speed) : base(state_machine)
    {
        _speed = speed;

        _transitions = new Transition[]
        {
            //new ToIdle(_input, _stateMachine),
            new ToJumping(_input, _stateMachine),
            //new ToCrouching(_input, _stateMachine),
            //new ToRunning(_input, _stateMachine)
        };
    }



    public override void Enter()
    {
        //Debug.Log("Moving state: [ENTER]");
    }

    public override void Exit()
    {
        //Debug.Log("Moving state: [EXIT]");
    }

    public override void Update()
    {
        Vector2 input_direction = ReadInput();

        if (input_direction.sqrMagnitude == 0)
            _stateMachine.SetState<CS_Idle>();

        if (_input.Jump)
            _stateMachine.SetState<CS_Jumping>();

        //if (Input.GetKeyDown(KeyCode.LeftShift))
            //_stateMachine.SetState<CS_Running>();

        Move(input_direction);
    }



    protected Vector2 ReadInput()
    {
        float horizontal = _input.Horizontal_Move;
        //float vertical = _input.Vertical_Move;

        return new Vector2(horizontal, 0f);
    }



    protected virtual void Move(Vector2 input_direction)
    {
        Vector3 moving_direction = _controller.transform.forward * input_direction.x;
                                 //+ _characterTransform.right * input_direction.x;
        moving_direction *= _speed * Time.deltaTime;

        _controller.Move(moving_direction);
    }
}
