using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityOverride : MonoBehaviour
{
    void FixedUpdate()
    {
        Physics.gravity = Quaternion.Euler(transform.eulerAngles) * new Vector3(0, -9.8f, 0);
    }
}
