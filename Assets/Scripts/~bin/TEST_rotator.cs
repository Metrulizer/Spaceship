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

        if (Input.GetKeyDown(KeyCode.G))
        {
            //Debug.Log("Rotation by " + Rotation);
            transform.Rotate(Rotation);
            _playerCharacter.transform.Rotate(Rotation);
            Debug.Log(transform.eulerAngles.normalized + " vs " +Quaternion.Euler(Vector3.down) * Physics.gravity.normalized + Physics.gravity.normalized);

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _playerCharacter.transform.position = _respawnNode.transform.position;
            _playerCharacter.transform.rotation = _respawnNode.transform.rotation;
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
