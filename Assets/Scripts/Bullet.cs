using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]

    Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        double angle = UnityEngine.Random.Range(-1f, 1f) * Math.PI;
        movement = new Vector3((float)Math.Cos(angle), (float)Math.Sin(angle), 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += movement * Time.deltaTime * speed;
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.layer == 7)
        {
            movement = new Vector3(movement.x, movement.y * -1, 0);
        }

        if (collider.gameObject.layer == 8)
        {
            movement = new Vector3(movement.x * -1, movement.y, 0);
        }
    }
}
