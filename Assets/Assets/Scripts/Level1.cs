using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject laser;

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
        borderLeft = GameObject.Find("Left");
        borderRight = GameObject.Find("Right");
        borderTop = GameObject.Find("Top");
        borderBottom = GameObject.Find("Bottom");
        player = GameObject.Find("Player");
        playerCollision = player.GetComponent<PlayerCollision>();
        UnloadAllScenesExcept("Level1");
        PlayerPrefs.SetString("level", "Level1");
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
        GameObject laserClone;

        yield return new WaitForSeconds(2.0f);

        PlayerAttraction(90.0f, 10.0f, 2.0f);
        PlayerScale(1.0f, 1.0f);

        yield return new WaitForSeconds(2.0f);

        PlayerScale(-1.0f, 1.0f);

        yield return new WaitForSeconds(2.0f);

        EnableDeadlyBorders();

        yield return new WaitForSeconds(1.0f);

        laserClone = CreateLaser(borderLeft.transform.position.x, borderTop.transform.position.y, 3.0f, 5.3f, 0.0f);
        RotateLaser(laserClone, 180.0f, 2.0f);
        MoveLaser(laserClone, borderRight.transform.position.x, borderTop.transform.position.y, 2.0f);

        yield return new WaitForSeconds(2.0f);

        Destroy(laserClone);
        DisableDeadlyBorders();
        CreateBullet(7.0f, 0.0f, 1.0f, 135.0f, 15.0f, 3);
        CreateBullet(7.0f, 0.0f, 1.0f, -135.0f, 15.0f, 2);
        laserClone = CreateLaser(borderTop.transform.position.x, borderLeft.transform.position.y, 3.0f, 3.0f, 0.0f);
        RotateLaser(laserClone, -900.0f, 5.0f);

        yield return new WaitForSeconds(2.0f);

        BorderRightScale(-2.0f, 1.0f);
        BorderTopScale(-2.0f, 1.0f);
        MoveLaser(laserClone, laserClone.transform.position.x - 1.0f, laserClone.transform.position.y - 1.0f, 2.0f);

        yield return new WaitForSeconds(3.0f);

        GameWon();
    }

    void EnableDeadlyBorders()
    {
        Color borderColor = new(1.0f, 0.0f, 0.0f);

        gameObject.tag = "Danger";
        borderLeft.GetComponent<SpriteRenderer>().color = borderColor;
        borderRight.GetComponent<SpriteRenderer>().color = borderColor;
        borderTop.GetComponent<SpriteRenderer>().color = borderColor;
        borderBottom.GetComponent<SpriteRenderer>().color = borderColor;
    }

    void DisableDeadlyBorders()
    {
        Color borderColor = new(1.0f, 1.0f, 1.0f);

        gameObject.tag = "Untagged";
        borderLeft.GetComponent<SpriteRenderer>().color = borderColor;
        borderRight.GetComponent<SpriteRenderer>().color = borderColor;
        borderTop.GetComponent<SpriteRenderer>().color = borderColor;
        borderBottom.GetComponent<SpriteRenderer>().color = borderColor;
    }

    GameObject CreateLaser(float posX, float posY, float laserWidth, float laserHeight, float angle)
    {
        GameObject laserClone = Instantiate(laser, new Vector3(posX, posY, 1.0f), Quaternion.Euler(0.0f, 0.0f, 90.0f - angle));
        Laser cloneScript = laserClone.GetComponent<Laser>();
        
        laserClone.transform.localScale = new Vector3(laserWidth, laserHeight, 1.0f);
        cloneScript.enabled = true;

        return laserClone;
    }

    void RotateLaser(GameObject laser, float angle, float duration)
    {
        laser.transform.DORotate(new Vector3(0.0f, 0.0f, 90.0f - laser.transform.rotation.z + angle), duration);
    }

    void MoveLaser(GameObject laser, float posX, float posY, float duration)
    {
        laser.transform.DOMove(new Vector3(posX, posY, 1.0f), duration);
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
