using UnityEngine;

public enum CharacterState
{
    Died,
    InAir,
    Moving,
    Turning,
    Standing,
    Crouching,
    Blocking,
    GetHit,
    StandAttack1,
    StandAttack2,
    CrouchAttack1,
    CrouchAttack2,
}

public class FightingCharacterController : MonoBehaviour
{
    [SerializeField] Character_FSM characterFSM;
    [SerializeField] float WalkSpeed;
    [SerializeField] float RunSpeed;
    [SerializeField] float JumpHeight;
    [SerializeField] float GravityValue;

    CharacterState characterState = CharacterState.Standing;

    public CharacterState CharacterState => characterState;



    void Start()
    {
        
    }



    /*private void OnEnable()
    {
        characterFSM.StateChanged += OnStateChanged;
    }

    private void OnDisable()
    {
        characterFSM.StateChanged -= OnStateChanged;
    }

    void OnStateChanged(CFSM_BaseState new_state)
    {
        //if (new_state is CS_Death death_state)
        //{
            //death_state.Update();
        //}

        switch(new_state)
        {
            case CS_Death:
                SetDeath();
                break;
            case CS_Idle:
                break;
        }
    }

    public void SetState(CharacterState state)
    {
        characterState = state;

        switch (characterState)
        {
            case CharacterState.Died:

                break;
            case CharacterState.InAir:
                
                break;
            case CharacterState.Moving:

                break;
            case CharacterState.Turning:

                break;
            case CharacterState.Crouching:

                break;
            case CharacterState.Blocking:

                break;
            case CharacterState.GetHit:
                
                break;
            case CharacterState.StandAttack1:

                break;
            case CharacterState.StandAttack2:

                break;
            case CharacterState.CrouchAttack1:

                break;
            case CharacterState.CrouchAttack2:

                break;
        }
    }*/
}