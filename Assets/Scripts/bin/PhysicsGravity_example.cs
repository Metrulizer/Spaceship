using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsGravity_example : MonoBehaviour
{
    void Start()
    {
        Physics.gravity = Quaternion.Euler(transform.eulerAngles) * new Vector3(0, -9.8f, 0);
        Debug.Log(Physics.gravity);
    }
}