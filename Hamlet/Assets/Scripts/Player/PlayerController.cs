using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private float movementSpeed;
    public float RunSpeed = 4f;
    public float WalkSpeed = 2f;


    private void Awake()
    {

    }

    void Update()
    {
        if(PlayerSprint.isRunning)
        {
            movementSpeed = RunSpeed;

        }
        
        if(!PlayerSprint.isRunning)
        {
            movementSpeed = WalkSpeed;
        }

        HandleMovementInput();
        HandleRotationInput();

    }

    void HandleMovementInput()
    {
        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");

        Vector3 _movement = new Vector3(_horizontal, 0, _vertical);
        transform.Translate(_movement * movementSpeed * Time.deltaTime, Space.World);
    }

    void HandleRotationInput()
    {
        RaycastHit _hit;
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(_ray, out _hit))
        {
            transform.LookAt(new Vector3(_hit.point.x, transform.position.y, _hit.point.z));
        }
    }
}
