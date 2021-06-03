using System;
using UnityEngine;
public class Coin : MonoBehaviour
{
    public Material yellow;
    public Material red;
    MeshRenderer _mesh;
    bool _givesPoints;
    float _time;
    public static event Action<Boolean> onCoinPickUp;
    void OnEnable()
    {
        _mesh = GetComponent<MeshRenderer>();
    }
    void OnTriggerEnter()
    {
        _givesPoints = Mathf.RoundToInt(_time % 2) == 0;
        onCoinPickUp?.Invoke(_givesPoints);
    }
    void Update()
    {
        _time += Time.deltaTime;
        _mesh.material = Mathf.RoundToInt(_time % 2) == 0 ? yellow : red;
    }
}