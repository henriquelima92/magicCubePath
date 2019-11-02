using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public LayerMask selectionLayer;
    public Material selectedMaterial;

    private InputHandler inputHolder;
    private InputRender inputRender;
    private BlockHandler blockHandler;

    private void Start()
    {
        inputHolder = new InputHandler(selectionLayer);
        inputRender = new InputRender(selectedMaterial);
        blockHandler = new BlockHandler(.51f);
    }

    private void Update()
    {
        CheckInputTrigger();
    }

    private void CheckInputTrigger()
    {
        #region Mouse Inputs
        if (Input.GetMouseButtonDown(0))
        {
            inputRender.RenderSelection(inputHolder.CheckInput());
        }
        #endregion

        #region Keyboard Inputs
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveBlock(Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveBlock(Vector2.right);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveBlock(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveBlock(Vector2.down);
        }
        #endregion
    }

    private void MoveBlock(Vector2 input)
    {
        if(blockHandler.IsMoving == false && inputHolder.CurrentSelectedObject != null)
        {
            StartCoroutine(blockHandler.Move(input, inputHolder.CurrentSelectedObject.transform));
        }
    }
}
