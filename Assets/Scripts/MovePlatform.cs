using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private Transform _leftPosition;
    [SerializeField] private Transform _rightPosition;
    [SerializeField] private float _platformSpeed;

    private Transform _targetPosition;

    private void Start()
    {
        _targetPosition = _rightPosition;
        _platformSpeed = 0.01f;
    }
    private void Update()
    {
        if (transform.position == _leftPosition.position)
        {
            _targetPosition = _rightPosition;
        }
        else if (transform.position == _rightPosition.position)
        {
            _targetPosition = _leftPosition;
        }
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition.position, _platformSpeed);
    }
}
