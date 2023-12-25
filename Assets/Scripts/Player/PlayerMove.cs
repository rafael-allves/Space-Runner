using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Player player;
    
    private void Start()
    {
        player = GetComponent<Player>();
    }
    
    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * player.playerSpeed, Space.World);
    }
}
