using UnityEngine;

public class InputRender
{
    private Material selectedMaterial, lastMaterial;
    private GameObject currentSelectedObject, lastSelectedObject;

    public InputRender(Material selectedMaterial)
    {
        this.selectedMaterial = selectedMaterial;
    }

    public void RenderSelection(GameObject selectable)
    {

        if (lastSelectedObject != null)
        {
            lastSelectedObject.GetComponent<Renderer>().material =
                lastSelectedObject != null && lastMaterial != null ? lastMaterial : null;
        }

        if (selectable != null)
        {
            lastSelectedObject = selectable;
            lastMaterial = selectable.GetComponent<Renderer>().material;
            selectable.GetComponent<Renderer>().material = selectedMaterial;
        }
    }
}
