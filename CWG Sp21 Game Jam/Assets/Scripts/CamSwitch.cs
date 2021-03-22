﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public Camera cam1; 
    public Camera cam2;
 
    void Start()
    {
        Camera[] cams = FindObjectsOfType<Camera>();
        cam1 = cams[0];
        cam2 = cams[1];
        cam1.enabled = true;
        cam2.enabled = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            cam1.enabled = !cam1.enabled;
            cam2.enabled = !cam2.enabled;
        }
    }
}
