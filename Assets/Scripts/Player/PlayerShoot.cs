using UnityEngine;
using SurvivalGame.Combat;

namespace SurvivalGame.Player
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] private Transform firePoint;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private float fireRate = 4f;
        [SerializeField] private AudioSource shootAudio;

        private float _fireCooldown;
        private Camera _mainCamera;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            HandleShootInput();
        }

        private void HandleShootInput()
        {
            _fireCooldown -= Time.deltaTime;

            if (Input.GetButton("Fire1") && _fireCooldown <= 0f)
            {
                Shoot();
                _fireCooldown = 1f / fireRate;
            }
        }

        private void Shoot()
        {
            if (_mainCamera == null || bulletPrefab == null || firePoint == null)
            {
                return;
            }

            Vector3 mouseScreenPosition = Input.mousePosition;
            Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(mouseScreenPosition);
            Vector2 direction = (worldPosition - firePoint.position).normalized;

            Bullet bulletInstance = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            bulletInstance.Initialize(direction);

            if (shootAudio != null)
            {
                shootAudio.Play();
            }
        }
    }
}
