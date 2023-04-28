using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _waitingTime = 2f;
    [SerializeField] private Enemy _prefabs;

    private int _respawnCount = 10;
    private float _timeToDestruction = 3f;

    private void Start()
    {
        StartCoroutine(SpawnEnemyAtTime());
    }

    private IEnumerator SpawnEnemyAtTime()
    {
        for (int i = 0; i < _respawnCount; i++)
        {
            yield return new WaitForSeconds(_waitingTime);
            int randomPointIndex = Random.Range(0, _spawnPoints.Length);
            Enemy enemy  = Instantiate(_prefabs, _spawnPoints[randomPointIndex].position, Quaternion.identity);

            yield return new WaitForSeconds(_timeToDestruction);
            Destroy(enemy.gameObject);
        }
    }
}
