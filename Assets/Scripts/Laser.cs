using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float laserWidth;
    public float laserHeight;

    Renderer laserRenderer;
    Collider2D laserCollider;

    // Start is called before the first frame update
    void Start()
    {
        laserRenderer = GetComponent<Renderer>();
        laserCollider = GetComponent<BoxCollider2D>();

        transform.localScale = new Vector3(laserWidth, laserHeight, 1f);
        laserRenderer.enabled = true;
        laserCollider.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
