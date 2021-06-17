using UnityEngine;
public class Save : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        GameManager.Instance.playerInfo.scoreSaved = GameManager.Instance.playerInfo.scoreCurrent;
    }
}