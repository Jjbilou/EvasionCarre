using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
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
    GameObject player;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject laser;

    bool isAttracted = false;
    Vector3 attractMovement;
    PlayerCollision playerCollision;

    // Start is called before the first frame update
    void Start()
    {
        playerCollision = player.GetComponent<PlayerCollision>();
        UnloadAllScenesExcept("Game");
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
            StopAllCoroutines();
        }
    }

    IEnumerator Launch()
    {
        GameObject laserClone;
        GameObject laserClone2;

        GameObject bullet;
        GameObject bullet2;
        GameObject bullet3;
        GameObject bullet4;

        yield return new WaitForSeconds(2f);

        laserClone = CreateLaser(borderLeft.transform.position.x, borderTop.transform.position.y, 3f, 5.7f, 0f);
        laserClone2 = CreateLaser(borderRight.transform.position.x, borderTop.transform.position.y, 3f, 5.7f, 0f);
        RotateLaser(laserClone, -90f, 0.5f);
        RotateLaser(laserClone2, 90f, 0.5f);

        yield return new WaitForSeconds(0.1f);

        PlayerAttraction(90f, 10f, 0.15f);

        yield return new WaitForSeconds(0.15f);

        CreateBullet(0f, 0f, 1f, -90f, 10f, 1);

        yield return new WaitForSeconds(0.25f);

        Destroy(laserClone);
        Destroy(laserClone2);

        bullet = CreateBullet(0f, 0f, 1f, 45f, 10f, 4);
        bullet2 = CreateBullet(0f, 0f, 1f, -45f, 10f, 4);
        bullet3 = CreateBullet(0f, 0f, 1f, 135f, 10f, 4);
        bullet4 = CreateBullet(0f, 0f, 1f, -135f, 10f, 4);

        yield return new WaitForSeconds(1f);

        BorderTopScale(-5, 1f);
        BorderLeftScale(-2f, 0.5f);
        BorderBottomScale(-2f, 0.5f);

        yield return new WaitForSeconds(0.5f);

        PlayerScale(1f, 0.5f);

        yield return new WaitForSeconds(0.5f);

        laserClone = CreateLaser(borderTop.transform.position.x, borderLeft.transform.position.y, 3f, 4f, 90f);
        RotateLaser(laserClone, 180f, 5f);

        yield return new WaitForSeconds(2f);

        PlayerScale(-1f, 1f);

        yield return new WaitForSeconds(3f);

        Destroy(laserClone);
        Destroy(bullet);
        Destroy(bullet2);
        Destroy(bullet3);
        Destroy(bullet4);
        BorderTopScale(5, 0.5f);
        BorderLeftScale(2f, 0.5f);
        BorderBottomScale(2f, 0.5f);

        yield return new WaitForSeconds(1f); //10.5'

        EnableDeadlyBorders();
        PlayerAttraction(0f, 6f, 10f);

        for (int i = -9; i < 9; i++)
        {
            if (i != 6 && i != 7)
            {
                CreateBullet(borderLeft.transform.position.x + 1f, i, 1f, 0f, 7f, 1);
            }
        }

        yield return new WaitForSeconds(1f);

        for (int i = -9; i < 9; i++)
        {
            if (i != 1 && i != 2)
            {
                CreateBullet(borderLeft.transform.position.x + 1f, i, 1f, 0f, 7f, 1);
            }
        }

        yield return new WaitForSeconds(1f);

        for (int i = -9; i < 9; i++)
        {
            if (i != -4 && i != -3)
            {
                CreateBullet(borderLeft.transform.position.x + 1f, i, 1f, 0f, 7f, 1);
            }
        }

        yield return new WaitForSeconds(1f);

        for (int i = -9; i < 9; i++)
        {
            if (i != 7 && i != 8)
            {
                CreateBullet(borderLeft.transform.position.x + 1f, i, 1f, 0f, 7f, 1);
            }
        }

        yield return new WaitForSeconds(1f);

        BorderLeftScale(-5f, 1);
        BorderRightScale(-5f, 1);
        BorderTopScale(-5f, 1);
        BorderBottomScale(-5f, 1);

        yield return new WaitForSeconds(1f);

        BorderLeftScale(-5f, 2);
        BorderRightScale(5f, 2);
        BorderTopScale(5f, 2);
        BorderBottomScale(-5f, 2);

        yield return new WaitForSeconds(2f);

        BorderLeftScale(10f, 2);
        BorderRightScale(-10f, 2);
        BorderTopScale(-10f, 2);
        BorderBottomScale(10f, 2);

        yield return new WaitForSeconds(2f);

        BorderRightScale(10f, 2);
        BorderTopScale(10f, 2);

        yield return new WaitForSeconds(2f); //21.5'

        DisableDeadlyBorders();
        for (int i = 0; i < 20; i++)
        {
            CreateBullet(0f, 0f, 1f, 90f - i * 18f, 7f, 3);
            yield return new WaitForSeconds(0.25f);
        }

        CreateBullet(-8f, 8f, 1f, -30f, 11f, 3);
        laserClone = CreateLaser(borderRight.transform.position.x, 0, 3f, 4f, 90f);
        MoveLaser(laserClone, 0, 0, 3);
        
        yield return new WaitForSeconds(4f); //30.5'

        Destroy(laserClone);

        yield return new WaitForSeconds(3f);

        GameWon();
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

    void RotateLaser(GameObject laser, float angle, float duration)
    {
        laser.transform.DORotate(new Vector3(0f, 0f, 90f - transform.rotation.z + angle), duration);
    }

    void MoveLaser(GameObject laser, float posX, float posY, float duration)
    {
        laser.transform.DOMove(new Vector3(posX, posY, 1f), duration);
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

    void PlayerScale(float scaleValue, float animationTime)
    {
        player.transform.DOScale(new Vector3(player.transform.localScale.x + scaleValue, player.transform.localScale.y + scaleValue, 1f), animationTime);
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

    void GameWon()
    {
        StopAllCoroutines();
        DOTween.PauseAll();
        SceneManager.LoadScene("WinMenu");
    }
}
