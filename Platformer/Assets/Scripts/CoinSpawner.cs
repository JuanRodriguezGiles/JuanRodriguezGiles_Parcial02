using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coin;
    int _rows;
    int _columns;
    List<Vector3> _emptyPositions;
    [SerializeField] float _timeThreshold;
    float _time;
    void OnEnable()
    {
        LevelCreator.onLevelCreated += GetLevelSize;
    }
    void GetLevelSize(int rows, int columns)
    {
        _rows = rows;
        _columns = columns;

        for (int rowIndex = 0; rowIndex < _rows; rowIndex++)
        {
            for (int columnIndex = 0; columnIndex < _columns; columnIndex++)
            {
                Vector3 position = new Vector3(columnIndex, 0.5f, rowIndex);
                _emptyPositions.Add(position);
            }
        }
    }
    void SpawnCoin()
    {
        int index = Random.Range(0, _emptyPositions.Count);
        Vector3 position = _emptyPositions[index];
        _emptyPositions.RemoveAt(index);
    }
    void UpdateEmptyPositions()
    void Update()
    {
        _time += Time.deltaTime;
        if (_time < _timeThreshold) return;
        SpawnCoin();
        _time = 0;
    }
}