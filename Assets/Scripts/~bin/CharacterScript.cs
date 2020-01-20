using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    private CharacterController _controller;
    public GameObject Head;
    //public Transform _body;
    //private Rigidbody _rb;
    
    public float Speed = 3.5f;  // Rough walking speed
    public float MouseSensitivity = 100f;
    public float FakeGravity = 1.5f;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        //_controller.Rotate = transform.parent.eulerAngles;
        //_rb = GetComponent<Rigidbody>();
        //Physics.gravity = new Vector3(0, -1.0F, 0) * transform.parent.eulerAngles;
    }

    void FixedUpdate()
    {
        // Set PC movement
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Speed;
        // Set Gravitational movement
        if (_controller.isGrounded == false) move += Physics.gravity;
        // Transform by ship rotation
        move = Quaternion.Euler(transform.eulerAngles) * move * Time.deltaTime;


        _controller.Move(move);

        //transform.position = transform.position + move;

        //_controller.Move(move * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;
        //_rb.angularVelocity = new Vector3(0,0,0);
        //_rb.AddTorque(-_rb.angularVelocity);
        transform.Rotate(0, mouseX, 0);
        Head.transform.Rotate(mouseY, 0, 0);

        //Debug.Log(_body.eulerAngles);

    }

}
        //You'll want this later for non-character objects
        //Physics.gravity = Quaternion.Euler(transform.parent.eulerAngles) * new Vector3(0,-1,0);