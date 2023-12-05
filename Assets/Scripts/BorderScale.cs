using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderScale : MonoBehaviour
{
    [SerializeField]
    GameObject borderLeft;
    [SerializeField]
    GameObject borderRight;
    [SerializeField]
    GameObject borderTop;
    [SerializeField]
    GameObject borderBottom;

    public float scaleLeft;
    public float scaleRight;
    public float scaleTop;
    public float scaleBottom;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 shrinkValue;

        //left
        shrinkValue = new Vector3(scaleLeft, 0f, 0f);

        borderLeft.transform.position += shrinkValue;
        borderTop.transform.localScale -= shrinkValue;
        borderTop.transform.position += shrinkValue / 2f;
        borderBottom.transform.localScale -= shrinkValue;
        borderBottom.transform.position += shrinkValue / 2f;

        //right
        shrinkValue = new Vector3(scaleRight, 0f, 0f);

        borderRight.transform.position -= shrinkValue;
        borderTop.transform.localScale -= shrinkValue;
        borderTop.transform.position -= shrinkValue / 2f;
        borderBottom.transform.localScale -= shrinkValue;
        borderBottom.transform.position -= shrinkValue / 2f;

        //top
        shrinkValue = new Vector3(0f, scaleTop, 0f);

        borderTop.transform.position -= shrinkValue;
        borderLeft.transform.localScale -= shrinkValue;
        borderLeft.transform.position -= shrinkValue / 2f;
        borderRight.transform.localScale -= shrinkValue;
        borderRight.transform.position -= shrinkValue / 2f;

        //bottom
        shrinkValue = new Vector3(scaleRight, 0f, 0f);

        borderBottom.transform.position -= shrinkValue;
        borderLeft.transform.localScale -= shrinkValue;
        borderLeft.transform.position += shrinkValue / 2f;
        borderRight.transform.localScale -= shrinkValue;
        borderRight.transform.position += shrinkValue / 2f;
    }
}
