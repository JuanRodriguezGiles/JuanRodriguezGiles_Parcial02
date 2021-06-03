using System;
using UnityEngine;
public class Player : MonoBehaviour
{
    [SerializeField] int _hp = 3;
    [SerializeField] int _score;
    [SerializeField] int _deathCount;

    int _rows;
    int _columns;

    public static event Action<int> onHpChange;
    public static event Action<int> onScoreChange;
    public static event Action onPlayerFallen;
    public static event Action onPlayerDeath;
    void OnEnable()
    {
        Coin.onCoinPickUp += OnCoinPickUp;
        onHpChange += OnHpChange;
        onPlayerDeath += OnPlayerDeath;
        onPlayerFallen += OnPlayerFallen;
    }
    void OnDisable()
    {
        Coin.onCoinPickUp -= OnCoinPickUp;
        onHpChange -= OnHpChange;
        onPlayerDeath -= OnPlayerDeath;
        onPlayerFallen -= OnPlayerFallen;
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
        Destroy(coin.gameObject);
    }
    void OnPlayerFallen()
    {
        _hp--;
        onHpChange?.Invoke(_hp);

        Respawn();
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
        onScoreChange?.Invoke(_score);

        _hp = 3;
        onHpChange?.Invoke(_hp);

        _deathCount++;

        Respawn();
    }
    void Respawn()
    {
        int playerX = _columns / 2;
        int playerZ = _rows / 2;
        Vector3 position = new Vector3(playerX, 0, playerZ);

        transform.position = position;
    }
    void Update()
    {
        if (transform.position.y < -10)
        {
            onPlayerFallen?.Invoke();
        }
    }
}