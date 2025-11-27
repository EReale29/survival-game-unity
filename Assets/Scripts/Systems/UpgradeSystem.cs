using UnityEngine;

namespace SurvivalGame.Systems
{
    public class UpgradeSystem : MonoBehaviour
    {
        [SerializeField] private float damageMultiplier = 1f;
        [SerializeField] private float fireRateMultiplier = 1f;

        public float DamageMultiplier => damageMultiplier;
        public float FireRateMultiplier => fireRateMultiplier;

        public void ApplyDamageUpgrade(float bonus)
        {
            damageMultiplier += bonus;
        }

        public void ApplyFireRateUpgrade(float bonus)
        {
            fireRateMultiplier += bonus;
        }
    }
}
