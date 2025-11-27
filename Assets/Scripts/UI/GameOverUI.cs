using UnityEngine;
using UnityEngine.UI;
using SurvivalGame.Systems;

namespace SurvivalGame.UI
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private Text survivalTimeText;
        [SerializeField] private GameManager gameManager;

        private void Awake()
        {
            Hide();
        }

        public void Show()
        {
            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(true);
            }

            UpdateSurvivalTime();
        }

        public void Hide()
        {
            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(false);
            }
        }

        public void UpdateSurvivalTime()
        {
            if (survivalTimeText == null || gameManager == null)
            {
                return;
            }

            float time = gameManager.SurvivalTime;
            survivalTimeText.text = $"Survival Time: {time:F1}s";
        }

        public void Restart()
        {
            gameManager?.RestartGame();
        }
    }
}
