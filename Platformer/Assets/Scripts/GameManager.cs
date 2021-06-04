using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public string userName;

    public static event Action<float> onTimeChange;

    void Start()
    {
        _time = _maxTimeSeconds;
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