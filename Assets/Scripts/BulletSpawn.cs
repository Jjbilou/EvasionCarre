using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    float delay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateBullet(delay));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator CreateBullet(float interval)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            GameObject clone = Instantiate(bullet, new Vector3(7f, 0f, 0f), Quaternion.identity);
            clone.GetComponent<Bullet>().enabled = true;
        }
    }
}
