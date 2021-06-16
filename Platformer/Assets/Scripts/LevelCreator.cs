using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class LevelCreator : MonoBehaviour
{
    public GameObject player;
    public GameObject platform;
    public GameObject saveSpot;

    int _rows;
    int _columns;

    void Start()
    {
        _rows = GameManager.Instance.rowsLevel;
        _columns = GameManager.Instance.columnsLevel;
        BuildLevel();
    }
    void BuildLevel()
    {
        GameObject platformParent = new GameObject("Platforms");
        GameObject saveParent = new GameObject("Save Points");
        GameObject go;
        Vector3 position;

        for (int rowIndex = 0; rowIndex < _rows; rowIndex++)
        {
            for (int columnIndex = 0; columnIndex < _columns; columnIndex++)
            {
                position = new Vector3(columnIndex, 0, rowIndex);

                go = Instantiate(platform, position, Quaternion.identity, platformParent.transform);
                go.name = "Platform";

                if (rowIndex != _rows / 2 && columnIndex != _columns / 2) GameManager.Instance.emptyPositions.Add(position);

                go.GetComponent<Platform>().enabled = !(rowIndex == _rows / 2 && columnIndex == _columns / 2); //Creates safespot for player respawn
            }
        }

        for (int i = 0; i < (_rows * _columns) / (_rows * _columns / 10); i++)
        {
            int index = Random.Range(0, GameManager.Instance.emptyPositions.Count);
            position = GameManager.Instance.emptyPositions[index];
            go = Instantiate(saveSpot, position, Quaternion.identity, saveParent.transform);
            go.name = "Save Spot";
            GameManager.Instance.emptyPositions.RemoveAt(index);
        }

        int playerX = _columns / 2;
        int playerZ = _rows / 2;
        position = new Vector3(playerX, 0, playerZ);
        go = Instantiate(player, position, Quaternion.identity);
        go.name = "Player";
    }
}