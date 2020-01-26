using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_rotator : MonoBehaviour
{
    public Vector3 Rotation = new Vector3(15, 30, 45);
    public GameObject _playerCharacter;
    public GameObject _respawnNode;
    public GameObject _observeNode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawRay(transform.position, Physics.gravity, Color.white, Time.time);
        if (Input.GetKeyDown(KeyCode.G))
        {
            //Debug.Log("Rotation by " + Rotation);
            transform.Rotate(Rotation);
            _playerCharacter.transform.position = _respawnNode.transform.position;
            _playerCharacter.transform.rotation = _respawnNode.transform.rotation;
            Debug.Log(transform.eulerAngles.normalized + " vs " +(Quaternion.Euler(transform.eulerAngles.normalized) * Physics.gravity.normalized + Physics.gravity.normalized));
            
            Debug.Log(transform.eulerAngles);
            Debug.Log(Quaternion.Euler(transform.eulerAngles) * Physics.gravity);
            Physics.gravity = Quaternion.Euler(transform.eulerAngles) * new Vector3(0, -9.8f, 0);

        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            _playerCharacter.transform.position = _respawnNode.transform.position;
            _playerCharacter.transform.rotation = _respawnNode.transform.rotation;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            _playerCharacter.GetComponent<Rigidbody>().useGravity = false;
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            _playerCharacter.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
           _playerCharacter.transform.position = _respawnNode.transform.position;
            _playerCharacter.transform.rotation = _respawnNode.transform.rotation;
            _playerCharacter.SetActive(true);
        }
    }
}
