using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelTuto : MonoBehaviour
{
    GameObject borderLeft;
    GameObject borderRight;
    GameObject borderTop;
    GameObject borderBottom;
    GameObject player;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject laser;
    [SerializeField]
    TMP_Text Txt1;
    [SerializeField]
    TMP_Text Txt2;
    [SerializeField]
    TMP_Text Txt3;
    [SerializeField]
    TMP_Text Txt4;
    [SerializeField]
    TMP_Text Txt5;
    [SerializeField]
    TMP_Text Txt6;
    [SerializeField]
    TMP_Text Txt7;
    [SerializeField]
    TMP_Text Txt8;
    [SerializeField]
    TMP_Text Txt9;
    [SerializeField]
    TMP_Text Txt10;
    [SerializeField]
    TMP_Text Txt11;
    [SerializeField]
    TMP_Text Txt12;
    [SerializeField]
    TMP_Text Txt13;

    bool isAttracted = false;
    public bool clear = false;
    Vector3 attractMovement;
    PlayerCollision playerCollision;


    // Start is called before the first frame update
    void Start()
    {
        borderLeft = GameObject.Find("Left");
        borderRight = GameObject.Find("Right");
        borderTop = GameObject.Find("Top");
        borderBottom = GameObject.Find("Bottom");
        player = GameObject.Find("Player");
        playerCollision = player.GetComponent<PlayerCollision>();
        Txt1.enabled = false;
        Txt2.enabled = false;
        Txt3.enabled = false;
        Txt4.enabled = false;
        Txt5.enabled = false;
        Txt6.enabled = false;
        Txt7.enabled = false;
        Txt8.enabled = false;
        Txt9.enabled = false;
        Txt10.enabled = false;
        Txt11.enabled = false;
        Txt12.enabled = false;
        Txt13.enabled = false;
        UnloadAllScenesExcept("LevelTuto");
        PlayerPrefs.SetString("level", "LevelTuto");
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
        GameObject bullet;
        GameObject laser;
        GameObject laser2;
        GameObject laser3;

        yield return new WaitForSeconds (1f);

        Txt1.enabled = true;

        yield return new WaitForSeconds (5f);

        Txt1.enabled = false;
        Txt2.enabled = true;

        yield return new WaitForSeconds (5f);

        Txt2.enabled = false;
        Txt3.enabled = true;
        bullet = CreateBullet(0f, 0f, 1f, 180f, 10f, 4);

        yield return new WaitForSeconds (7f);

        Destroy(bullet);
        Txt3.enabled = false;
        Txt4.enabled = true;

        yield return new WaitForSeconds (2f);

        CreateBullet(0f, 0f, 1f, 180f, 10f, 3);

        yield return new WaitForSeconds (7f);

        Txt4.enabled = false;
        Txt5.enabled = true;
        laser = CreateLaser(borderTop.transform.position.x, borderLeft.transform.position.y, 2f, 2f, 0f);
        MoveLaser(laser, 0, -5, 5);

        yield return new WaitForSeconds (7f);

        Txt5.enabled = false;
        Txt6.enabled = true;
        MoveLaser(laser, 0, 2, 5);

        yield return new WaitForSeconds (5f);

        RotateLaser(laser, 180f, 5f);

        yield return new WaitForSeconds (7f);

        Destroy(laser);
        Txt6.enabled = false;
        Txt7.enabled = true;

        yield return new WaitForSeconds (3f);

        EnableDeadlyBorders();

        yield return new WaitForSeconds (3f);

        Txt7.enabled = false;
        Txt8.enabled = true;

        yield return new WaitForSeconds (2f);
        
        DisableDeadlyBorders();
        BorderLeftScale(-8f, 3);
        BorderRightScale(-8f, 3);
        BorderTopScale(-8f, 3);
        BorderBottomScale(-8f, 3);

        yield return new WaitForSeconds (6f);

        Txt8.enabled = false;
        Txt9.enabled = true;
        BorderLeftScale(8f, 3);
        BorderRightScale(8f, 3);
        BorderTopScale(8f, 3);
        BorderBottomScale(8f, 3);

        yield return new WaitForSeconds (6f);

        Txt9.enabled = false;
        Txt10.enabled = true;
        PlayerAttraction(0f, 10f, 5f);
        
        yield return new WaitForSeconds (5f);

        PlayerAttraction(180f, 20f, 5f);

        yield return new WaitForSeconds (5f);

        Txt10.enabled = false;
        Txt11.enabled = true;
        PlayerScale(4f, 2f);

        yield return new WaitForSeconds (3f);

        PlayerScale(-4f, 2f);

        yield return new WaitForSeconds (3f);

        Txt11.enabled = false;
        Txt12.enabled = true;

        yield return new WaitForSeconds (5f);

        Txt12.enabled = false;
        Txt13.enabled = true;

        yield return new WaitForSeconds (2f);

        Txt13.enabled = false;
        clear = true;
        laser2 = CreateLaser(0, 0, 2f, 3f, 0f);
        laser3 = CreateLaser(0, 0, 2f, 3f, 90f);
        RotateLaser(laser2, 360, 10);
        RotateLaser(laser3, 360, 10);
        for (int i = 0; i < 20; i++)
            {
                CreateBullet(0f, 0f, 1f, 90f - i * 18f, 7f, 4);
                CreateBullet(0f, 0f, 1f, 90f + i * 18f, 7f, 4);
                yield return new WaitForSeconds(0.05f);
            }

        yield return new WaitForSeconds (10f);
    
        GameWon();
    }

    void EnableDeadlyBorders()
    {
        Color borderColor = new Color(1f, 0f, 0f);

        gameObject.tag = "Danger";
        borderLeft.GetComponent<SpriteRenderer>().color = borderColor;
        borderRight.GetComponent<SpriteRenderer>().color = borderColor;
        borderTop.GetComponent<SpriteRenderer>().color = borderColor;
        borderBottom.GetComponent<SpriteRenderer>().color = borderColor;
    }

    void DisableDeadlyBorders()
    {
        Color borderColor = new Color(1f, 1f, 1f);

        gameObject.tag = "Untagged";
        borderLeft.GetComponent<SpriteRenderer>().color = borderColor;
        borderRight.GetComponent<SpriteRenderer>().color = borderColor;
        borderTop.GetComponent<SpriteRenderer>().color = borderColor;
        borderBottom.GetComponent<SpriteRenderer>().color = borderColor;
    }


    GameObject CreateLaser(float posX, float posY, float laserWidth, float laserHeight, float angle)
    {
        GameObject laserClone = Instantiate(laser, new Vector3(posX, posY, 1f), Quaternion.Euler(0f, 0f, angle - 90f));
        Laser cloneScript = laserClone.GetComponent<Laser>();
        cloneScript.enabled = true;
        cloneScript.laserWidth = laserWidth;
        cloneScript.laserHeight = laserHeight;

        return laserClone;
    }

    void RotateLaser(GameObject laser, float angle, float duration)
    {
        laser.transform.DORotate(new Vector3(0f, 0f, angle + laser.transform.eulerAngles.z), duration, RotateMode.FastBeyond360);
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
        SceneManager.LoadScene("MainMenu");
    }
}

