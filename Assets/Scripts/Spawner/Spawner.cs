using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private SpawnableObject[] _spawnableObjectTemplates;
    [SerializeField] private Transform[] _spwanPoints;
    [SerializeField] private float _secondsBetweenSpawn;

    private float _elapsedTime = 0;
    private GameObject[] _spawnableObjects;

    private void Start()
    {
        _spawnableObjects = _spawnableObjectTemplates.Select(spawnableObject => spawnableObject.gameObject).ToArray();
        Initialize(_spawnableObjects);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            if(TryGetObject(out GameObject spawnableObject))
            {
                _elapsedTime = 0;

                int spawnPointNumber = Random.Range(0, _spwanPoints.Length);

                SetSpawnableObject(spawnableObject, _spwanPoints[spawnPointNumber].position);
            }
        }
    }

    private void SetSpawnableObject(GameObject spawnableObject, Vector3 spawnPoint)
    {
        spawnableObject.gameObject.SetActive(true);
        spawnableObject.transform.position = spawnPoint;
    }
}
