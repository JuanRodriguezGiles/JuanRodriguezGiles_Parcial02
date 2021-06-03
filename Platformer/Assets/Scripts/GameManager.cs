using System;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    #region INSTANCE
    private static GameManager instance;
    public static GameManager Get()
    {
        return instance;
    }
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion
    public int rowsLevel;
    public int columnsLevel;
    [SerializeField] float _maxTimeSeconds;

    float _time;
    string userName;

    public static event Action<float> onTimeChange;

    void Start()
    {
        _time = _maxTimeSeconds;
    }
    void Update()
    {
        _time -= Time.deltaTime;
        onTimeChange?.Invoke(_time);
        if (_time <= 0)
            GameOver();
    }
    void GameOver()
    {

    }
}