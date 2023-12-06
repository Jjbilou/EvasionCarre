using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Laser : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed;
    Renderer laser;
    Collider2D collision;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(DisplayLaser(1f));

        laser = GetComponent<Renderer>();
        collision = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("l"))
        {
            transform.Rotate(0f, 0f, rotationSpeed); 
        }
    }

    IEnumerator DisplayLaser(float interval)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            laser.enabled = !laser.enabled;
            collision.enabled = !collision.enabled;
        }
    }
}
