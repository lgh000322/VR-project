﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObstacle : MonoBehaviour
{

    // 회전 속도 (도/초)
    public float rotationSpeed = 30.0f;
    public float z;

    // Update is called once per frame
    void Update()
    {
      
        z += rotationSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, 0, z);
    }
}