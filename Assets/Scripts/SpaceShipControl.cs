using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipControl : MonoBehaviour
{
    // Unity Physics body
    private Rigidbody _rb;
    private AudioLowPassFilter _alpf;

    public Transform _playerBody;

    public float Tonnage = 1000;
    public float Acceleration = 50;
    public float Torque = 1;
    public float InertialDampener = 10;

    ////////////////////////////////////////////////////////////////////////
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _alpf = GetComponent<AudioLowPassFilter>();
        _rb.mass = Tonnage * 1000;
        Acceleration *= _rb.mass;   // Use as Force
        Torque *= _rb.mass;
    }

    ////////////////////////////////////////////////////////////////////////
    void FixedUpdate()
    {
        ////////////////////////////////////////////////////////////////////////
        if (!Input.GetKey(KeyCode.LeftAlt))
        {
            ////////////////////////////////////////////////////////////////////////
            // Reference to: Roll-a-ball Tutorial https://learn.unity.com/project/roll-a-ball-tutorial
            // and Unity Documentation: Vector3

            // Get Thrust
            float moveLongitudinal = Input.GetAxis("Vertical");  // Vertical = W, S keys, AeroLongitudinal = Tip-to-Tail axis
            float moveLateral = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetKey(KeyCode.LeftControl) ? 1 :
                Input.GetKey(KeyCode.Space) ? -1 : 0;

            // Set Thrust
            Vector3 movement = new Vector3(moveLateral, moveLongitudinal, moveVertical);
            movement = Quaternion.Euler(_playerBody.eulerAngles) * movement;
            //Debug.Log(movement);

            if (movement == Vector3.zero) _alpf.cutoffFrequency = 10;
            else
            {
                _alpf.cutoffFrequency = 1000 * movement.magnitude;
                _rb.AddForce(movement * Acceleration);
            }

            ////////////////////////////////////////////////////////////////////////
            // Get torque for this update. Vertical/Lateral inverted.
            float rotateLongitudinal = Input.GetKey(KeyCode.Q) ? 1 :
                Input.GetKey(KeyCode.E) ? -1 : 0;
            float rotateVertical = -Input.GetAxis("Mouse X");
            float rotateLateral = -Input.GetAxis("Mouse Y");

            // Set torque thrust for this update.
            Vector3 rotation = new Vector3(rotateLateral, rotateLongitudinal, rotateVertical);
            rotation = Quaternion.Euler(_playerBody.eulerAngles) * rotation;
            _rb.AddTorque(Torque * rotation);
            _alpf.cutoffFrequency += 100 * rotation.magnitude;
        }
        ////////////////////////////////////////////////////////////////////////
        else
        {
            ////////////////////////////////////////////////////////////////////////
            // Inspired by: Using Torque to kill Angular Velocity https://answers.unity.com/questions/611992/using-torque-to-kill-angular-velocity.html
            // Inertial Dampener
            _rb.AddTorque(-_rb.angularVelocity * Torque * InertialDampener);
            _rb.AddForce(-_rb.velocity * Acceleration * 0.01f * InertialDampener);
            _alpf.cutoffFrequency = 10;
        };
    }
}



//private Vector3 zeroVelocity = Vector3.zero;

//private Vector3 m_EulerAngleVelocity;
//public float mouseSensitivity = 100f;

/*void Update()
{
    if (rb.angularVelocity.magnitude > 0)
        Debug.Log("angVel = " + rb.angularVelocity.magnitude);
}*/
/*
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        //if (Input.GetKeyDown(KeyCode.Q)) Debug.Log("Q key is down.");
        //if (Input.GetKeyUp(KeyCode.Q)) Debug.Log("Q key is up.");
        float yaw = Input.GetKey(KeyCode.Q) ? 1 :
            Input.GetKey(KeyCode.E)? -1 : 0;

        m_EulerAngleVelocity = new Vector3(-mouseY, 100f*yaw, -mouseX);
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);*/

//playerBody.Rotate(Vector3.up * mouseX);