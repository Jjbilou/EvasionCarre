using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    Renderer laser;
    Collider collision;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DisplayLaser(1f));
        laser = GetComponent<Renderer>();
        collision = GetComponent<BoxCollider>();
        laser.enabled = false;
        collision.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
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
