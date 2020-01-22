﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveControl();
    }
    
    void MoveControl()
    {
        Vector3 shouldMove = Vector3.zero;
        if(Input.GetKey(KeyCode.UpArrow))
        {
            shouldMove.y = movespeed;
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            shouldMove.y = -movespeed;
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            shouldMove.x = -movespeed;
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            shouldMove.x = movespeed;
        }

        transform.Translate(shouldMove * Time.deltaTime);
    }
}
