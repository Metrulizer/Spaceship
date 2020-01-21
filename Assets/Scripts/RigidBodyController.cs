using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyController : MonoBehaviour
{
    private Rigidbody _rb;
    public GameObject _ground;
    public GameObject _head;

    public float Acceleration = 10f;
    public float MouseSensitivity = 100f;
    public float SpeedLimit = 5f;

    Vector3 vA;
    Vector3 vB;
    float moveKeyCodeWS;
    float moveKeyCodeAD;
    Vector3 movement;
    float force;
    float mouseX;
    float mouseY;

    bool flagCollision = false;

    ////////////////////////////////////////////////////////////////////////
    void OnEnable()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = Vector3.zero;
        //transform.rotation = Physics.gravity.normalized;
    }
    // enable is just slightly above in the hierarchy
    /*void Start()
    {
        //_rb = GetComponent<Rigidbody>();
    }*/

    ////////////////////////////////////////////////////////////////////////
    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.contactCount == 0)
            flagCollision = false;
    }

    ////////////////////////////////////////////////////////////////////////
    void OnCollisionStay(Collision collisionInfo)
    {
        flagCollision = true;
    }

    // FixedUpdate, 50 calls per second ////////////////////////////////////
    void FixedUpdate()
    {
        ////////////////////////////////////////////////////////////////////////
        // Unity Documentation: Vector3 (notably sqrMagnitude optimization, normalized) 
        //  Quaternion, transform.eulerAngles

        // Limit the x-z speed
        // Get planar Vector3 using Euler relative to GRAVITY (NOT parent(Ship's Interior))
        vA = Quaternion.Euler(-Physics.gravity.normalized) * _rb.velocity;
        vB = new Vector3(vA.x, 0, vA.z);

        // Set Normalized speed
        if (vB.sqrMagnitude > SpeedLimit * SpeedLimit)
        {
            _rb.velocity = Quaternion.Euler(Physics.gravity.normalized)
                * new Vector3(vB.normalized.x * SpeedLimit, vA.y, vB.normalized.z * SpeedLimit);
        }

        ////////////////////////////////////////////////////////////////////////
        // Reference to: Roll-a-ball Tutorial https://learn.unity.com/project/roll-a-ball-tutorial
        // and Unity Documentation: Vector3

        // Get Movement
        moveKeyCodeWS = Input.GetAxis("Vertical");
        moveKeyCodeAD = Input.GetAxis("Horizontal");
        
        // Set Movement, with respect to objects eulerAngle
        movement = new Vector3(moveKeyCodeAD, 0, moveKeyCodeWS);
        // movement = Quaternion.Euler(transform.eulerAngles) * movement;    // RelativeForce does this job
        force = _rb.mass * Acceleration;

        // Push Movement
        _rb.AddRelativeForce(movement * force * Time.fixedDeltaTime);
        //_rb.AddTorque(-_rb.angularVelocity * .5f);    // rigidbody is now clamped

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) & flagCollision) 
            _rb.AddRelativeForce(-Physics.gravity * force * Time.fixedDeltaTime * .5f);
    }

    ////////////////////////////////////////////////////////////////////////
    void Update()
    {
        ////////////////////////////////////////////////////////////////////////
        // Code modified from SpaceShipControl

        // Get Mouse Input
        mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        // Set Transformation: yaw on body but pitch only on head
        transform.Rotate(0, mouseX, 0);
        _head.transform.Rotate(-mouseY, 0, 0);
    }
}
