using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        Vector3 playerPosition = transform.position;

        if (playerPosition.x > 8.2450f)
        {
            transform.position = new Vector3(8.2450f, transform.position.y, 0f);
        }
        if (playerPosition.x < -8.2450f)
        {
            transform.position = new Vector3(-8.2450f, transform.position.y, 0f);
        }
        if (playerPosition.y > 3.7450f)
        {
            transform.position = new Vector3(transform.position.x, 3.7450f, 0f);
        }
        if (playerPosition.y < -3.7450f)
        {
            transform.position = new Vector3(transform.position.x, -3.7450f, 0f);
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        GameObject collided_object = collider.gameObject;

        if (collided_object.layer == 10)
        {
            Destroy(collided_object);
        }
    }
}
