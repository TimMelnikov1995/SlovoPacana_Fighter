using UnityEngine;

public enum CharacterState
{
    Move,
    Air,
    Block,
    Hit,
    StandAttack1,
    StandAttack2, 
    Crouch,
    CrouchAttack1,
    CrouchAttack2,
    Died,
}

public class FightingCharacterController : MonoBehaviour
{
    CharacterState characterState;

    public CharacterState CharacterState => characterState;

    void Start()
    {
        
    }
}