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

    public void Move(float movement) { _animator.SetFloat(AnimationTags.MOVEMENT, movement); }

    public void Rotate(float rotation) { _animator.SetFloat(AnimationTags.ROTATION, rotation); }

    public void Hit()
    {
        _animator.SetTrigger(AnimationTags.HIT_TRIGGER);
    }

    public void Death()
    {
        _animator.SetTrigger(AnimationTags.DEATH_TRIGGER);
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
