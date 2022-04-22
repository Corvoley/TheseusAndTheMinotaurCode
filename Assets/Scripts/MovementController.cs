using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private EnemyMovement enemy;
    private bool hasMoveFinished = true;
    private Vector3 direction;

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && hasMoveFinished)
        {
            direction = Vector3.up;
            StartCoroutine(TurnMovementCour());

        }
        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && hasMoveFinished)
        {
            direction = Vector3.down;
            StartCoroutine(TurnMovementCour());
        }
        if ((Input.GetKeyDown(KeyCode.A ) || Input.GetKeyDown(KeyCode.LeftArrow)) && hasMoveFinished)
        {
            direction = Vector3.left;
            StartCoroutine(TurnMovementCour());
        }
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && hasMoveFinished)
        {
            direction = Vector3.right;
            StartCoroutine(TurnMovementCour());
        }
        if(Input.GetKeyDown(KeyCode.Space) && hasMoveFinished)
        {
            direction = Vector3.zero;
            WaitTurn();
        }
    }

    public void UndoLastMovement()
    {
        player.LoadLastPosition();
        enemy.LoadLastPosition();
    }
    private IEnumerator TurnMovementCour()
    {
        hasMoveFinished = false;
        player.SaveLastPosition();
        enemy.SaveLastPosition();
        player.PlayerMove(direction);
        yield return new WaitForSeconds(0.2f);
        enemy.MoveEnemy();
        yield return new WaitForSeconds(0.25f);
        enemy.MoveEnemy();
        yield return new WaitForSeconds(0.25f);
        hasMoveFinished = true;
    }
    public void WaitTurn()
    {
        StartCoroutine(WaitTurnCour());
    }
    private IEnumerator WaitTurnCour()
    {
        hasMoveFinished = false;        
        enemy.MoveEnemy();
        yield return new WaitForSeconds(0.25f);
        enemy.MoveEnemy();
        yield return new WaitForSeconds(0.25f);
        hasMoveFinished = true;
    }

}
