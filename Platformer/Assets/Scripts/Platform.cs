using UnityEngine;
public class Platform : MonoBehaviour
{
    [SerializeField] float _randomThreshold;
    [SerializeField] float _timeThreshold;

    float _time;
    MeshRenderer _mesh;
    BoxCollider _collider;

    void Start()
    {
        _mesh = GetComponent<MeshRenderer>();
        _collider = GetComponent<BoxCollider>();
    }
    void Update()
    {
        _time += Time.deltaTime;
        if (_time < _timeThreshold) return;
        if (Random.value > _randomThreshold)
        {
            _mesh.enabled = false;
            _collider.enabled = false;
        }
        else
        {
            _mesh.enabled = true;
            _collider.enabled = true;
        }
        _time = 0;
    }
}