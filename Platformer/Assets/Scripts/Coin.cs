using System;
using UnityEngine;
public class Coin : MonoBehaviour
{
    public bool givesPoints;
    MeshRenderer _mesh;
    float _time;
    public static event Action<Coin> onCoinPickUp;
    void Start()
    {
        _mesh = GetComponent<MeshRenderer>();
        _mesh.material.color = Color.red;
    }
    void OnTriggerEnter()
    {
        givesPoints = _mesh.material.color == Color.yellow;
        onCoinPickUp?.Invoke(this);
    }
    void Update()
    {
        _time += Time.deltaTime;
        if (!(_time >= 1)) return;
        _mesh.material.color = _mesh.material.color == Color.yellow ? Color.red : Color.yellow;
        _time = 0;
    }
}