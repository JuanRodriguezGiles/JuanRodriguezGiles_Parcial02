using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coin;
    GameObject _coinParent;

    [SerializeField] float _timeThreshold;
    List<Vector3> _emptyPositions;

    float _time;
    int _rows;
    int _columns;

    void OnEnable()
    {
        Coin.onCoinPickUp += UpdateEmptyPositions;
    }
    void OnDisable()
    {
        Coin.onCoinPickUp -= UpdateEmptyPositions;
    }
    void Start()
    {
        _emptyPositions = new List<Vector3>();
        _coinParent = new GameObject("Coins");

        _rows = GameManager.Get().rowsLevel;
        _columns = GameManager.Get().columnsLevel;

        GetEmptyPositions();
    }
    void GetEmptyPositions()
    {
        for (int rowIndex = 0; rowIndex < _rows; rowIndex++)
        {
            for (int columnIndex = 0; columnIndex < _columns; columnIndex++)
            {
                Vector3 position = new Vector3(columnIndex, 0.5f, rowIndex);
                _emptyPositions.Add(position);
            }
        }
    }
    void UpdateEmptyPositions(Coin _coin)
    {
        _emptyPositions.Add(_coin.transform.position);
    }
    void SpawnCoin()
    {
        int index = Random.Range(0, _emptyPositions.Count);
        Vector3 position = _emptyPositions[index];
        GameObject go = Instantiate(coin, position, Quaternion.identity, _coinParent.transform);
        go.name = "Coin";
        _emptyPositions.RemoveAt(index);
    }
    void Update()
    {
        _time += Time.deltaTime;
        if (_time < _timeThreshold) return;
        SpawnCoin();
        _time = 0;
    }
}