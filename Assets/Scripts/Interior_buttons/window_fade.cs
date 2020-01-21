using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class window_fade : MonoBehaviour
{
    Renderer _rn;
    private bool alphaZero = false;


    // Start is called before the first frame update
    void Start()
    {
        _rn = GetComponent<Renderer>();
        //Debug.Log(_rn.material.color + "closer " + (_rn.material.color.a == 0)) ;
        alphaZero = (_rn.material.color.a == 0) ? true : false;
        StartCoroutine("OnInteract");
    }

    IEnumerator OnInteract()
    {
        int inverter = alphaZero ? -1 : 1;
        for (float ft = .5f; ft >= -.5f; ft -= Time.deltaTime)
        {
            Color c = _rn.material.color;
            c.a = inverter * ft + .5f;
            _rn.material.color = c;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        Debug.Log(_rn.material.color);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
