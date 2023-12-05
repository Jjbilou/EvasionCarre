using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float speed;

    SpriteRenderer bulletRenderer;
    Bullet script;
    Collider2D collider2d;

    Vector3 movement;

    Color bounce0;
    Color bounce1;
    Color bounce2;

    // Start is called before the first frame update
    void Start()
    {
        bulletRenderer = GetComponent<SpriteRenderer>();
        script = GetComponent<Bullet>();
        collider2d = GetComponent<Collider2D>();

        bulletRenderer.enabled = true;
        collider2d.enabled = true;

        bounce0 = new Color(0f, 0f, 0f);
        bounce1 = new Color(0.36f, 0f, 0.62f);
        bounce2 = new Color(1f, 0f, 0f);

        switch (UnityEngine.Random.Range(0, 4))
        {
            case 0:
                bulletRenderer.color = bounce0;
                break;
            case 1:
                bulletRenderer.color = bounce1;
                break;
            case 2:
                bulletRenderer.color = bounce2;
                break;
            case 3:
                bulletRenderer.color = new Color(1, 1, 1);
                break;
        }

        double angle = UnityEngine.Random.Range(-1f, 1f) * Math.PI;
        movement = new Vector3((float)Math.Cos(angle), (float)Math.Sin(angle), 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += movement * Time.deltaTime * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HorizontalBorder")
        {
            BounceOrDestroy();
            movement = new Vector3(movement.x, movement.y * -1f, 0f);
        }

        if (collision.tag == "VerticalBorder")
        {
            BounceOrDestroy();
            movement = new Vector3(movement.x * -1f, movement.y, 0f);
        }
    }

    void BounceOrDestroy()
    {
        if (bulletRenderer.color == bounce0)
        {
            if (gameObject.name == "Bullet(Clone)")
            {
                Destroy(gameObject);
            }
            bulletRenderer.enabled = false;
            collider2d.enabled = false;
            script.enabled = false;
        }
        else if (bulletRenderer.color == bounce1)
        {
            bulletRenderer.color = bounce0;
        }
        else if (bulletRenderer.color == bounce2)
        {
            bulletRenderer.color = bounce1;
        }
    }
}
