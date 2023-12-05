using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderDeadly : MonoBehaviour
{
    [SerializeField]
    GameObject borderLeft;
    [SerializeField]
    GameObject borderRight;
    [SerializeField]
    GameObject borderTop;
    [SerializeField]
    GameObject borderBottom;

    // Start is called before the first frame update
    void Start()
    {
        Color borderColor = new Color(1f, 0f, 0f);

        gameObject.tag = "Danger";
        borderLeft.GetComponent<SpriteRenderer>().color = borderColor;
        borderRight.GetComponent<SpriteRenderer>().color = borderColor;
        borderTop.GetComponent<SpriteRenderer>().color = borderColor;
        borderBottom.GetComponent<SpriteRenderer>().color = borderColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
