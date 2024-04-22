using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEvents : MonoBehaviour
{
    static GameObject bullet;
    static GameObject laser;
    static GameObject redLine;

    static Transform borders;
    static Borders bordersScript;
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
        bordersScript = borders.GetComponent<Borders>();
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

    static void ChangeBordersColor(Color borderColor)
    {
        borderLeft.GetComponent<SpriteRenderer>().color = borderColor;
        borderRight.GetComponent<SpriteRenderer>().color = borderColor;
        borderTop.GetComponent<SpriteRenderer>().color = borderColor;
        borderBottom.GetComponent<SpriteRenderer>().color = borderColor;
    }

    public static void EnableDeadlyBorders()
    {
        borders.tag = "Danger";
        ChangeBordersColor(new Color(1.0f, 0.0f, 0.0f));
    }

    public static void DisableDeadlyBorders()
    {
        borders.tag = "Untagged";
        ChangeBordersColor(new Color(1.0f, 1.0f, 1.0f));
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

    public static void ScaleBorderLeft(float scaleValue, float duration)
    {
        borderLeft.DOScaleY(scaleValue, duration).SetRelative();
        bordersScript.scalingLeftTime = duration;
    }

    public static void ScaleBorderRight(float scaleValue, float duration)
    {
        borderRight.DOScaleY(scaleValue, duration).SetRelative();
        bordersScript.scalingRightTime = duration;
    }

    public static void ScaleBorderTop(float scaleValue, float duration)
    {
        borderTop.DOScaleX(scaleValue, duration).SetRelative();
        bordersScript.scalingTopTime = duration;
    }

    public static void ScaleBorderBottom(float scaleValue, float duration)
    {
        borderBottom.DOScaleX(scaleValue, duration).SetRelative();
        bordersScript.scalingBottomTime = duration;
    }

    public static void ResetBordersCloseness(float duration)
    {
        borderLeft.DOLocalMoveX(-9.0f, duration);
        borderRight.DOLocalMoveX(9.0f, duration);
        borderTop.DOLocalMoveY(9.0f, duration);
        borderBottom.DOLocalMoveY(-9.0f, duration);
    }

    public static void MoveBorderLeft(float posX, float posY, float duration)
    {
        borderLeft.DOLocalMove(new Vector3(posX, posY), duration).SetRelative();
        bordersScript.movingLeftTime = duration;
    }

    public static void MoveBorderRight(float posX, float posY, float duration)
    {
        borderRight.DOLocalMove(new Vector3(posX, posY), duration).SetRelative();
        bordersScript.movingRightTime = duration;
    }

    public static void MoveBorderTop(float posX, float posY, float duration)
    {
        borderTop.DOLocalMove(new Vector3(posX, posY), duration).SetRelative();
        bordersScript.movingTopTime = duration;
    }

    public static void MoveBorderBottom(float posX, float posY, float duration)
    {
        borderBottom.DOLocalMove(new Vector3(posX, posY), duration).SetRelative();
        bordersScript.movingBottomTime = duration;
    }

    public static void MoveBorders(float posX, float posY, float duration)
    {
        borders.DOMove(new Vector3(posX, posY), duration).SetRelative();
    }

    public static void ResetBordersPosition(float duration)
    {
        borders.DOMove(Vector3.zero, duration);
        MoveBorderLeft(-9.0f, 0.0f, duration);
        MoveBorderRight(9.0f, 0.0f, duration);
        MoveBorderTop(0.0f, 9.0f, duration);
        MoveBorderBottom(0.0f, -9.0f, duration);
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

    public static Transform CreateLaser(float posX, float posY, float laserWidth, float laserHeight, float angle)
    {
        Transform laserClone = Instantiate(laser, new Vector3(posX, posY), Quaternion.Euler(0.0f, 0.0f, 90.0f - angle)).transform;

        laserClone.localScale = new Vector3(laserWidth, laserHeight);

        return laserClone;
    }

    public static void RotateLaser(Transform laser, float angle, float duration)
    {
        laser.DORotate(new Vector3(0.0f, 0.0f, angle), duration, RotateMode.FastBeyond360).SetRelative();
    }

    public static void MoveLaser(Transform laser, float posX, float posY, float duration)
    {
        laser.DOMove(new Vector3(posX, posY), duration).SetRelative();
    }

    public static void ScaleLaser(Transform laser, float width, float height, float duration)
    {
        laser.DOScale(new Vector3(width, height), duration).SetRelative();
    }

    public static void ScaleLaser(Transform laser, float multiplier, float duration)
    {
        laser.DOScale(multiplier * laser.localScale, duration);
    }

    public static GameObject CreateBullet(float posX, float posY, float size, float angle, float speed, int level)
    {
        GameObject bulletClone = Instantiate(bullet, new Vector3(posX, posY), Quaternion.Euler(0.0f, 0.0f, 90.0f - angle));
        bulletClone.transform.localScale *= size;

        Bullet cloneScript = bulletClone.GetComponent<Bullet>();
        cloneScript.angle = angle;
        cloneScript.speed = speed;
        cloneScript.level = level;

        return bulletClone;
    }

    public static Transform CreateRedLine(float posX, float posY, float angle)
    {
        return Instantiate(redLine, new Vector3(posX, posY), Quaternion.Euler(0f, 0f, angle - 90f)).transform;
    }

    public static void MoveRedLine(Transform redLine, float posX, float posY, float duration)
    {
        redLine.DOMove(new Vector3(posX, posY), duration).SetRelative();
    }

    public static void PlayerAttraction(float angle, float force, float duration)
    {
        angle = Mathf.PI * angle / 180.0f;
        playerCollision.attractMovement = force * new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        playerCollision.attractingTime = duration;
    }

    public static void PlayerScale(float scaleX, float scaleY, float duration)
    {
        player.DOScale(new Vector3(scaleX, scaleY), duration).SetRelative();
    }

    public static void PlayerScale(float multiplier, float duration)
    {
        player.DOScale(multiplier * player.localScale, duration);
    }

    public static void GameWon()
    {
        DOTween.KillAll();
        SceneManager.LoadScene("WinMenu");
    }
}
