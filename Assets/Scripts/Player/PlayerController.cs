using UnityEngine;

namespace SurvivalGame.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;

        private Rigidbody2D _rigidbody2D;
        private Vector2 _movementInput;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            ReadMovementInput();
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        private void ReadMovementInput()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            _movementInput = new Vector2(horizontal, vertical).normalized;
        }

        private void MovePlayer()
        {
            Vector2 desiredVelocity = _movementInput * moveSpeed;
            Vector2 newPosition = _rigidbody2D.position + desiredVelocity * Time.fixedDeltaTime;
            _rigidbody2D.MovePosition(newPosition);
        }
    }
}
