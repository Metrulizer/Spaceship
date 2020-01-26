using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public KeyCode KeyPerspective = KeyCode.P;
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera3;
    bool camflag = false;   // implicit based on flag, later uses explicit

    void CameraReposition(GameObject camera)
    {
        Debug.Log("CameraReposition, Camera now at " + camera);
        transform.position = camera.transform.position;
        transform.rotation = camera.transform.rotation;
        transform.parent = camera.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start");
        Cursor.lockState = CursorLockMode.Locked;
        CameraReposition(Camera1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyPerspective) & (transform.parent.gameObject != Camera1))
        {
            //Debug.Log(transform.parent +""+ Camera2 + ""+(transform.parent.gameObject == Camera2));
            CameraReposition(transform.parent.gameObject == Camera3 ? Camera2 : Camera3);
            //camflag = !camflag;
        }
            /*transform.position = NextCameraPosition.transform.eulerAngles;
        transform.SetParent(NextCameraPosition.transform);*/
    }

    public void SwitchCamera()
    {
        CameraReposition(camflag ? Camera1 : Camera2);
        camflag = !camflag;
    }
}
