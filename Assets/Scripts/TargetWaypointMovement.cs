using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class TargetWaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed = 15f;

    private Transform[] _points;
    private int _currentPointIndex;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        Transform target = _points[_currentPointIndex];

        transform.position =
            Vector3.MoveTowards(transform.position, target.transform.position, _speed * Time.deltaTime);

        if ((transform.position - target.transform.position).magnitude < 0.1f)
            _currentPointIndex++;

        if (_currentPointIndex >= _points.Length)
            _currentPointIndex = 0;
    }
    
    
}