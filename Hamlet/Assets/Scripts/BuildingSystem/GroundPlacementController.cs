using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPlacementController : MonoBehaviour
{
    [SerializeField]private GameObject placeableObjectPrefab;
    [SerializeField]private KeyCode newObjectHotkey = KeyCode.B;
    
    private GameObject currentPlaceableObject;

    public Camera cam;

    private float mouseWheelRotation;

    void Update()
    {
        HandleNewObjectHotkey();

        if(currentPlaceableObject != null)
        {
            MoveCurrentObjectToMouse();
            RotateFromMouseWheel();
            ReleaseIfClicked();
        }
    }

    private void HandleNewObjectHotkey()
    {
        if(Input.GetKeyDown(newObjectHotkey))
        {
            if(currentPlaceableObject != null)
            {
                Destroy(currentPlaceableObject);
            }
            else
            {
                currentPlaceableObject = Instantiate(placeableObjectPrefab);
            }
        }
    }

    private void MoveCurrentObjectToMouse()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo))
        {
            currentPlaceableObject.transform.position = hitInfo.point;
            currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
        if(hitInfo.collider.tag == ("Obstacle"))
        {
            currentPlaceableObject = null;
        }

    }

    private void RotateFromMouseWheel()
    {
        Debug.Log(Input.mouseScrollDelta);
        mouseWheelRotation += Input.mouseScrollDelta.y;
        currentPlaceableObject.transform.Rotate(Vector3.up, mouseWheelRotation * 10f);
    }

    private void ReleaseIfClicked()
    {
        if(Input.GetMouseButtonDown(0))
        {
            currentPlaceableObject = null;
        }
    }
}
