using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hologram_CollisionTrigger : MonoBehaviour
{
    private Renderer _ren;
    private SphereCollider _sc;
    float maxdist;
    // Start is called before the first frame update
    void Start()
    {
        _ren = transform.GetComponent<Renderer>();
        _sc = transform.GetComponent<SphereCollider>();
        maxdist = _sc.radius * transform.localScale.magnitude;
        //transform.GetComponent<Renderer>().material.SetColor("_Color", new Color(0, 0, 1, 0.1f));
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        float distance = Vector3.Distance(transform.position, other.transform.position);
        Debug.Log(distance / maxdist);
        float transparency = Mathf.Clamp((distance / maxdist) - .5f, 0f, 1f);
        _ren.material.SetColor("_Color", new Color(0, 0, 1, transparency));
        transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", new Color(0, 0, 1, transparency));
    }
}
