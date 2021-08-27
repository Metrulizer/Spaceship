using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPilotSeat : MonoBehaviour
{
    public GameObject _SpaceShip;
    public GameObject _MainCamera;
    public GameObject _Character;
    public GameObject _Interior;
    public GameObject _RespawnNode;
    public GameObject _SeatTrigger;

    //public bool flag_InSeat;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ButtonPilotSeat started");
        //_ss = GetComponent<GameObject>();
        //(_SpaceShip.GetComponent("SpaceShipControl") as MonoBehaviour).enabled = false;
        _SpaceShip.SetActive(false);
        //ReAttach();

        //_cm = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        /*      if (Input.GetKeyDown(KeyCode.X))
              {
                  OnMouseDown();
              }*/

        if (Input.GetKeyDown(KeyCode.F1))
        {
            _Character.transform.position = _RespawnNode.transform.position;
            _Character.transform.rotation = _RespawnNode.transform.rotation;
        }
        //if (_SeatTrigger.GetComponent<Collider>().) //actually needs a message from the mesh
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("X");
            if (_SpaceShip.activeSelf == false)
                SpaceshipChangeover();
            else
                InteriorChangeover();
        }

    }
    public void SpaceshipChangeover()
    {
        Debug.Log("ButtonPilotSeat pressed");
        _SpaceShip.SetActive(true);
        
        _MainCamera.GetComponent<CameraController>().SwitchCamera();

        _Character.SetActive(false);
        _Interior.SetActive(false);
    }

    public void InteriorChangeover()
    {
        Debug.Log("ButtonPilotSeat pressed");

        _Character.SetActive(true);
        _Interior.SetActive(true);

        //Reset Interior Space
        _Interior.transform.position = _SpaceShip.transform.position;
        _Interior.transform.rotation = _SpaceShip.transform.rotation;
        _Character.transform.position = _RespawnNode.transform.position;
        _Character.transform.rotation = _RespawnNode.transform.rotation;
        Physics.gravity = Quaternion.Euler(_SpaceShip.transform.eulerAngles) * new Vector3(0, -9.8f, 0); ;

        _MainCamera.GetComponent<CameraController>().SwitchCamera();

        _SpaceShip.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _SpaceShip.SetActive(false);
    }

    /*    private void OnMouseDown()
        {
            if (_SpaceShip.activeSelf == false)
                SpaceshipChangeover();
            else
                InteriorChangeover();
        }

        private void OnTriggerEnter(Collider other)
        {
            flag_InSeat = true;
        }

        private void OnTriggerExit(Collider other)
        {
            flag_InSeat = false;
        }*/
    /*    private void OnTriggerStay(Collider other)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("TriggerStay and X");
                if (_SpaceShip.activeSelf == false)
                    SpaceshipChangeover();
                else
                    InteriorChangeover();
            }
        }
    */

    private void ReAttach()
    {
        GameObject newParent = _SpaceShip.activeSelf == true ? _SpaceShip : _Interior;
        transform.parent = newParent.transform;
    }
}
