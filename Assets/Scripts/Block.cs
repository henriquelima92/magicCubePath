using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour, IInteractable
{
    public bool IsInteractable { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public bool IsSelected { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public float RayDistance;
    private bool isMoving = false;

    public void DoInteraction()
    {
        if (isMoving == false)
        {
            Vector2 inputMov = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (CanMove(inputMov) == false)
                {
                    StartCoroutine(UnitMove(inputMov));
                }
            }

            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (CanMove(inputMov) == false)
                {
                    StartCoroutine(UnitMove(inputMov));
                }
            }

            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (CanMove(inputMov) == false)
                {
                    StartCoroutine(UnitMove(inputMov));
                }
            }

            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (CanMove(inputMov) == false)
                {
                    StartCoroutine(UnitMove(inputMov));
                }
            }
        }
    }

    public void ResetInteractable()
    {
        throw new System.NotImplementedException();
    }

    private Vector3 Move(Vector2 input)
    {
        Transform cam = Camera.main.transform;
        Vector3 camF = cam.up;
        Vector3 camR = cam.right;

        return (camF * input.y + camR * input.x);
    }

    private bool CanMove(Vector2 direction)
    {
        bool canMove = Physics.Raycast(transform.position, Move(direction), RayDistance);
        //Debug.Log(canMove);
        return canMove;
    }

    private IEnumerator UnitMove(Vector2 direction)
    {
        isMoving = true;

        Vector3 startPosition = transform.position;
        Vector3 destinationPosition = transform.position + Move(direction);
        float time = 0;

        while (time < 1f)
        {
            transform.position = Vector3.Lerp(startPosition, destinationPosition, time);
            time += Time.deltaTime / GameUtilities.BlockMovementTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = destinationPosition;
        isMoving = false;
    }
}
