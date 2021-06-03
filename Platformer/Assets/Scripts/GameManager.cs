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
    string playerName;
    void Update()
    {
        _time += Time.deltaTime;
        if (_time >= _maxTimeSeconds)
            GameOver();
    }
    void GameOver()
    {

    }
}