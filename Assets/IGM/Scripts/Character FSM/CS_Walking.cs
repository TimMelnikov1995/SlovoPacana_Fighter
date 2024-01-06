using UnityEngine;

public class CS_Walking : CS_Moving
{
    public CS_Walking(Character_FSM state_machine, CharacterController character_controller, Transform character_transform,  float walk_speed) : base(state_machine, character_controller, character_transform, walk_speed) { }

    public override void Enter()
    {
        Debug.Log("Walking state: [ENTER]");
    }

    public override void Update()
    {
        Debug.Log("Walking state: [UPDATE]");

        base.Update();
    }

    public override void Exit()
    {
        Debug.Log("Walking state: [EXIT]");
    }
}
