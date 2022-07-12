using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public Camera Camera;

    public Transform followTransform;
    public Transform cameraTransform;

    public float camNormalSpeed;
    public float camFastSpeed;
    public float camMoveSpeed;
    public float camMoveTime;
    public float camRotationAmount;

    public Vector3 zoomAmount;
    public Vector3 newZoom;
    public Vector3 newPosition;
    public Quaternion newRotation;

    public Vector3 dragStartPosition;
    public Vector3 dragCurPosition;
    public Vector3 rotateStartPosition;
    public Vector3 rotateCurPosition;


    void Start()
    {
        instance = this;
        
        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraTransform.localPosition;
    }

    void Update()
    {
        if(followTransform != null)
        {
            transform.position = followTransform.position;
        }
        else
        {
        CamMouseInput();
        CamKeyboardInput();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            followTransform = null;
        }
    }

    void CamMouseInput()
    {
        if(Input.mouseScrollDelta.y !=0)
        {
            newZoom += Input.mouseScrollDelta.y * zoomAmount;
        }

        if(Input.GetKeyDown(KeyCode.LeftAlt) && Input.GetMouseButtonDown(0))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);

            float entry;

            if(plane.Raycast(ray, out entry))
            {
                dragStartPosition = ray.GetPoint(entry);
            }
        }
        if(Input.GetKey(KeyCode.LeftAlt) && Input.GetMouseButton(0))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);

            float entry;

            if(plane.Raycast(ray, out entry))
            {
                dragCurPosition = ray.GetPoint(entry);

                newPosition = transform.position +  dragStartPosition - dragCurPosition;
            }
        }

        if(Input.GetMouseButtonDown(2))
        {
            rotateStartPosition = Input.mousePosition;
        }
        if(Input.GetMouseButton(2))
        {
            rotateCurPosition = Input.mousePosition;

            Vector3 difference = rotateStartPosition - rotateCurPosition;

            rotateStartPosition = rotateCurPosition;

            newRotation *= Quaternion.Euler(Vector3.up * (-difference.x / 5f));
        }
    }

    void CamKeyboardInput()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            camMoveSpeed = camFastSpeed;
        }
        else
        {
            camMoveSpeed = camNormalSpeed;
        }

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            newPosition += (transform.forward * camMoveSpeed);
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            newPosition += (transform.forward * -camMoveSpeed);
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition += (transform.right * camMoveSpeed);
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += (transform.right * -camMoveSpeed);
        }

        if(Input.GetKey(KeyCode.Q))
        {
            newRotation *= Quaternion.Euler(Vector3.up * camRotationAmount);
        }
        if(Input.GetKey(KeyCode.E))
        {
            newRotation *= Quaternion.Euler(Vector3.up * -camRotationAmount);
        }

        if(Input.GetKey(KeyCode.R))
        {
            newZoom += zoomAmount;
        }
        if(Input.GetKey(KeyCode.F))
        {
            newZoom -= zoomAmount;
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * camMoveTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * camMoveTime);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * camMoveTime);
    }
}
