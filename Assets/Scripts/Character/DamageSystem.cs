using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    [SerializeField] uint _damageAmount;

    HealthSystem _healthSystem;

    private void Awake()
    {
        _healthSystem = GetComponentInChildren<HealthSystem>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out HealthSystem health_system))
            if (_healthSystem != health_system)
                health_system.SetDamage(_damageAmount);
    }
}
