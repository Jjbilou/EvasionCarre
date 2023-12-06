using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
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
    float borderWidth;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        float middleX = (borderLeft.transform.position.x + borderRight.transform.position.x) / 2f;
        float middleY = (borderTop.transform.position.y + borderBottom.transform.position.y) / 2f;

        borderLeft.transform.position = new Vector3(borderLeft.transform.position.x, middleY, 1f);
        borderRight.transform.position = new Vector3(borderRight.transform.position.x, middleY, 1f);
        borderTop.transform.position = new Vector3(middleX, borderTop.transform.position.y, 1f);
        borderBottom.transform.position = new Vector3(middleX, borderBottom.transform.position.y, 1f);

        float sizeX = borderRight.transform.position.x - borderLeft.transform.position.x + borderLeft.transform.localScale.x;
        float sizeY = borderTop.transform.position.y - borderBottom.transform.position.y + borderTop.transform.localScale.y;

        borderLeft.transform.localScale = new Vector3(borderWidth, sizeY, 1f);
        borderRight.transform.localScale = new Vector3(borderWidth, sizeY, 1f);
        borderTop.transform.localScale = new Vector3(sizeX, borderWidth, 1f);
        borderBottom.transform.localScale = new Vector3(sizeX, borderWidth, 1f);
    }
}
