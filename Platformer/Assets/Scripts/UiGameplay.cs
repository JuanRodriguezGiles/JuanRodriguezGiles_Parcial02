using TMPro;
using UnityEngine;
public class UiGameplay : MonoBehaviour
{
    public TMP_Text timeText;
    public TMP_Text scoreText;
    public TMP_Text hpText;
    public TMP_Text deathsText;
    public GameObject gameOverPanel;
    void OnEnable()
    {
        GameManager.onTimeChange += UpdateTimeText;
        Player.onHpChange += UpdateHpText;
        Player.onScoreChange += UpdateScoreText;
        Player.onDeathsChange += UpdateDeathsText;
        GameManager.onGameOver += OnGameOver;
    }
    void OnDisable()
    {
        GameManager.onTimeChange -= UpdateTimeText;
        Player.onHpChange -= UpdateHpText;
        Player.onScoreChange -= UpdateScoreText;
        Player.onDeathsChange -= UpdateDeathsText;
        GameManager.onGameOver -= OnGameOver;
    }
    void UpdateTimeText(float time)
    {
        timeText.text = Mathf.RoundToInt(time).ToString();
    }
    void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }
    void UpdateHpText(int hp)
    {
        hpText.text = hp.ToString();
    }
    void UpdateDeathsText(int deaths)
    {
        deathsText.text = deaths.ToString();
    }
    void OnGameOver()
    {
        gameOverPanel.SetActive(true);
    }
}