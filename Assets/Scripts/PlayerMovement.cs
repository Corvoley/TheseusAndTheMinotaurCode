using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Movement movement;
    private Vector3 lastPosition;
    private void Awake()
    {
        movement = GetComponent<Movement>();
        SaveLastPosition();
    }     

    public void PlayerMove(Vector3 direction)
    {        
        movement.MoveCharacter(direction);        
    }
    public void SaveLastPosition()
    {
        lastPosition = transform.position;
    }
    public void LoadLastPosition()
    {
        transform.position = lastPosition;
    }


}
