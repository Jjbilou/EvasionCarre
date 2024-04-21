using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEvents : MonoBehaviour
{
    static GameObject bullet;
    static GameObject laser;
    static GameObject redLine;
    static Transform borders;
    static Transform borderLeft;
    static Transform borderRight;
    static Transform borderTop;
    static Transform borderBottom;
    static Transform player;
    static PlayerCollision playerCollision;

    public static void Init()
    {
        Destroy(GameObject.Find("MenuBGM"));

        bullet = (GameObject)Resources.Load("Bullet");
        laser = (GameObject)Resources.Load("Laser");
        redLine = (GameObject)Resources.Load("RedLine");

        borders = GameObject.Find("Borders").transform;
        borderLeft = borders.Find("Left");
        borderRight = borders.Find("Right");
        borderTop = borders.Find("Top");
        borderBottom = borders.Find("Bottom");

        player = GameObject.Find("Player").transform;
        playerCollision = player.GetComponent<PlayerCollision>();

        DOTween.Init();
        DOTween.defaultEaseType = Ease.Linear;
    }

    public static float GetLeftX()
    {
        return borderLeft.position.x;
    }

    public static float GetMiddleX()
    {
        return borderTop.position.x;
    }

    public static float GetRightX()
    {
        return borderRight.position.x;
    }

    public static float GetTopY()
    {
        return borderTop.position.y;
    }

    public static float GetMiddleY()
    {
        return borderLeft.position.y;
    }

    public static float GetBottomY()
    {
        return borderBottom.position.y;
    }

    public static void EnableDeadlyBorders()
    {
        Color borderColor = new(1.0f, 0.0f, 0.0f);

        borders.tag = "Danger";
        borderLeft.GetComponent<SpriteRenderer>().color = borderColor;
        borderRight.GetComponent<SpriteRenderer>().color = borderColor;
        borderTop.GetComponent<SpriteRenderer>().color = borderColor;
        borderBottom.GetComponent<SpriteRenderer>().color = borderColor;
    }

    public static void DisableDeadlyBorders()
    {
        Color borderColor = new(1.0f, 1.0f, 1.0f);

        borders.tag = "Untagged";
        borderLeft.GetComponent<SpriteRenderer>().color = borderColor;
        borderRight.GetComponent<SpriteRenderer>().color = borderColor;
        borderTop.GetComponent<SpriteRenderer>().color = borderColor;
        borderBottom.GetComponent<SpriteRenderer>().color = borderColor;
    }

    public static void CloseBorderLeft(float scaleValue, float duration)
    {
        borderLeft.DOLocalMoveX(scaleValue, duration).SetRelative();
    }

    public static void CloseBorderRight(float scaleValue, float duration)
    {
        borderRight.DOLocalMoveX(-scaleValue, duration).SetRelative();
    }

    public static void CloseBorderX(float scaleValue, float duration)
    {
        CloseBorderLeft(scaleValue, duration);
        CloseBorderRight(scaleValue, duration);
    }

    public static void CloseBorderTop(float scaleValue, float duration)
    {
        borderTop.DOLocalMoveY(-scaleValue, duration).SetRelative();
    }

    public static void CloseBorderBottom(float scaleValue, float duration)
    {
        borderBottom.DOLocalMoveY(scaleValue, duration).SetRelative();
    }

    public static void CloseBorderY(float scaleValue, float duration)
    {
        CloseBorderTop(scaleValue, duration);
        CloseBorderBottom(scaleValue, duration);
    }

    public static void CloseBorderAll(float scaleValue, float duration)
    {
        CloseBorderX(scaleValue, duration);
        CloseBorderY(scaleValue, duration);
    }

    public static void ResetBordersCloseness(float duration)
    {
        borderLeft.DOLocalMoveX(-9.0f, duration);
        borderRight.DOLocalMoveX(9.0f, duration);
        borderTop.DOLocalMoveY(9.0f, duration);
        borderBottom.DOLocalMoveY(-9.0f, duration);
    }

    public static void MoveBorders(float posX, float posY, float duration)
    {
        borders.DOMove(new Vector3(posX, posY, 1.0f), duration);
    }

    public static void ResetBordersPosition(float duration)
    {
        borders.DOMove(Vector3.zero, duration);
    }

    public static void RotateBorders(float angle, float duration)
    {
        borders.DORotate(new Vector3(0.0f, 0.0f, angle), duration, RotateMode.FastBeyond360).SetRelative();
    }

    public static void ResetBordersRotation(float duration)
    {
        borders.DORotate(Vector3.zero, duration);
    }

    public static void ResetBorders(float duration)
    {
        ResetBordersPosition(duration);
        ResetBordersRotation(duration);
        ResetBordersCloseness(duration);
    }

    public static GameObject CreateLaser(float posX, float posY, float laserWidth, float laserHeight, float angle)
    {
        GameObject laserClone = Instantiate(laser, new Vector3(posX, posY, 1.0f), Quaternion.Euler(0.0f, 0.0f, 90.0f - angle));

        laserClone.transform.localScale = new Vector3(laserWidth, laserHeight, 1.0f);

        return laserClone;
    }

    public static void RotateLaser(GameObject laser, float angle, float duration)
    {
        laser.transform.DORotate(new Vector3(0.0f, 0.0f, angle), duration, RotateMode.FastBeyond360).SetRelative();
    }

    public static void MoveLaser(GameObject laser, float posX, float posY, float duration)
    {
        laser.transform.DOMove(new Vector3(posX, posY, 1.0f), duration);
    }

    public static void ScaleLaser(GameObject laser, float width, float height, float duration)
    {
        laser.transform.DOScale(new Vector3(laser.transform.localScale.x + width, laser.transform.localScale.y + height, 1.0f), duration);
    }

    public static GameObject CreateBullet(float posX, float posY, float size, float angle, float speed, int level)
    {
        GameObject bulletClone = Instantiate(bullet, new Vector3(posX, posY, 1.0f), Quaternion.Euler(0.0f, 0.0f, 90.0f - angle));
        bulletClone.transform.localScale *= size;

        Bullet cloneScript = bulletClone.GetComponent<Bullet>();
        cloneScript.angle = angle;
        cloneScript.speed = speed;
        cloneScript.level = level;

        return bulletClone;
    }

    public static GameObject CreateRedLine(float posX, float posY, float angle)
    {
        GameObject redLineClone = Instantiate(redLine, new Vector3(posX, posY, 1f), Quaternion.Euler(0f, 0f, angle - 90f));
        return redLineClone;
    }

    public static void MoveRedLine(GameObject redLine, float posX, float posY, float duration)
    {
        redLine.transform.DOMove(new Vector3(posX, posY, 1f), duration);
    }

    public static void PlayerAttraction(float angle, float force, float duration)
    {
        angle = Mathf.PI * angle / 180.0f;
        playerCollision.attractMovement = force * new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        playerCollision.attractingTime = duration;
    }

    public static void PlayerScale(float scaleValue, float duration)
    {
        player.DOScale(new Vector3(scaleValue, scaleValue, 0.0f), duration).SetRelative();
    }

    public static void GameWon()
    {
        DOTween.KillAll();
        SceneManager.LoadScene("WinMenu");
    }
}
