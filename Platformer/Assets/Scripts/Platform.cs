using System.Collections;
using UnityEngine;
public class Platform : MonoBehaviour
{
    [SerializeField] float _randomThreshold;
    [SerializeField] float _timeThreshold;

    float _time;
    bool _enabled = true;
    MeshRenderer _mesh;
    BoxCollider _collider;

    void Start()
    {
        _mesh = GetComponent<MeshRenderer>();
        _mesh.material.color = Color.green;
        _collider = GetComponent<BoxCollider>();
    }
    void Update()
    {
        _time += Time.deltaTime;
        if (_time < _timeThreshold) return;
        if (Random.value > _randomThreshold)
        {
            if (_enabled)
                StartCoroutine(DisablePlatform());
        }
        else if (!_enabled)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            _mesh.material.color = Color.green;
            _mesh.enabled = true;
            _collider.enabled = true;
            _enabled = true;
        }
        _time = 0;
    }
    IEnumerator DisablePlatform()
    {
        float timeToDisable = 2;
        float time = 0;

        _mesh.material.color = Color.red;
        while (time <= timeToDisable)
        {
            time += Time.deltaTime;
            yield return null;
        }

        _collider.enabled = false;
        while (transform.position.y > -5)
        {
            transform.Translate(Vector3.down * Time.deltaTime * 2);
            yield return null;
        }

        _mesh.enabled = false;
        _enabled = false;
    }
}