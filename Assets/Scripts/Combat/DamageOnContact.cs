using UnityEngine;

namespace SurvivalGame.Combat
{
    public class DamageOnContact : MonoBehaviour
    {
        [SerializeField] private int contactDamage = 1;
        [SerializeField] private float damageInterval = 0.5f;
        [SerializeField] private LayerMask targetLayers;

        private float _damageCooldown;

        private void Update()
        {
            _damageCooldown -= Time.deltaTime;
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            TryDealDamage(collision.gameObject);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            TryDealDamage(other.gameObject);
        }

        private void TryDealDamage(GameObject target)
        {
            if (_damageCooldown > 0f)
            {
                return;
            }

            if ((targetLayers.value & (1 << target.layer)) == 0)
            {
                return;
            }

            if (target.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(contactDamage);
                _damageCooldown = damageInterval;
            }
        }
    }
}
