using UnityEditor;
using UnityEngine;

public class CFSM_Script : MonoBehaviour
{
    [SerializeField] CharacterController _characterController;
    [Space]
    [Min(0)]
    [SerializeField] float _jumpHeight = 0.0f;
    [Min(0)]
	[SerializeField] float _walkSpeed = 1.0f;
    [Min(0)]
    [SerializeField] float _gravity = 3.0f;
    //[Space]
    //[SerializeField] InputVariant m_inputVariant;

	Character_FSM _stateMachine;



    void Start()
    {
        _stateMachine = new Character_FSM();

        _stateMachine.AddState(new CS_Idle(_stateMachine));
        _stateMachine.AddState(new CS_Jumping(_stateMachine, _characterController, transform, _gravity, _jumpHeight));
        _stateMachine.AddState(new CS_Walking(_stateMachine, _characterController, transform, _walkSpeed));

        _stateMachine.SetState<CS_Idle>();
    }

    void Update()
    {
        _stateMachine.Update();
    }
}