using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject laser;

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
        UnloadAllScenesExcept("Level2");
        PlayerPrefs.SetString("level", "Level2");
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
        // GameObject[] lasers;
        // GameObject laserClone;
        // GameObject laserClone2;

        // GameObject bullet;
        // GameObject bullet2;
        // GameObject bullet3;
        // GameObject bullet4;

        // yield return new WaitForSeconds(2.0f);

        // laserClone = CreateLaser(borderLeft.transform.position.x, borderTop.transform.position.y, 3.0f, 5.7f, 0.0f);
        // laserClone2 = CreateLaser(borderRight.transform.position.x, borderTop.transform.position.y, 3.0f, 5.7f, 0.0f);
        // RotateLaser(laserClone, -90.0f, 0.5f);
        // RotateLaser(laserClone2, 90.0f, 0.5f);

        // yield return new WaitForSeconds(0.1f);

        // PlayerAttraction(90.0f, 10.0f, 0.15f);

        // yield return new WaitForSeconds(0.15f);

        // CreateBullet(0.0f, 0.0f, 1.0f, -90.0f, 10.0f, 1);

        // yield return new WaitForSeconds(0.25f);

        // Destroy(laserClone);
        // Destroy(laserClone2);

        // bullet = CreateBullet(0.0f, 0.0f, 1.0f, 45.0f, 10.0f, 4);
        // bullet2 = CreateBullet(0.0f, 0.0f, 1.0f, -45.0f, 10.0f, 4);
        // bullet3 = CreateBullet(0.0f, 0.0f, 1.0f, 135.0f, 10.0f, 4);
        // bullet4 = CreateBullet(0.0f, 0.0f, 1.0f, -135.0f, 10.0f, 4);

        // yield return new WaitForSeconds(1.0f);

        // BorderTopScale(-5, 1.0f);
        // BorderLeftScale(-2.0f, 0.5f);
        // BorderBottomScale(-2.0f, 0.5f);

        // yield return new WaitForSeconds(0.5f);

        // PlayerScale(1.0f, 0.5f);

        // yield return new WaitForSeconds(0.5f);

        // laserClone = CreateLaser(borderTop.transform.position.x, borderLeft.transform.position.y, 3.0f, 4.0f, 90.0f);
        // RotateLaser(laserClone, -180.0f, 5.0f);

        // yield return new WaitForSeconds(2.0f);

        // PlayerScale(-1.0f, 1.0f);

        // yield return new WaitForSeconds(3.0f);

        // Destroy(laserClone);
        // Destroy(bullet);
        // Destroy(bullet2);
        // Destroy(bullet3);
        // Destroy(bullet4);
        // BorderTopScale(5, 0.5f);
        // BorderLeftScale(2.0f, 0.5f);
        // BorderBottomScale(2.0f, 0.5f);

        // yield return new WaitForSeconds(1.0f); //10.5'

        // EnableDeadlyBorders();
        // PlayerAttraction(0.0f, 6.0f, 10.0f);

        // for (int i = -8; i < 9; i++)
        // {
        //     if (i != 6 && i != 7)
        //     {
        //         CreateBullet(borderLeft.transform.position.x + 1.0f, i, 1.0f, 0.0f, 7.0f, 1);
        //     }
        // }

        // yield return new WaitForSeconds(1.0f);

        // for (int i = -8; i < 9; i++)
        // {
        //     if (i != 1 && i != 2)
        //     {
        //         CreateBullet(borderLeft.transform.position.x + 1.0f, i, 1.0f, 0.0f, 7.0f, 1);
        //     }
        // }

        // yield return new WaitForSeconds(1.0f);

        // for (int i = -8; i < 9; i++)
        // {
        //     if (i != -4 && i != -3)
        //     {
        //         CreateBullet(borderLeft.transform.position.x + 1.0f, i, 1.0f, 0.0f, 7.0f, 1);
        //     }
        // }

        // yield return new WaitForSeconds(1.0f);

        // for (int i = -8; i < 9; i++)
        // {
        //     if (i != 7 && i != 8)
        //     {
        //         CreateBullet(borderLeft.transform.position.x + 1.0f, i, 1.0f, 0.0f, 7.0f, 1);
        //     }
        // }

        // yield return new WaitForSeconds(2.0f);

        // BorderLeftScale(-5.0f, 1.0f);
        // BorderRightScale(-5.0f, 1.0f);
        // BorderTopScale(-5.0f, 1.0f);
        // BorderBottomScale(-5.0f, 1.0f);

        // yield return new WaitForSeconds(1.0f);

        // BorderLeftScale(-5.0f, 2.0f);
        // BorderRightScale(5.0f, 2.0f);
        // BorderTopScale(5.0f, 2.0f);
        // BorderBottomScale(-5.0f, 2.0f);

        // yield return new WaitForSeconds(2.0f);

        // BorderLeftScale(10.0f, 2.0f);
        // BorderRightScale(-10.0f, 2.0f);
        // BorderTopScale(-10.0f, 2.0f);
        // BorderBottomScale(10.0f, 2.0f);

        // yield return new WaitForSeconds(2.0f); //20.5'

        // BorderRightScale(10.0f, 2.0f);
        // BorderTopScale(10.0f, 2.0f);

        // yield return new WaitForSeconds(2.0f);

        // DisableDeadlyBorders();
        // for (int i = 0; i < 20; i++)
        // {
        //     CreateBullet(0.0f, 0.0f, 1.0f, 90.0f - i * 18.0f, 7.0f, 3);
        //     yield return new WaitForSeconds(0.25f);
        // }

        // CreateBullet(-8.0f, 8.0f, 1.0f, -30.0f, 11.0f, 3);
        // laserClone = CreateLaser(borderRight.transform.position.x, 0.0f, 3.0f, 4.0f, 90.0f);
        // MoveLaser(laserClone, 0.0f, 0.0f, 3.0f);

        // yield return new WaitForSeconds(4.0f); //31.5'

        // Destroy(laserClone);

        // yield return new WaitForSeconds(3.0f);

        // lasers = new GameObject[12];
        // for (int i = 0; i < 12; i++)
        // {
        //     lasers[i] = CreateLaser(0.0f, 0.0f, 3.0f, 4.0f, 180.0f - i * 36);
        //     ScaleLaser(lasers[i], 0.0f, -8.0f, 2.5f);
        //     RotateLaser(lasers[i], 180.0f, 5.0f);
        // }
        
        // yield return new WaitForSeconds(2.5f);

        // for (int i = 0; i < 12; i++)
        // {
        //     ScaleLaser(lasers[i], 0.0f, 8.0f, 2.5f);
        // }

        // yield return new WaitForSeconds(3.0f);

        // for (int i = 0; i < 12; i++)
        // {
        //     Destroy(lasers[i]);
        // }

        RotateBorders(30.0f, 2.0f);

        yield return new WaitForSeconds(2.0f);

        // BorderLeftScale(10.0f, 2.0f);
        // BorderRightScale(-10.0f, 2.0f);
        // BorderTopScale(-10.0f, 2.0f);
        // BorderBottomScale(10.0f, 2.0f);

        yield return new WaitForSeconds(2.0f);
        
        GameWon();
    }

    void EnableDeadlyBorders()
    {
        Color borderColor = new(1.0f, 0.0f, 0.0f);

        borders.tag = "Danger";
        borderLeft.GetComponent<SpriteRenderer>().color = borderColor;
        borderRight.GetComponent<SpriteRenderer>().color = borderColor;
        borderTop.GetComponent<SpriteRenderer>().color = borderColor;
        borderBottom.GetComponent<SpriteRenderer>().color = borderColor;
    }

    void DisableDeadlyBorders()
    {
        Color borderColor = new(1.0f, 1.0f, 1.0f);

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

    void RotateBorders(float angle, float animationTime)
    {
        borders.transform.DORotate(new Vector3(0.0f, 0.0f, angle), animationTime);
    }

    void PlayerAttraction(float angle, float force, float duration)
    {
        angle = Mathf.PI * angle / 180;
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
