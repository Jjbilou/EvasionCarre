using System.Collections;
using System.Collections.Generic;
using System.Data;
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
        yield return new WaitForSeconds(3);

        EnableDeadlyBorders();

        yield return new WaitForSeconds(1);

        GameObject laserClone = Instantiate(laser, new Vector3(borderLeft.transform.position.x, borderTop.transform.position.y, 1f), Quaternion.identity);

        Laser cloneScript = laserClone.GetComponent<Laser>();
        cloneScript.enabled = true;
        cloneScript.laserWidth = 3;
        cloneScript.laserHeight = 7;

        LaserRotation laserRotation = laserClone.GetComponent<LaserRotation>();
        laserRotation.enabled = true;
        laserRotation.rotationSpeed = 90;

        yield return new WaitForSeconds(3);

        Destroy(laserClone);
        DisableDeadlyBorders();


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
}
