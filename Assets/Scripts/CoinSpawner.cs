using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinSpawner : MonoBehaviour
{
[SerializeField] private GameObject[] _coinPrefabs;

    [Header("Random Timing")]
    [SerializeField] private float _minInterval = 0.8f;
    [SerializeField] private float _maxInterval = 2.2f;

    [Header("Wave Count")]
    [SerializeField] private int _minPerWave = 1;
    [SerializeField] private int _maxPerWave = 4;

    [Header("Spawn Position")]
    [SerializeField] private float _spawnY = 2f;
    [SerializeField] private float _spawnPadding = 1f; 
    [SerializeField] private float _spreadX = 0.8f;

private float _timer;
    private float _nextSpawnTime;

    private void Start()
    {
        PickNextSpawnTime();
    }

    private void Update()
    {
        if (_coinPrefabs == null || _coinPrefabs.Length == 0) return;

        _timer += Time.deltaTime;
        if (_timer >= _nextSpawnTime)
        {
            _timer = 0f;
            SpawnWave();
            PickNextSpawnTime();
        }
    }
    private void PickNextSpawnTime()
    {
        _nextSpawnTime = Random.Range(_minInterval, _maxInterval);
    }

    private void SpawnWave()
    {
        int count = Random.Range(_minPerWave, _maxPerWave + 1);

        float baseX = GetRightEdgeX() + _spawnPadding;

        for (int i = 0; i < count; i++)
        {
            Vector3 pos = new Vector3(baseX + i * _spreadX, _spawnY, 0f);
            int index = Random.Range(0, _coinPrefabs.Length);
            Instantiate(_coinPrefabs[index], pos, Quaternion.identity);
        }
    }
     private float GetRightEdgeX()
    {
        Camera cam = Camera.main;
        Vector3 rightEdge = cam.ViewportToWorldPoint(new Vector3(1f, 0.5f, 0f));
        return rightEdge.x;
    }
}
    