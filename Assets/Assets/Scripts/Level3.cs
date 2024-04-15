using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3 : MonoBehaviour
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
        UnloadAllScenesExcept("Level3");
        PlayerPrefs.SetString("level", "Level3");
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
        yield return new WaitForSeconds (2.0f);

        GameObject laser;
        GameObject laser2;
        GameObject laser3;
        GameObject laser4;
        GameObject laser5;
        GameObject laser6;

        laser = CreateLaser(-3, 9, 2.0f, 3f, 0.0f);
        MoveLaser(laser,-3, -9, 1.0f);
        

        yield return new WaitForSeconds (0.5f);

        laser2 = CreateLaser(-9, -3, 2.0f, 3f, 90.0f);
        MoveLaser(laser2, 9, -3, 1.0f);

        yield return new WaitForSeconds (0.5f);

        laser3 = CreateLaser(3, -9, 2.0f, 3f, 0.0f);
        MoveLaser(laser3, 3, 9, 2.0f);
        MoveLaser(laser, 1, 0, 1.0f);   
        MoveLaser(laser2, 0, -1, 1.0f);

        yield return new WaitForSeconds (2.0f);

        laser4 = CreateLaser(0, -9, 2.0f, 3f, 0.0f);
        MoveLaser(laser4, -12, 0, 1.0f);
        MoveLaser(laser, 9, 0, 1.0f);
    
        yield return new WaitForSeconds (0.8f);

        MoveLaser(laser3, 0, 0, 1.0f);

        yield return new WaitForSeconds (1.0f);

        MoveLaser(laser, 0, 0, 1.0f);
        MoveLaser(laser2, 0, 0, 1.0f);
        MoveLaser(laser4, 0, 0, 1.0f);

        yield return new WaitForSeconds (1.0f);

        ScaleLaser(laser3, 0, 1, 1.0f);
        ScaleLaser(laser4, 0, 1, 1.0f);
        RotateLaser(laser3, 720, 20.0f);
        RotateLaser(laser4, 720, 20.0f);

        for (int i = 0; i < 2; i++)
        {
            MoveLaser(laser2, 0, 3, 1.0f);

            yield return new WaitForSeconds (1.5f);

            MoveLaser(laser, -3, 0, 1.0f);

            yield return new WaitForSeconds (1.5f);

            MoveLaser(laser2, 0, -3, 1.0f);

            yield return new WaitForSeconds (1.5f);

            MoveLaser(laser, 3, 0, 1.0f);

            yield return new WaitForSeconds (1.5f);
        }

        yield return new WaitForSeconds (5f);

        /*laser5 = CreateLaser(-1, 8, 2.0f, 2.5f, 0.0f);
        MoveLaser(laser5, 0, -9, 4);
        laser6 = CreateLaser(-1, 8, 2.0f, 2.5f, 0.0f);
        MoveLaser(laser6, 0, -9, 4);*/



        yield return new WaitForSeconds (3f);


        GameWon();
    }

    void EnableDeadlyBorders()
    {
        Color borderColor = new Color(1.0f, 0.0f, 0.0f);

        borders.tag = "Danger";
        borderLeft.GetComponent<SpriteRenderer>().color = borderColor;
        borderRight.GetComponent<SpriteRenderer>().color = borderColor;
        borderTop.GetComponent<SpriteRenderer>().color = borderColor;
        borderBottom.GetComponent<SpriteRenderer>().color = borderColor;
    }

    void DisableDeadlyBorders()
    {
        Color borderColor = new Color(1.0f, 1.0f, 1.0f);

        borders.tag = "Untagged";
        borderLeft.GetComponent<SpriteRenderer>().color = borderColor;
        borderRight.GetComponent<SpriteRenderer>().color = borderColor;
        borderTop.GetComponent<SpriteRenderer>().color = borderColor;
        borderBottom.GetComponent<SpriteRenderer>().color = borderColor;
    }

    GameObject CreateLaser(float posX, float posY, float laserWidth, float laserHeight, float angle)
    {
        GameObject laserClone = Instantiate(laser, new Vector3(posX, posY, 1.0f), Quaternion.Euler(0.0f, 0.0f, angle - 90.0f));
        Laser cloneScript = laserClone.GetComponent<Laser>();
        
        laserClone.transform.localScale = new Vector3(laserWidth, laserHeight, 1.0f);
        cloneScript.enabled = true;

        return laserClone;
    }

    void RotateLaser(GameObject laser, float angle, float duration)
    {
        laser.transform.DORotate(new Vector3(0.0f, 0.0f, angle + laser.transform.eulerAngles.z), duration, RotateMode.FastBeyond360);
    }

    void MoveLaser(GameObject laser, float posX, float posY, float duration)
    {
        laser.transform.DOMove(new Vector3(posX, posY, 1.0f), duration);
    }

    void ScaleLaser(GameObject laser, float width, float height, float duration)
    {
        laser.transform.DOScale(new Vector3(laser.transform.localScale.x + width, laser.transform.localScale.y + height, 1.0f), duration);
    }

    GameObject CreateBullet(float posX, float posY, float size, float angle, float speed, int level)
    {
        GameObject bulletClone = Instantiate(bullet, new Vector3(posX, posY, 1.0f), Quaternion.Euler(0.0f, 0.0f, 90.0f - angle));
        Bullet cloneScript = bulletClone.GetComponent<Bullet>();
        
        bulletClone.transform.localScale *= size;
        cloneScript.enabled = true;
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
        angle = Mathf.PI * angle / 180.0f;
        attractMovement = force * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 1.0f);
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
        player.transform.DOScale(new Vector3(player.transform.localScale.x + scaleValue, player.transform.localScale.y + scaleValue, 1.0f), animationTime);
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

