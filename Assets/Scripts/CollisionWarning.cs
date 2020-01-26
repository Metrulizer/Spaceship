using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWarning : MonoBehaviour
{
    public AudioClip sawtooth;
    AudioSource _as;

    //Collider _col;
    //bool detection = true;

    bool soundActive = true;
    float proximity;
    // Start is called before the first frame update
    void Start()
    {
        _as = GetComponent<AudioSource>();
        //_col = GetComponent<Collider>();

        //StartCoroutine(ProximitySensor());
    }


    void OnTriggerStay(Collider other)
    {
        proximity = (transform.position - other.ClosestPoint(transform.position)).magnitude;
        if (soundActive)
        {
            StartCoroutine(ProximitySensor());
        }
    }
    private IEnumerator ProximitySensor()
    {
        soundActive = false;
        _as.Play();
        float delay = Mathf.Sqrt(proximity) / 2f - .2f;
        //Debug.Log(delay);
        yield return new WaitForSeconds(delay);
        soundActive = true;

    }

}/*

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        //detection = true;
    }
    void OnTriggerExit(Collider other)
    {
        //detection = false;
    }*/
