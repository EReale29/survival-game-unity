using System.Collections;
using UnityEngine;

namespace SurvivalGame.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyHealth enemyPrefab;
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private float initialDelay = 2f;
        [SerializeField] private float spawnInterval = 3f;
        [SerializeField] private int enemiesPerWave = 3;
        [SerializeField] private float difficultyGrowth = 0.9f;

        private bool _isSpawning;

        private void OnEnable()
        {
            StartSpawning();
        }

        public void StartSpawning()
        {
            if (_isSpawning)
            {
                return;
            }

            StartCoroutine(SpawnRoutine());
        }

        public void StopSpawning()
        {
            _isSpawning = false;
            StopAllCoroutines();
        }

        private IEnumerator SpawnRoutine()
        {
            _isSpawning = true;
            yield return new WaitForSeconds(initialDelay);

            float currentInterval = spawnInterval;
            int currentWaveSize = enemiesPerWave;

            while (_isSpawning)
            {
                SpawnWave(currentWaveSize);
                currentWaveSize = Mathf.CeilToInt(currentWaveSize / difficultyGrowth);
                currentInterval *= difficultyGrowth;
                yield return new WaitForSeconds(currentInterval);
            }
        }

        private void SpawnWave(int count)
        {
            if (enemyPrefab == null || spawnPoints == null || spawnPoints.Length == 0)
            {
                return;
            }

            for (int i = 0; i < count; i++)
            {
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            }
        }
    }
}
