using UnityEngine;

namespace SurvivalGame.Combat
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed = 12f;
        [SerializeField] private int damage = 1;
        [SerializeField] private float lifetime = 3f;
        [SerializeField] private LayerMask damageLayers;

        private Rigidbody2D _rigidbody2D;
        private Vector2 _direction;
        private float _lifeTimer;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            _lifeTimer = lifetime;
        }

        private void FixedUpdate()
        {
            MoveBullet();
            UpdateLifetime();
        }

        public void Initialize(Vector2 direction)
        {
            _direction = direction.normalized;
        }

        private void MoveBullet()
        {
            Vector2 movement = _direction * speed * Time.fixedDeltaTime;
            _rigidbody2D.MovePosition(_rigidbody2D.position + movement);
        }

        private void UpdateLifetime()
        {
            _lifeTimer -= Time.fixedDeltaTime;
            if (_lifeTimer <= 0f)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((damageLayers.value & (1 << other.gameObject.layer)) == 0)
            {
                return;
            }

            if (other.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
