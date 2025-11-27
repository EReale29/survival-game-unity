using UnityEngine;
using UnityEngine.Events;
using SurvivalGame.Combat;

namespace SurvivalGame.Enemies
{
    public class EnemyHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private int maxHealth = 2;
        [SerializeField] private UnityEvent onDamaged;
        [SerializeField] private UnityEvent onDeath;

        private int _currentHealth;

        private void Awake()
        {
            _currentHealth = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            if (damage <= 0 || _currentHealth <= 0)
            {
                return;
            }

            _currentHealth = Mathf.Max(0, _currentHealth - damage);
            onDamaged?.Invoke();

            if (_currentHealth == 0)
            {
                onDeath?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
