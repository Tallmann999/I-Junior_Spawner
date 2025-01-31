using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _waitingTime = 2f;
    [SerializeField] private Enemy _prefabs;

    private WaitForSeconds _waitForSeconds;
    private int _respawnCount = 10;
    private float _timeToDestruction = 3f;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_waitingTime);
        StartCoroutine(SpawnEnemyAtTime());
    }

    private IEnumerator SpawnEnemyAtTime()
    {
        for (int i = 0; i < _respawnCount; i++)
        {
            yield return _waitForSeconds;
            int randomPointIndex = Random.Range(0, _spawnPoints.Length);
            Enemy enemy  = Instantiate(_prefabs, _spawnPoints[randomPointIndex].position, Quaternion.identity);
            Destroy(enemy.gameObject, _timeToDestruction);
        }
    }
}
