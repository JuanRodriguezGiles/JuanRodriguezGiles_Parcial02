using System;
using UnityEngine;
using UnityEngine.Playables;

public class Player : MonoBehaviour
{
    [SerializeField] int _hp = 3;
    int _rows;
    int _columns;

    public static event Action<int> onHpChange;
    public static event Action<int> onScoreChange;
    public static event Action<int> onDeathsChange;

    PlayableDirector _timerDirector;
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
        _rows = GameManager.Instance.rowsLevel;
        _columns = GameManager.Instance.columnsLevel;
        _timerDirector = FindObjectOfType<PlayableDirector>();
        _timerDirector.Play();
    }
    void OnCoinPickUp(Coin coin)
    {
        if (coin.givesPoints)
        {
            GameManager.Instance.playerInfo.scoreCurrent += 10;
            onScoreChange?.Invoke(GameManager.Instance.playerInfo.scoreCurrent);
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
            OnPlayerDeath();
        }
    }
    void OnPlayerDeath()
    {
        GameManager.Instance.playerInfo.scoreCurrent /= 2;
        onScoreChange?.Invoke(GameManager.Instance.playerInfo.scoreCurrent);

        _hp = 3;
        onHpChange?.Invoke(_hp);

        GameManager.Instance.playerInfo.deathCount++;
        onDeathsChange?.Invoke(GameManager.Instance.playerInfo.deathCount);

        Respawn();
    }
    void Respawn()
    {
        int playerX = _columns / 2;
        int playerZ = _rows / 2;
        Vector3 position = new Vector3(playerX, 0, playerZ);

        transform.position = position;

        _timerDirector.Play();
    }
    void Update()
    {
        if (transform.position.y < -10)
        {
            OnPlayerFallen();
        }
    }
}