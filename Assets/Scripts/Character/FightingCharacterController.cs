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

    CharacterState _state;



    void Start()
    {
        
    }



    public void TryToSetState(CharacterState state)
    {
        if (_state != state)
        {

        }
    }

    public void SetState(CharacterState state)
    {
        _state = state;

        switch (_state)
        {
            /*case CheckerState.Died:
                _rigidbody.angularVelocity -= _rigidbody.angularVelocity;
                _rigidbody.velocity -= _rigidbody.velocity;

                // воспроизводить анимацию смерти шашки

                //_dissolveControl.SetDissolve(1);
                _markAnimationController.Kill();
                gameObject.SetActive(false);

                TurnSystem.Instance.SetCheckerReady(this, true);
                break;
            case CheckerState.Standing:
                _markAnimationController.Pull(false);
                TurnSystem.Instance.SetCheckerReady(this, true);
                break;
            case CheckerState.Moving:
                _markAnimationController.Pull(false);
                TurnSystem.Instance.SetCheckerReady(this, false);
                break;
            case CheckerState.Turning:
                _markAnimationController.Pull(true);
                TurnSystem.Instance.SetCheckerReady(this, false);
                break;*/
        }
    }
}