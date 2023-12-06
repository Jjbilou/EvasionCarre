using System.Collections;
using System.Collections.Generic;
using System.Data;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Level0 : MonoBehaviour
{
    [SerializeField]
    GameObject borders;
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
    [SerializeField]
    GameObject laser;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Launch());
    }

    IEnumerator Launch()
    {
        GameObject laserClone;

        yield return new WaitForSeconds(2f);

        EnableDeadlyBorders();

        yield return new WaitForSeconds(1f);

        laserClone = CreateLaser(borderLeft.transform.position.x, borderTop.transform.position.y, 3f, 6f, 0f);
        RotateLaser(laserClone, -180f, 2f);
        MoveLaser(laserClone, borderRight.transform.position.x, borderTop.transform.position.y, 2f);

        yield return new WaitForSeconds(2f);

        Destroy(laserClone);
        DisableDeadlyBorders();
        CreateBullet(7f, 0f, 1f, 135f, 15f, 3);
        CreateBullet(7f, 0f, 1f, -135f, 15f, 2);
        laserClone = CreateLaser(borderTop.transform.position.x, borderLeft.transform.position.y, 3f, 3f, 0f);
        RotateLaser(laserClone, -900f, 5f);

        yield return new WaitForSeconds(2f);

        BorderRightScale(-2f, 1f);
        BorderTopScale(-2f, 1f);
        MoveLaser(laserClone, laserClone.transform.position.x - 1f, laserClone.transform.position.y - 1f, 2f);

        yield return new WaitForSeconds(3f);

        print("You won, gg");
        StopCoroutine(Launch());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void EnableDeadlyBorders()
    {
        Color borderColor = new Color(1f, 0f, 0f);

        borders.tag = "Danger";
        borderLeft.GetComponent<SpriteRenderer>().color = borderColor;
        borderRight.GetComponent<SpriteRenderer>().color = borderColor;
        borderTop.GetComponent<SpriteRenderer>().color = borderColor;
        borderBottom.GetComponent<SpriteRenderer>().color = borderColor;
    }

    void DisableDeadlyBorders()
    {
        Color borderColor = new Color(1f, 1f, 1f);

        borders.tag = "Untagged";
        borderLeft.GetComponent<SpriteRenderer>().color = borderColor;
        borderRight.GetComponent<SpriteRenderer>().color = borderColor;
        borderTop.GetComponent<SpriteRenderer>().color = borderColor;
        borderBottom.GetComponent<SpriteRenderer>().color = borderColor;
    }

    GameObject CreateLaser(float posX, float posY, float laserWidth, float laserHeight, float angle)
    {
        GameObject laserClone = Instantiate(laser, new Vector3(posX, posY, 1f), Quaternion.Euler(0f, 0f, 90f - angle));

        Laser cloneScript = laserClone.GetComponent<Laser>();
        cloneScript.enabled = true;
        cloneScript.laserWidth = laserWidth;
        cloneScript.laserHeight = laserHeight;

        return laserClone;
    }

    void RotateLaser(GameObject laser, float angle, float time)
    {
        laser.transform.DORotate(new Vector3(0f, 0f, 90f - transform.rotation.z + angle), time);
    }

    void MoveLaser(GameObject laser, float posX, float posY, float time)
    {
        laser.transform.DOMove(new Vector3(posX, posY, 1f), time);
    }

    GameObject CreateBullet(float posX, float posY, float size, float angle, float speed, int level)
    {
        GameObject bulletClone = Instantiate(bullet, new Vector3(posX, posY, 1f), Quaternion.Euler(0f, 0f, 90f - angle));

        Bullet cloneScript = bulletClone.GetComponent<Bullet>();
        cloneScript.enabled = true;
        cloneScript.size = size;
        cloneScript.angle = angle;
        cloneScript.speed = speed;
        cloneScript.level = level;

        return bulletClone;
    }

    void BorderLeftScale(float scaleValue, float time)
    {
        borderLeft.transform.DOMoveX(borderLeft.transform.position.x - scaleValue, time);
    }

    void BorderRightScale(float scaleValue, float time)
    {
        borderRight.transform.DOMoveX(borderRight.transform.position.x + scaleValue, time);
    }

    void BorderTopScale(float scaleValue, float time)
    {
        borderTop.transform.DOMoveY(borderTop.transform.position.y + scaleValue, time);
    }

    void BorderBottomScale(float scaleValue, float time)
    {
        borderBottom.transform.DOMoveY(borderBottom.transform.position.y - scaleValue, time);
    }
}
