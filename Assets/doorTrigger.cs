using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTrigger : MonoBehaviour
{
    Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        //Get the Animator attached to the GameObject you are intending to animate.
        m_Animator = gameObject.transform.parent.transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Press the up arrow button to reset the trigger and set another one
        if (Input.GetKey(KeyCode.Home))
        {
            Debug.Log("do shit pls");
            m_Animator.SetBool("do_Open", true);
            m_Animator.SetBool("do_Close", false);
        }

        if (Input.GetKey(KeyCode.End))
        {
            m_Animator.SetBool("do_Open", !m_Animator.GetBool("do_Open"));
            m_Animator.SetBool("do_Close", !m_Animator.GetBool("do_Close"));
        }
    }
    private void OnMouseDown()
    {
        Debug.Log("mdown");
        m_Animator.SetBool("do_Open", !m_Animator.GetBool("do_Open"));
        m_Animator.SetBool("do_Close", !m_Animator.GetBool("do_Close"));
    }
}
