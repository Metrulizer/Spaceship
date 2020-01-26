using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeButton : MonoBehaviour
{
    public bool activate = false;
    public int frame;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OnPress());
    }

    // Update is called once per frame
    void Update()
    {

    }
    // https://docs.unity3d.com/ScriptReference/WaitUntil.html
    IEnumerator OnPress()
    {
        Debug.Log("Waiting for princess to be rescued...");
        yield return new WaitUntil(() => activate == true);
        activate = false;
        Debug.Log("Princess was rescued!");
    }
    private void OnMouseDown()
    {
        Debug.Log("cubebutton mouse down");
    }
}
