using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace SurvivalGame.Systems
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private UnityEvent onGameOver;

        private float _survivalTime;
        private bool _isGameOver;

        public float SurvivalTime => _survivalTime;

        private void Update()
        {
            if (_isGameOver)
            {
                return;
            }

            _survivalTime += Time.deltaTime;
        }

        public void TriggerGameOver()
        {
            if (_isGameOver)
            {
                return;
            }

            _isGameOver = true;
            onGameOver?.Invoke();
        }

        public void RestartGame()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}
