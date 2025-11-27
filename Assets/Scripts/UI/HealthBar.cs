using UnityEngine;
using UnityEngine.UI;
using SurvivalGame.Player;

namespace SurvivalGame.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider healthSlider;
        [SerializeField] private PlayerHealth playerHealth;

        private void Start()
        {
            if (playerHealth != null)
            {
                UpdateHealthBar();
            }
        }

        public void UpdateHealthBar()
        {
            if (healthSlider == null || playerHealth == null)
            {
                return;
            }

            healthSlider.maxValue = playerHealth.MaxHealth;
            healthSlider.value = playerHealth.CurrentHealth;
        }
    }
}
