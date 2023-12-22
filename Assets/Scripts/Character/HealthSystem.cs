using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    CharacterAnimation _characterAnimation;

    public bool _isDead = false;
    public bool _inBlockingState = false;

    public uint _maxHealth;
    public uint _currentHealth;

    public void SetDamage(uint damage)
    {
        if (!_inBlockingState)
        {
            _currentHealth -= damage;
            _characterAnimation.Hit();
        }

        if (_currentHealth <= 0)
        {
            _isDead = true;
            _characterAnimation.Death();
        }
    }

    public void GetHealth(uint heal_amount)
    {
        _currentHealth += heal_amount;

        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;
    }



    void Awake()
    {
        _characterAnimation = GetComponentInChildren<CharacterAnimation>();
    }
}
