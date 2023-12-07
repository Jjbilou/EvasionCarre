using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using DG.Tweening;
using Unity.Mathematics;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    GameObject player;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject ParticleSystem;
    [SerializeField] 
    GameObject laser;

    bool isAttracted = false;
    Vector3 attractMovement;

    // Start is called before the first frame update
    void Start()
    {
        UnloadAllScenesExcept("Game");
        StartCoroutine(Launch());
    }

    IEnumerator Launch()
    {
        GameObject laserClone;

        yield return new WaitForSeconds(2f);

        PlayerAttraction(90f, 10f, 2f);
        PlayerScale(1f, 1f);

        yield return new WaitForSeconds(2f);

        PlayerScale(-1f, 1f);

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

        GameWon();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttracted)
        {
            player.transform.position += attractMovement * Time.deltaTime;
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
