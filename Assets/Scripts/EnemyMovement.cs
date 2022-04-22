using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    private Movement movement;
    private Vector3 dir;
    private Vector3 lastPosition;
    private void Awake()
    {
        movement = GetComponent<Movement>();
        SaveLastPosition();
    }
    public void MoveEnemy()
    {        
        movement.MoveCharacter(FindPlayerDirToMove());
    }

    public void SaveLastPosition()
    {
        lastPosition = transform.position;
    }
    public void LoadLastPosition()
    {
        transform.position = lastPosition;
    }

    private Vector3 FindPlayerDirToMove()
    {       
        Vector3 targetPos = (player.transform.position - transform.position).normalized;

        if (haveRightHorWall() && haveLeftHorWall())
        {

            if (targetPos.y > 0)
            {
                dir = Vector3.up;
            }
            else if (targetPos.y < 0)
            {
                dir = Vector3.down;
            }
            else if (targetPos.x > 0)
            {
                dir = Vector3.right;
            }
            else if (targetPos.x < 0)
            {
                dir = Vector3.left;
            }
            else
            {
                dir = Vector3.zero;
            }
        }
        else if (haveLeftHorWall())
        {
            if (targetPos.x > 0)
            {
                dir = Vector3.right;
            }
            else if (targetPos.y > 0)
            {
                dir = Vector3.up;
            }
            else if (targetPos.y < 0)
            {
                dir = Vector3.down;
            }
            else if (targetPos.x < 0)
            {
                dir = Vector3.left;
            }
            else
            {
                dir = Vector3.zero;
            }


        }
        else if (haveRightHorWall())
        {
            if (targetPos.x < 0)
            {
                dir = Vector3.left;
            }

            else if (targetPos.y > 0)
            {
                dir = Vector3.up;
            }
            else if (targetPos.y < 0)
            {
                dir = Vector3.down;
            }
            else if (targetPos.x > 0)
            {
                dir = Vector3.right;
            }
            else
            {
                dir = Vector3.zero;
            }
        }
        else
        {
            if (targetPos.x > 0)
            {
                dir = Vector3.right;
            }
            else if (targetPos.x < 0)
            {
                dir = Vector3.left;
            }
            else if (targetPos.y > 0)
            {
                dir = Vector3.up;
            }
            else if (targetPos.y < 0)
            {
                dir = Vector3.down;
            }
            else
            {
                dir = Vector3.zero;
            }
        }        
       return dir;
    }
    private bool haveLeftHorWall()
    {
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, 0.5f);

        if (hitLeft)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool haveRightHorWall()
    {
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, 0.5f);

        if (hitRight)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
