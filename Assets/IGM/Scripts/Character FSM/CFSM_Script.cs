using UnityEngine;

public class CFSM_Script : MonoBehaviour
{
    [SerializeField] CharacterController m_character_controller;
    [Space]
    [SerializeField] CharacterAnimation m_character_animation;
    [SerializeField] CharacterInput m_character_input;
    [Space]
    [SerializeField, Range(0, 20)] float m_jump_height = 1.0f;
    [Min(0)]
	[SerializeField] float m_walk_speed = 2.0f;
    [Min(0)]
    [SerializeField] float m_gravity = 30.0f;
    //[Space]
    //[SerializeField] InputVariant m_inputVariant;

	Character_FSM _stateMachine;



    void Start()
    {
        _stateMachine = new Character_FSM(m_character_controller, m_character_animation, m_character_input);

        _stateMachine.AddState(new CS_Idle(_stateMachine));
        _stateMachine.AddState(new CS_Moving(_stateMachine, m_walk_speed));
        _stateMachine.AddState(new CS_Jumping(_stateMachine, m_gravity, m_jump_height));

        _stateMachine.SetState<CS_Idle>();
    }

    void Update()
    {
        _stateMachine.Update();
    }
}