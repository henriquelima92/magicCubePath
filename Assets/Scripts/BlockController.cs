using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public LayerMask selectionLayer;
    public Material selectedMaterial;

    private InputHandler inputHolder;
    private InputRender inputRender;

    private void Start()
    {
        inputHolder = new InputHandler(selectionLayer);
        inputRender = new InputRender(selectedMaterial);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            inputRender.RenderSelection(inputHolder.CheckInput());
        }
    }
}
