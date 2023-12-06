using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderShrink : MonoBehaviour
{
    [SerializeField]
    GameObject borderLeft;
    [SerializeField]
    GameObject borderRight;
    [SerializeField]
    GameObject borderTop;
    [SerializeField]
    GameObject borderBottom;
    [SerializeField]
    float shrinkSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("h"))
        {
            Vector3 shrinkValue = new Vector3(0f, shrinkSpeed, 0f);

            borderTop.transform.position -= shrinkValue;
            borderBottom.transform.position += shrinkValue;
            borderLeft.transform.localScale -= 2f * shrinkValue;
            borderRight.transform.localScale -= 2f * shrinkValue;
        }

        if (Input.GetKey("n"))
        {
            Vector3 shrinkValue = new Vector3(shrinkSpeed, 0f, 0f);

            borderRight.transform.position -= shrinkValue;
            borderLeft.transform.position += shrinkValue;
            borderTop.transform.localScale -= 2f * shrinkValue;
            borderBottom.transform.localScale -= 2f * shrinkValue;
        }

        if (Input.GetKey("b"))
        {
            Vector3 shrinkValue = new Vector3(0f, -shrinkSpeed, 0f);

            borderTop.transform.position -= shrinkValue;
            borderBottom.transform.position += shrinkValue;
            borderLeft.transform.localScale -= 2f * shrinkValue;
            borderRight.transform.localScale -= 2f * shrinkValue;
        }

        if (Input.GetKey("v"))
        {
            Vector3 shrinkValue = new Vector3(-shrinkSpeed, 0f, 0f);

            borderRight.transform.position -= shrinkValue;
            borderLeft.transform.position += shrinkValue;
            borderTop.transform.localScale -= 2f * shrinkValue;
            borderBottom.transform.localScale -= 2f * shrinkValue;
        }
    }
}
