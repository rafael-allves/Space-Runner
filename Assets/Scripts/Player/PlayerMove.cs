using UnityEngine;

using Environment; 

namespace Player
{
    /**
     * Enum to represent movement directions.
     */
    public enum MovementDirection
    {
        Idle,
        Left,
        Right,
        Top,
        Bottom
    }

    /**
     * This class manages the player movements.
     */
    public class PlayerMove : MonoBehaviour
    {
        private StateManager _player;
        private Transform _transform;
        private readonly float _xAxisSpeed = 4f;
        private MovementDirection _moveDirection = MovementDirection.Idle;

        // Define the points the player can move to
        private readonly float[] _movePoints = new float[] {-LevelBoundary.EdgeBorder, 0f, LevelBoundary.EdgeBorder}; // Example positions
        private int _currentPointIndex = 1; // Starting at the middle point (index 1 in this case)

        private void Awake()
        {
            _player = GetComponent<StateManager>();
            _transform = transform;
        }

        private void Update()
        {
            CheckForInput();
            MovePlayer();
        }

        private void CheckForInput()
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (_currentPointIndex < _movePoints.Length - 1)
                {
                    _currentPointIndex++;
                    _moveDirection = MovementDirection.Right;
                }
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (_currentPointIndex > 0)
                {
                    _currentPointIndex--;
                    _moveDirection = MovementDirection.Left;
                }
            }
        }

        private void MovePlayer()
        {
            _transform.Translate(Vector3.forward * Time.deltaTime * _player.playerSpeed, Space.World);
            HandleMovement();
        }

        private void HandleMovement()
        {
            if (_moveDirection != MovementDirection.Idle)
            {
                Vector3 newPosition = _transform.position;
                MoveTowardsDirection(ref newPosition, _movePoints[_currentPointIndex]);
                _transform.position = newPosition;
            }
        }

        private void MoveTowardsDirection(ref Vector3 currentPosition, float targetX)
        {
            currentPosition.x = Mathf.MoveTowards(currentPosition.x, targetX, _xAxisSpeed * Time.deltaTime);
            
            float tolerance = 0.001f;
            
            if (Mathf.Abs(currentPosition.x - targetX) < tolerance)
                _moveDirection = MovementDirection.Idle;
        }
    }
}