﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.position;

    }
    private void Update()
    {
        transform.position = player.position + offset; 
    }
}
