using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemySpawner : MonoBehaviour
{
    private Transform[] _spawnPoints;
    
    [SerializeField] private Enemy _enemyPrefab;
    private Coroutine _coroutine;

    private void Awake()
    {
        _spawnPoints = GetComponentsInChildren<Transform>();
    }

    public void Update()
    {
        if (_coroutine == null)
        _coroutine = StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        float delay = 2f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (true)
        {
            Vector3 spawnPoint = _spawnPoints[GetRandomSpawnPointIndex()].transform.position;
            
            Enemy enemy = Instantiate(_enemyPrefab, spawnPoint, Quaternion.identity);
            enemy.Init(GetRandomRotation(),GetRandomDirection());
            
            yield return wait;
        }
    }

    private Vector3 GetRandomRotation()
    {
        float angle = Random.Range(0f, 360f);
        
        return new Vector3(0, angle, 0);
    }

    private Vector3 GetRandomDirection()
    {
        List<Vector3> directions = new List<Vector3>()
        {
            Vector3.forward,
            Vector3.back,
            Vector3.left,
            Vector3.right
        };

        return directions[Random.Range(0, directions.Count)];
    }

    private int GetRandomSpawnPointIndex()
    {
        int min = 0;
        int max = _spawnPoints.Length;

        return Random.Range(min, max);
    }
}