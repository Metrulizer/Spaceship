﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit_sample : MonoBehaviour
{
    // Quit on esc
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
