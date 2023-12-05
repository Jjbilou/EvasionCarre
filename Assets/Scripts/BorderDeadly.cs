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

    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Color borderColor;

        if (isActive)
        {
            borderColor = new Color(1f, 0f, 0f);
            gameObject.tag = "Danger";
        }
        else
        {
            borderColor = new Color(1f, 1f, 1f);
            gameObject.tag = "Untagged";
        }
        borderLeft.GetComponent<SpriteRenderer>().color = borderColor;
        borderRight.GetComponent<SpriteRenderer>().color = borderColor;
        borderTop.GetComponent<SpriteRenderer>().color = borderColor;
        borderBottom.GetComponent<SpriteRenderer>().color = borderColor;
    }
}
