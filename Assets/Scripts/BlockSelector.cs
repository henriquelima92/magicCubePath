using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSelector : MonoBehaviour
{
    private IInteractable blockSelected;
    private GameObject lastBlockSelected;

    public LayerMask SelectionLayer;

    private Ray raycast;
    private RaycastHit hit;

    private Material lastMaterial;
    public Material SelectedMaterial;


    private void Update()
    {
#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Vector2 touchPosition = touch.position;
                raycast = Camera.main.ScreenPointToRay(touchPosition);
            }
        }
#elif UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            raycast = Camera.main.ScreenPointToRay(mousePosition);
        }
#endif

        if (Input.GetMouseButtonUp(0))
        {
            if (Physics.Raycast(raycast, out hit, SelectionLayer))
            {
                if (hit.transform != null)
                {
                    if(lastBlockSelected != null)
                        lastBlockSelected.GetComponent<Renderer>().material = lastMaterial;

                    lastBlockSelected = hit.transform.gameObject;
                    blockSelected = hit.transform.GetComponent<IInteractable>();
                    lastMaterial = hit.transform.GetComponent<Renderer>().material;
                    hit.transform.GetComponent<Renderer>().material = SelectedMaterial;
                }
            }
            else
            {
                if (lastBlockSelected != null)
                {
                    lastBlockSelected.GetComponent<Renderer>().material = lastMaterial;
                    lastBlockSelected = null;
                    lastMaterial = null;
                }
            }
        }
    }
}
