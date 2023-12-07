using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Laser : MonoBehaviour
{
    public float laserWidth;
    public float laserHeight;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<Animator>().enabled = true;

        transform.localScale = new Vector3(laserWidth, laserHeight, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
