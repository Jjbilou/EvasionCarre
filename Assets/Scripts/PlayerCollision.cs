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
    [SerializeField]
    GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateBullet(3f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        Vector3 playerPosition = transform.position;
        float maxX = borderRight.transform.position.x - borderRight.transform.localScale.x / 2f - transform.localScale.x / 2f;
        float minX = borderLeft.transform.position.x + borderLeft.transform.localScale.x / 2f + transform.localScale.x / 2f;
        float maxY = borderTop.transform.position.y - borderTop.transform.localScale.y / 2f - transform.localScale.y / 2f;
        float minyY = borderBottom.transform.position.y + borderBottom.transform.localScale.y / 2f + transform.localScale.y / 2f;

        if (playerPosition.x > maxX)
        {
            transform.position = new Vector3(maxX, transform.position.y, 0f);
        }
        if (playerPosition.x < minX)
        {
            transform.position = new Vector3(minX, transform.position.y, 0f);
        }
        if (playerPosition.y > maxY)
        {
            transform.position = new Vector3(transform.position.x, maxY, 0f);
        }
        if (playerPosition.y < minyY)
        {
            transform.position = new Vector3(transform.position.x, minyY, 0f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Danger")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private IEnumerator CreateBullet(float interval)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            Instantiate(bullet, new Vector3(7, 0, 0), Quaternion.identity);
        }
    }
}
