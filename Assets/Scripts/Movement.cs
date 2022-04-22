using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private bool isMoving;
    [SerializeField]private LayerMask mask;
    [SerializeField] private float timeToMove = 0.2f;
    public void MoveCharacter(Vector3 direction)
    {
        if (!isMoving)
        {
            StartCoroutine(MoveCour(direction));
        }
    }
    private IEnumerator MoveCour(Vector3 direction)
    {
        if (CanMove(direction))
        {
            isMoving = true;
            float timePassed = 0;

            Vector3 pos = transform.position;
            Vector3 targetPos = pos + direction;

            while (timePassed < timeToMove)
            {
                transform.position = Vector3.Lerp(pos, targetPos, (timePassed / timeToMove));
                timePassed += Time.deltaTime;
                yield return null;
                Debug.DrawRay(transform.position, direction / 2, Color.red);
            }

            transform.position = targetPos;
            isMoving = false;
        }        
    }

    private bool CanMove(Vector3 direction)
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, direction, 0.5f , mask);        
        return raycastHit.collider == null;
    }
}
