using UnityEngine;

class CS_Death : CFSM_BaseState
{
    public CS_Death(Character_FSM state_machine) : base(state_machine) { }



    public override void Enter()
    {
        Debug.Log("Death state: [ENTER]");
    }
}