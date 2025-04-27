using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class PinballController : MonoBehaviour
{
    [SerializeField] private Transform _springConnectorTransform;
    [SerializeField] private Transform _underPosition;
    [SerializeField] private Transform _topPosition;
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private float _springPower;

    private float _currentSpringConnectorSpeed;
    private float _springTensionSpeed;
    private Transform _targetPosition;

    public List<GameObject> Balls = new();

    public int MaximumAmountBalls;

    private void Awake()
    {
        _springTensionSpeed = _springPower / 50;
    }
    //я не стал разделять логику и строить сложные абстракции ибо задача слишком лёгкая
    // и не будет в дальнейшем расширяться
    private void Update()
    {
        if (_springConnectorTransform.position == _underPosition.position)
        {
            _currentSpringConnectorSpeed = _springPower;
            _targetPosition = _topPosition;
            if (Balls.Count < MaximumAmountBalls)
            {
                Balls.Add(Instantiate(_ballPrefab, _underPosition.position, _underPosition.rotation));
            }
        }
        else if (_springConnectorTransform.position == _topPosition.position)
        {
            _targetPosition = _underPosition;
            _currentSpringConnectorSpeed = _springTensionSpeed;
        }

       _springConnectorTransform.position =  Vector3.MoveTowards(_springConnectorTransform.position, _targetPosition.position, _currentSpringConnectorSpeed);
    }
}
