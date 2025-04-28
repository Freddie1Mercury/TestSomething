using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovePlatform : MonoBehaviour
{
     private Vector3 _leftPosition;
     private Vector3 _rightPosition;

    [SerializeField] private float _platformSpeed;
    [SerializeField] private float _platformMoveDistance;

    private Rigidbody _movePlatformRigidbody;

    private Vector3 _move;

    private void Start()
    {
        _platformMoveDistance = 3;
        _move = new Vector3(1,0,0);
        _platformSpeed = 5f;
        _movePlatformRigidbody = GetComponent<Rigidbody>();
        _leftPosition = transform.position + new Vector3(-_platformMoveDistance,0,0);
        _rightPosition = transform.position + new Vector3(_platformMoveDistance, 0, 0);
    }
    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, _leftPosition) < 0.1)
        {
            _move = new Vector3(1, 0, 0);
        }
        else if (Vector3.Distance(transform.position,_rightPosition) < 0.1)
        {
            _move = new Vector3(-1, 0, 0);
        }
        _movePlatformRigidbody.MovePosition(transform.position + _move * _platformSpeed * Time.fixedDeltaTime);

    }
}
