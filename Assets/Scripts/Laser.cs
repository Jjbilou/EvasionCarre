using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float laserWidth;
    public bool isDisplayed;

    Renderer laserRenderer;
    Collider2D laserCollider;

    // Start is called before the first frame update
    void Start()
    {
        laserRenderer = GetComponent<Renderer>();
        laserCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(laserWidth, 3f, 1f);
        laserRenderer.enabled = isDisplayed;
        laserCollider.enabled = isDisplayed;
    }
}
