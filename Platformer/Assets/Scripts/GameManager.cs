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
    public static event Action<float> onTimeChange;
    public List<Vector3> emptyPositions = new List<Vector3>();
    [SerializeField] float _maxTimeSeconds;
    float _time;
    void Start()
    {
        _time = _maxTimeSeconds;
        playerInfo = new PlayerInfo();
    }
    void GameOver()
    {
        SqlConnection.Instance.CallUpdate();
    }
    public void LoadGameplay()
    {
        SceneManager.LoadScene("GamePlay");
        StartCoroutine(Timer());
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