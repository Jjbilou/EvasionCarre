using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndless : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject laser;

    GameObject borders;
    GameObject borderLeft;
    GameObject borderRight;
    GameObject borderTop;
    GameObject borderBottom;
    GameObject player;
    bool isAttracted = false;
    Vector3 attractMovement;
    PlayerCollision playerCollision;

    // Start is called before the first frame update
    void Start()
    {
        borders = GameObject.Find("Borders");
        borderLeft = GameObject.Find("Left");
        borderRight = GameObject.Find("Right");
        borderTop = GameObject.Find("Top");
        borderBottom = GameObject.Find("Bottom");
        player = GameObject.Find("Player");
        playerCollision = player.GetComponent<PlayerCollision>();
        UnloadAllScenesExcept("LevelEndless");
        PlayerPrefs.SetString("level", "LevelEndless");
        StartCoroutine(Launch());
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttracted)
        {
            player.transform.position += attractMovement * Time.deltaTime;
        }

        if (!playerCollision.running)
        {
            isAttracted = false;
            StopAllCoroutines();
        }
    }

    IEnumerator Launch()
    {
        yield return new WaitForSeconds(2f);

        while (true)
        {
            switch (UnityEngine.Random.Range(0, 3))
            {
                case 0:

                    EnableDeadlyBorders();

                    int occur0 = UnityEngine.Random.Range(1, 6);
                    for (int j = 0; j < occur0; j++)
                    {
                        PlayerAttraction(0f, 6f, 1f);
                        int hole = UnityEngine.Random.Range(-8, 8);
                        for (int i = -8; i < 9; i++)
                        {
                            if (i != hole && i != hole + 1)
                            {
                                CreateBullet(borderLeft.transform.position.x + 1f, i, 1f, 0f, 7f, 1);
                            }
                        }

                        yield return new WaitForSeconds(1f);
                    }

                    yield return new WaitForSeconds(1.5f);

                    DisableDeadlyBorders();

                    break;
                case 1:

                    EnableDeadlyBorders();
                    float boxReduction = UnityEngine.Random.Range(-6f, -1f);

                    BorderLeftScale(boxReduction, 1);
                    BorderRightScale(boxReduction, 1);
                    BorderTopScale(boxReduction, 1);
                    BorderBottomScale(boxReduction, 1);

                    yield return new WaitForSeconds(1f);

                    int occur1 = UnityEngine.Random.Range(1, 4);
                    for (int i = 0; i < occur1; i++)
                    {
                        float movementX = UnityEngine.Random.Range(3f, 5f) * (UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1);
                        float movementY = UnityEngine.Random.Range(3f, 5f) * (UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1);

                        BorderLeftScale(-movementX, 1);
                        BorderRightScale(movementX, 1);
                        BorderTopScale(movementY, 1);
                        BorderBottomScale(-movementY, 1);

                        yield return new WaitForSeconds(1f);
                    }

                    DisableDeadlyBorders();
                    borderLeft.transform.DOMove(new Vector3(-9f, 0f, 1f), 1f);
                    borderRight.transform.DOMove(new Vector3(9f, 0f, 1f), 1f);
                    borderTop.transform.DOMove(new Vector3(0f, 9f, 1f), 1f);
                    borderBottom.transform.DOMove(new Vector3(0f, -9f, 1f), 1f);

                    yield return new WaitForSeconds(2f);

                    break;
                case 2:

                    for (int i = 0; i < 20; i++)
                    {
                        CreateBullet(0f, 0f, 1f, 90f - i * 18f, 7f, 3);
                        yield return new WaitForSeconds(0.25f);
                    }

                    GameObject laserClone;
                    switch (UnityEngine.Random.Range(0, 3))
                    {
                        default:
                            CreateBullet(-8f, 8f, 1f, -30f, UnityEngine.Random.Range(10f, 15f), 3);
                            laserClone = CreateLaser(borderRight.transform.position.x, 0f, 3f, 4f, 90f);
                            break;

                        case 0:
                            CreateBullet(8f, 8f, 1f, -150f, UnityEngine.Random.Range(10f, 15f), 3);
                            laserClone = CreateLaser(0f, borderTop.transform.position.y, 3f, 4f, 0f);
                            break;

                        case 1:
                            CreateBullet(8f, -8f, 1f, 150f, UnityEngine.Random.Range(10f, 15f), 3);
                            laserClone = CreateLaser(borderLeft.transform.position.x, 0f, 3f, 4f, 90f);
                            break;

                        case 2:
                            CreateBullet(-8f, -8f, 1f, 30f, UnityEngine.Random.Range(10f, 15f), 3);
                            laserClone = CreateLaser(0f, borderBottom.transform.position.y, 3f, 4f, 0f);
                            break;
                    }

                    MoveLaser(laserClone, 0f, 0f, 3);

                    yield return new WaitForSeconds(4f);

                    Destroy(laserClone);

                    break;
            }
        }
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
        GameObject laserClone = Instantiate(laser, new Vector3(posX, posY, 1f), Quaternion.Euler(0f, 0f, angle - 90f));
        Laser cloneScript = laserClone.GetComponent<Laser>();
        
        laserClone.transform.localScale = new Vector3(laserWidth, laserHeight, 1f);
        cloneScript.enabled = true;

        return laserClone;
    }

    void RotateLaser(GameObject laser, float angle, float duration)
    {
        laser.transform.DORotate(new Vector3(0f, 0f, 90f - laser.transform.rotation.z + angle), duration);
    }

    void MoveLaser(GameObject laser, float posX, float posY, float duration)
    {
        laser.transform.DOMove(new Vector3(posX, posY, 1f), duration);
    }

    GameObject CreateBullet(float posX, float posY, float size, float angle, float speed, int level)
    {
        GameObject bulletClone = Instantiate(bullet, new Vector3(posX, posY, 1f), Quaternion.Euler(0f, 0f, 90f - angle));

        Bullet cloneScript = bulletClone.GetComponent<Bullet>();
        bulletClone.transform.localScale *= size;
        cloneScript.enabled = true;
        cloneScript.angle = angle;
        cloneScript.speed = speed;
        cloneScript.level = level;

        return bulletClone;
    }

    void UnloadAllScenesExcept(string sceneName)
    {
        int sceneNumber = SceneManager.sceneCount;
        for (int i = 0; i < sceneNumber; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name != sceneName)
            {
                SceneManager.UnloadSceneAsync(scene);
            }
        }
    }

    void BorderLeftScale(float scaleValue, float animationTime)
    {
        borderLeft.transform.DOMoveX(borderLeft.transform.position.x - scaleValue, animationTime);
    }

    void BorderRightScale(float scaleValue, float animationTime)
    {
        borderRight.transform.DOMoveX(borderRight.transform.position.x + scaleValue, animationTime);
    }

    void BorderTopScale(float scaleValue, float animationTime)
    {
        borderTop.transform.DOMoveY(borderTop.transform.position.y + scaleValue, animationTime);
    }

    void BorderBottomScale(float scaleValue, float animationTime)
    {
        borderBottom.transform.DOMoveY(borderBottom.transform.position.y - scaleValue, animationTime);
    }

    void PlayerAttraction(float angle, float force, float duration)
    {
        angle = (float)Math.PI * angle / 180;
        attractMovement = force * new Vector3((float)Math.Cos(angle), (float)Math.Sin(angle), 1f);
        isAttracted = true;
        StartCoroutine(WaitAttractEnd(duration));
    }

    IEnumerator WaitAttractEnd(float duration)
    {
        yield return new WaitForSeconds(duration);
        isAttracted = false;
    }
}
