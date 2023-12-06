using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Laser : MonoBehaviour
{
    Renderer laser;
    Collider2D collision;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DisplayLaser(1f));

        laser = GetComponent<Renderer>();
        collision = GetComponent<BoxCollider2D>();

        laser.enabled = false;
        collision.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.DOMoveX(4, 20);
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
