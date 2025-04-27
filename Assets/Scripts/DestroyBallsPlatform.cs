using UnityEngine;

public class DestroyBallsPlatform : MonoBehaviour
{
    [SerializeField] private PinballController _pinballController;
    private void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < _pinballController.Balls.Count; i++)
        {

            if (collision.gameObject == _pinballController.Balls[i])
            {
                Destroy(collision.gameObject);
                _pinballController.Balls.RemoveAt(i);
                break;
            }

        }
    }
}
