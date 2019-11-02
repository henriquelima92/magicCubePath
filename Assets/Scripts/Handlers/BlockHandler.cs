using System.Collections;
using UnityEngine;

public class BlockHandler
{
    public bool IsMoving { get => isMoving; }
    private bool isMoving = false;

    private Transform selectedObject;
    private float collisionDistance;


    public BlockHandler(float collisionDistance)
    {
        this.collisionDistance = collisionDistance;
    }

    public IEnumerator Move(Vector2 inputDirection, Transform selectedObject)
    {
        this.selectedObject = selectedObject;
        Vector3 startPosition = this.selectedObject.position;
        Vector3 destinationPosition = this.selectedObject.position + GetCameraDirection(inputDirection);

        Debug.Log("Destination position: " + destinationPosition);

        if (CanMove(inputDirection) == true )//|| !LevelController.Instance.IsInsideGrid(destinationPosition))
        {
            yield break;
        }

        isMoving = true;
        float time = 0;

        while(time < 1f)
        {
            this.selectedObject.position = Vector3.Lerp(startPosition, destinationPosition, time);
            time += Time.deltaTime / GameUtilities.BlockMovementTime;
            yield return new WaitForEndOfFrame();
        }

        this.selectedObject.position = destinationPosition;
        isMoving = false;
        this.selectedObject = null;
    }

    private bool CanMove(Vector2 inputDirection)
    {
        bool canMove = Physics.Raycast(selectedObject.position, GetCameraDirection(inputDirection), collisionDistance);
        return canMove;
    }

    private Vector3 GetCameraDirection(Vector2 input)
    {
        Transform cam = Camera.main.transform;
        Vector3 camF = cam.up;
        Vector3 camR = cam.right;

        return (camF * input.y + camR * input.x);
    }
}
