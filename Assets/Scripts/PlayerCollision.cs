using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
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

    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        Vector3 playerPosition = transform.position;
        float maxX = borderRight.transform.transform.position.x - borderRight.transform.localScale.x / 2f - transform.localScale.x / 2f + 0.05f;
        float minX = borderLeft.transform.transform.position.x + borderLeft.transform.localScale.x / 2f + transform.localScale.x / 2f - 0.05f;
        float maxY = borderTop.transform.transform.position.y - borderTop.transform.localScale.y / 2f - transform.localScale.y / 2f + 0.05f;
        float minyY = borderBottom.transform.transform.position.y + borderBottom.transform.localScale.y / 2f + transform.localScale.y / 2f - 0.05f;

        if (playerPosition.x > maxX)
        {
            transform.position = new Vector3(maxX, transform.transform.position.y, 1f);
        }
        if (playerPosition.x < minX)
        {
            transform.position = new Vector3(minX, transform.transform.position.y, 1f);
        }
        if (playerPosition.y > maxY)
        {
            transform.position = new Vector3(transform.transform.position.x, maxY, 1f);
        }
        if (playerPosition.y < minyY)
        {
            transform.position = new Vector3(transform.transform.position.x, minyY, 1f);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Danger")
        {
            Destroy(gameObject);
        }
        if (collision.tag == "HorizontalBorder")
        {
            if (collision.transform.parent.tag == "Danger")
            {
                Destroy(gameObject);
            }
        }
        if (collision.tag == "VerticalBorder")
        {
            if (collision.transform.parent.tag == "Danger")
            {
                Destroy(gameObject);
            }
        }
    }
}
