using UnityEngine;
public class TimeScale : MonoBehaviour
{
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Play()
    {
        Time.timeScale = 1;
    }
}