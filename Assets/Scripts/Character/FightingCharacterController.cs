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
    CharacterState characterState = CharacterState.Standing;

    public CharacterState CharacterState => characterState;



    void Start()
    {
        
    }



    public void TryToSetState(CharacterState state)
    {
        if (characterState != state)
        {

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
    }
}