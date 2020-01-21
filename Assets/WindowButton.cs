using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        
    }

    private void OnMouseDown()
    {
        Renderer _rn;
        _rn = transform.parent.GetComponent<Renderer>();
        //Debug.Log(_rn.material.color + "closer " + (_rn.material.color.a == 0)) ;
        //alphaZero = (_rn.material.color.a == 0) ? true : false;
        Debug.Log(_rn.material.color.a);
        StartCoroutine(OnInteract(_rn, (_rn.material.color.a < .5f) ? true : false));
    }

    IEnumerator OnInteract(Renderer _rn, bool alphaZero)
    {
        int inverter = alphaZero ? -1 : 1;  // redundant but readable
        for (float ft = .5f; ft >= -.5f; ft -= Time.deltaTime)
        {
            Color c = _rn.material.color;
            c.a = inverter * ft + .5f;
            _rn.material.color = c;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        Debug.Log(_rn.material.color);
    }
}
