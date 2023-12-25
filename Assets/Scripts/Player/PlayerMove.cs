using UnityEngine;

namespace Player
{
    public class PlayerMove : MonoBehaviour
    {
        private StateManager _player;
        
        private void Start()
        {
            _player = GetComponent<StateManager>();
        }
    
        private void Update()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _player.playerSpeed, Space.World);
        }
    }
}
