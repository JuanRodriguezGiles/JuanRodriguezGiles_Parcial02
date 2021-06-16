using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coin;
    GameObject _coinParent;

    [SerializeField] float _timeThreshold;

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
        _coinParent = new GameObject("Coins");

        _rows = GameManager.Instance.rowsLevel;
        _columns = GameManager.Instance.columnsLevel;
    }
    void UpdateEmptyPositions(Coin _coin)
    {
        GameManager.Instance.emptyPositions.Add(_coin.transform.position);
    }
    void SpawnCoin()
    {
        int index = Random.Range(0, GameManager.Instance.emptyPositions.Count);
        Vector3 position = GameManager.Instance.emptyPositions[index] + new Vector3(0, 0.5f, 0);
        GameObject go = Instantiate(coin, position, Quaternion.identity, _coinParent.transform);
        go.name = "Coin";
        GameManager.Instance.emptyPositions.RemoveAt(index);
    }
    void Update()
    {
        _time += Time.deltaTime;
        if (_time < _timeThreshold) return;
        SpawnCoin();
        _time = 0;
    }
}