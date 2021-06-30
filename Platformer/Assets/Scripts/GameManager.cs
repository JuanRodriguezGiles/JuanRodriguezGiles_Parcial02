using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviourSingletonPersistent<GameManager>
{
    public PlayerInfo playerInfo;
    public int rowsLevel;   
    public int columnsLevel;
    [SerializeField] float _maxTimeSeconds;
    public static event Action<float> onTimeChange;
    public static event Action onGameOver;
    public List<Vector3> emptyPositions = new List<Vector3>();
    float _time;
    void Start()
    {
        _time = _maxTimeSeconds;
        playerInfo = new PlayerInfo();
    }
    void GameOver()
    {
        Time.timeScale = 0;
        onGameOver?.Invoke();
    }
    public void LoadGameplay()
    {
        SceneManager.LoadScene("GamePlay");
        StartCoroutine(Timer());
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    IEnumerator Timer()
    {
        while (_time > 0)
        {
            _time -= Time.deltaTime;
            onTimeChange?.Invoke(_time);
            yield return null;
        }
        GameOver();
    }
}