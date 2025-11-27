using UnityEngine;

namespace SurvivalGame.Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 3f;
        [SerializeField] private float rotationSpeed = 720f;

        private Rigidbody2D _rigidbody2D;
        private Transform _target;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                _target = playerObject.transform;
            }
        }

        private void FixedUpdate()
        {
            if (_target == null)
            {
                return;
            }

            MoveTowardsTarget();
            RotateTowardsTarget();
        }

        private void MoveTowardsTarget()
        {
            Vector2 direction = (_target.position - transform.position).normalized;
            Vector2 newPosition = _rigidbody2D.position + direction * moveSpeed * Time.fixedDeltaTime;
            _rigidbody2D.MovePosition(newPosition);
        }

        private void RotateTowardsTarget()
        {
            Vector2 direction = (_target.position - transform.position).normalized;
            float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            float smoothedAngle = Mathf.MoveTowardsAngle(_rigidbody2D.rotation, targetAngle, rotationSpeed * Time.fixedDeltaTime);
            _rigidbody2D.MoveRotation(smoothedAngle);
        }
    }
}
