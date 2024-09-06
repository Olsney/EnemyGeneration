using UnityEngine;

public class Stalker : MonoBehaviour
{
    [SerializeField] private float _speed = 11f;

    private Transform _target;

    private void Update()
    {
        transform.position = 
            Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    public void Init(Transform target)
    {
        _target = target;
    }
}