using System;
using UnityEngine;
public class Coin : MonoBehaviour
{
    public Material yellow;
    public Material red;
    public bool givesPoints;
    MeshRenderer _mesh;
    float _time;
    public static event Action<Coin> onCoinPickUp;
    void OnEnable()
    {
        _mesh = GetComponent<MeshRenderer>();
    }
    void OnTriggerEnter()
    {
        givesPoints = Mathf.RoundToInt(_time % 2) == 0;
        onCoinPickUp?.Invoke(this);
    }
    void Update()
    {
        _time += Time.deltaTime;
        _mesh.material = Mathf.RoundToInt(_time % 2) == 0 ? yellow : red;
    }
}