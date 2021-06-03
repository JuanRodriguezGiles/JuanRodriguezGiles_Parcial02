using System;
using UnityEngine;
public class LevelCreator : MonoBehaviour
{
    public GameObject player;
    public GameObject platform;

    int _rows;
    int _columns;

    void Start()
    {
        _rows = GameManager.Get().rowsLevel;
        _columns = GameManager.Get().columnsLevel;
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

                go.GetComponent<Platform>().enabled = !(rowIndex == _rows / 2 && columnIndex == _columns / 2); //Creates safespot for player respawn
            }
        }

        int playerX = _columns / 2;
        int playerZ = _rows / 2;
        position = new Vector3(playerX, 0, playerZ);
        go = Instantiate(player, position, Quaternion.identity);
        go.name = "Player";
    }
}