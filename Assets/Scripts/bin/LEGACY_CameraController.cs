using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEGACY_CameraController : MonoBehaviour
{
    private GameObject InitialCamera;
    public GameObject NextCameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        NextCameraPosition = GetComponent<GameObject>();
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            transform.position = NextCameraPosition.transform.eulerAngles;
        transform.SetParent(NextCameraPosition.transform);
    }
}
