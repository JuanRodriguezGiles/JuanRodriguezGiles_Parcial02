using System;
using UnityEngine;
public class Player : MonoBehaviour
{
    int _hp = 3;
    int _score;
    int _deathCount;

    int _rows;
    int _columns;

    public static event Action<int> onHpChange;
    public static event Action<int> onScoreChange;
    public static event Action onPlayerDeath;
    void OnEnable()
    {
        Coin.onCoinPickUp += OnCoinPickUp;
        onHpChange += OnHpChange;
    }
    void OnDisable()
    {
        Coin.onCoinPickUp -= OnCoinPickUp;
        onHpChange -= OnHpChange;
    }
    void Start()
    {
        _rows = GameManager.Get().rowsLevel;
        _columns = GameManager.Get().columnsLevel;
    }
    void OnCoinPickUp(Coin coin)
    {
        if (coin.givesPoints)
        {
            _score += 10;
            onScoreChange?.Invoke(_score);
        }
        else
        {
            _hp--;
            onHpChange?.Invoke(_hp);
        }
    }
    void OnHpChange(int hp)
    {
        if (hp == 0)
        {
            onPlayerDeath?.Invoke();
        }
    }

    void OnPlayerDeath()
    {
        _score /= 2;
    }
}