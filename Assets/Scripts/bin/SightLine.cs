using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightLine : MonoBehaviour
{
    //private bool hitFlag;

    // Start is called before the first frame update
    void Start()
    {
        //hitFlag = false;
        //StartCoroutine()
        Cursor.lockState = CursorLockMode.Locked;
        Example();
    }

    // https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
    // Example code includes LayerMasks which they use to filter out the player collision mesh
    // While hidden inside the user, the ray will still work fine without the layer masking
    void Update()
    {
    }

    void Example()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow, Time.deltaTime);
            //Debug.Log("Did Hit "+hit.collider.gameObject.name);
            //hitFlag = true;
            hit.collider.gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(0f, 0f, 0f, 1f));
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white, Time.deltaTime);
            //hitFlag = false;
            //Debug.Log("Did not Hit");
        }
    }

    // On the otherhand, onmousedown works perfectly fine over colliders
    private void OnMouseDown()
    {
    }

}
//https://answers.unity.com/questions/903402/onmousedown-collider-other-not-working.html
//maybe useful