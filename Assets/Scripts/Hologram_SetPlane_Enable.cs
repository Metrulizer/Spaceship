using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hologram_SetPlane_Enable : MonoBehaviour
{
    private void OnEnable()
    {
        transform.rotation = Quaternion.Euler(1,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.F1)) transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
