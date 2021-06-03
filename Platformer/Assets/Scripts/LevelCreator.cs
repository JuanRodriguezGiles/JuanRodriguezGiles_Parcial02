using System;
using UnityEngine;
public class LevelCreator : MonoBehaviour
{
    public GameObject player;
    public GameObject platform;

    [SerializeField] int _rows;
    [SerializeField] int _columns;

    public static event Action<int, int> onLevelCreated;
    void Start()
    {
        BuildLevel();
    }
    void BuildLevel()
    {
        GameObject platformParent = new GameObject("Platforms");
        GameObject go;
        Vector3 position;

        for (int rowIndex = 0; rowIndex < _rows; rowIndex++)
        {
            for (int columnIndex = 0; columnIndex < _columns; columnIndex++)
            {
                position = new Vector3(columnIndex, 0, rowIndex);
                go = Instantiate(platform, position, Quaternion.identity, platformParent.transform);
                go.name = "Platform";
            }
        }

        int playerX = Mathf.RoundToInt(_columns / 2);
        int playerZ = Mathf.RoundToInt(_rows / 2);
        position = new Vector3(playerX, 0, playerZ);
        go = Instantiate(player, position, Quaternion.identity);
        go.name = "Player";

        onLevelCreated?.Invoke(_rows, _columns);
    }
}