﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFollowMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		this.transform.position = Input.mousePosition;
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}
}
