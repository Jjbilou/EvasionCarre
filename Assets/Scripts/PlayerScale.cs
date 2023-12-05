using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScale : MonoBehaviour
{
    [SerializeField]
    float scaleSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("p"))
        {
            transform.localScale += new Vector3 (scaleSpeed, scaleSpeed, 0f);
        }
        if (Input.GetKey("m"))
        {
            transform.localScale -= new Vector3 (scaleSpeed, scaleSpeed, 0f);
        }
    }
}
