using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
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

        if (playerPosition.x > 8.2350f)
        {
            transform.position = new Vector3(8.2350f, transform.position.y, 0f);
        }
        if (playerPosition.x < -8.2350f)
        {
            transform.position = new Vector3(-8.2350f, transform.position.y, 0f);
        }
        if (playerPosition.y > 3.7350f)
        {
            transform.position = new Vector3(transform.position.x, 3.7350f, 0f);
        }
        if (playerPosition.y < -3.7350f)
        {
            transform.position = new Vector3(transform.position.x, -3.7350f, 0f);
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Danger")
        {
            Destroy(collider.gameObject);
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
