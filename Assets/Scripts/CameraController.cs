using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public KeyCode KeyPerspective = KeyCode.P;
    public GameObject Camera1;
    public GameObject Camera2;
    bool camflag = false;

    void CameraReposition(GameObject camera)
    {
        //Debug.Log("CamRepo " + camera);
        transform.position = camera.transform.position;
        transform.rotation = camera.transform.rotation;
        transform.parent = camera.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start");
        CameraReposition(Camera1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyPerspective))
        {
            //Debug.Log((transform.parent == Camera2));
            CameraReposition(camflag ? Camera1 : Camera2);
            camflag = !camflag;
        }
            /*transform.position = NextCameraPosition.transform.eulerAngles;
        transform.SetParent(NextCameraPosition.transform);*/
    }
}
