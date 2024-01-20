using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;



    public void ChangeLayer(bool crouch = true)
    {
        if (crouch)
            _animator.SetLayerWeight(1, 1);
        else
            _animator.SetLayerWeight(1, 0);
    }

    public void CrossFadeAnimation()
    {
        _animator.CrossFade("Crouch", 0.1f);
    }

    public void HorizontalMove(float movement) { _animator.SetFloat(AnimationTags.HORIZONTAL_MOVEMENT, movement); }

    public void VerticalMove(int movement) { _animator.SetInteger(AnimationTags.VERTICAL_MOVEMENT, movement); }

    public void Rotate(float rotation) { _animator.SetFloat(AnimationTags.ROTATION, rotation); }

    public void SetOnFloor(bool state)
    {
        _animator.SetBool(Tags.ON_FLOOR_TAG, state);
    }

    public void Hit()
    {
        _animator.SetTrigger(AnimationTags.HIT_TRIGGER);
    }

    public void Death()
    {
        _animator.SetTrigger(AnimationTags.DEATH_TRIGGER);
    }

    public void Jump()
    {
        _animator.CrossFade("Jump Start", 0.1f);
    }

    public void Land()
    {
        _animator.CrossFade("Jump End", 0.1f, 0);
    }

    public void SetAnimationBoolByName(string bool_name, bool state)
    {
        _animator.SetBool(bool_name, state);
    }

    public void SetAnimationTriggerByName(string trigger_name)
    {
        _animator.SetTrigger(trigger_name);
    }

    public void EnemyAttack(int attack)
    {
        if (attack == 0)
            _animator.SetTrigger(AnimationTags.PUNCH_1_TRIGGER);
        if (attack == 1)
            _animator.SetTrigger(AnimationTags.PUNCH_2_TRIGGER);
        if (attack == 2)
            _animator.SetTrigger(AnimationTags.PUNCH_3_TRIGGER);
    } // enemy atack



    void Awake()
    {
        _animator = GetComponent<Animator>();
    }
}
