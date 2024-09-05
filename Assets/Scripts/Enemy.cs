using System.Timers;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _velocity = 10f;

    private Vector3 _direction;
    private Vector3 _rotation;

    public void Update()
    {
        transform.position += _direction * Time.deltaTime;
        transform.rotation = Quaternion.Euler(_rotation);
    }

    public void Init(Vector3 rotation, Vector3 direction)
    {
        _rotation = rotation;
        _direction = direction;
    }
}