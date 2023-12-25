using UnityEngine;

namespace Player
{
    /**
     * this class has the responsability to manage the player Movements
     */
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
