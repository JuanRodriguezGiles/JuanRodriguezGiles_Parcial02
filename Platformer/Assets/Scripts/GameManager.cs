using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviourSingletonPersistent<GameManager>
{
    //#region INSTANCE
    //private static GameManager instance;
    //public static GameManager Get()
    //{
    //    return instance;
    //}
    //private void Awake()
    //{
    //    if (instance != null)
    //        Destroy(gameObject);
    //    else
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //}
    //#endregion
    public PlayerInfo playerInfo;
    public int rowsLevel;   
    public int columnsLevel;
    [SerializeField] float _maxTimeSeconds;
    float _time;
    public static event Action<float> onTimeChange;
    public List<Vector3> emptyPositions = new List<Vector3>();
    void Start()
    {
        _time = _maxTimeSeconds;
        playerInfo = new PlayerInfo();
    }
    void GameOver()
    {

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