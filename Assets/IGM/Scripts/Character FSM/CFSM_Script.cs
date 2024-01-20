using UnityEngine;

public class CFSM_Script : MonoBehaviour
{
    [SerializeField] CharacterController m_character_controller;
    [Space]
    [SerializeField] CharacterAnimation m_character_animation;
    [SerializeField] CharacterInput m_character_input;
    [Space]
    [SerializeField, Range(0, 50)] float m_jump_height = 1.0f;
    [Min(0)]
	[SerializeField] float m_walk_speed = 2.0f;
    [Min(0)]
    [SerializeField] float m_gravity = 30.0f;
    //[Space]
    //[SerializeField] InputVariant m_inputVariant;

	Character_FSM _stateMachine;



    public CharacterController CharController => m_character_controller;
    public CharacterAnimation CharAnimation => m_character_animation;
    public CharacterInput CharInput => m_character_input;



    void Start()
    {
        _stateMachine = new Character_FSM(this);

        _stateMachine.AddState(new CS_Idle(_stateMachine));
        _stateMachine.AddState(new CS_Moving(_stateMachine, m_walk_speed));
        _stateMachine.AddState(new CS_Jumping(_stateMachine, m_gravity, m_jump_height));

        _stateMachine.SetState<CS_Idle>();
    }

    void Update()
    {
        _stateMachine.Update();
    }

    void FixedUpdate()
    {
        _stateMachine.FixedUpdate();
    }
}