using UnityEngine;

public class InputHandler
{
    private Ray raycast;
    private RaycastHit hit;
    private LayerMask selectionLayer;

    public GameObject CurrentSelectedObject { get => currentSelectedObject; }
    private GameObject currentSelectedObject, lastSelectedObject;
    private Material selectedMaterial, lastMaterial;

    public InputHandler( LayerMask selectionLayer)
    {
        this.selectionLayer = selectionLayer;
    }

    public GameObject CheckInput()
    {
        Vector3 mousePosition = Input.mousePosition;
        raycast = Camera.main.ScreenPointToRay(mousePosition);

        bool blockHit = Physics.Raycast(raycast, out hit, selectionLayer);
        currentSelectedObject = hit.transform != null ? hit.transform.gameObject : null;

        //Debug.Log(string.Format("Block hit: {0}", blockHit));
        return currentSelectedObject;
    }
}
