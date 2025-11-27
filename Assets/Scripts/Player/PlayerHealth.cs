using UnityEngine;
using UnityEngine.Events;
using SurvivalGame.Combat;

namespace SurvivalGame.Player
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private int maxHealth = 5;
        [SerializeField] private UnityEvent onDamaged;
        [SerializeField] private UnityEvent onDeath;

        private int _currentHealth;

        public int CurrentHealth => _currentHealth;
        public int MaxHealth => maxHealth;

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
            }
        }

        public void Heal(int amount)
        {
            if (amount <= 0 || _currentHealth <= 0)
            {
                return;
            }

            _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, maxHealth);
        }
    }
}
