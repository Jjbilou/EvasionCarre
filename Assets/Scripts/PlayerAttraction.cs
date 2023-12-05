using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttraction : MonoBehaviour
{
    public float force;
    public double angle;
    
    Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        angle = Math.PI * (angle % 360) / 180;
        movement = new Vector3((float)Math.Cos(angle), (float)Math.Sin(angle), 0f);
    }

    // Update is called once per frame
    void Update()
    {
         transform.position += movement * Time.deltaTime * force;
    }
}
