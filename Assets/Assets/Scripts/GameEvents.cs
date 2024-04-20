using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEvents : MonoBehaviour
{
    static GameObject bullet;
    static GameObject laser;
    static GameObject redLine;
    static GameObject borders;
    static GameObject borderLeft;
    static GameObject borderRight;
    static GameObject borderTop;
    static GameObject borderBottom;
    static GameObject player;
    static PlayerCollision playerCollision;

    public static void Init(string level)
    {
        bullet = (GameObject)Resources.Load("Bullet");
        laser = (GameObject)Resources.Load("Laser");
        redLine = (GameObject)Resources.Load("RedLine");
        borders = GameObject.Find("Borders");
        borderLeft = GameObject.Find("Left");
        borderRight = GameObject.Find("Right");
        borderTop = GameObject.Find("Top");
        borderBottom = GameObject.Find("Bottom");
        player = GameObject.Find("Player");
        playerCollision = player.GetComponent<PlayerCollision>();
        UnloadAllScenesExcept(level);
        PlayerPrefs.SetString("level", level);
        DOTween.defaultEaseType = Ease.Linear;
    }

    public static float GetLeftX()
    {
        return borderLeft.transform.position.x;
    }

    public static float GetMiddleX()
    {
        return borderTop.transform.position.x;
    }

    public static float GetRightX()
    {
        return borderRight.transform.position.x;
    }

    public static float GetTopY()
    {
        return borderTop.transform.position.y;
    }

    public static float GetMiddleY()
    {
        return borderLeft.transform.position.y;
    }

    public static float GetBottomY()
    {
        return borderBottom.transform.position.y;
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

    public static void BorderScaleLeft(float scaleValue, float animationTime)
    {
        borderLeft.transform.DOLocalMoveX(borderLeft.transform.localPosition.x - scaleValue, animationTime);
    }

    public static void BorderScaleRight(float scaleValue, float animationTime)
    {
        borderRight.transform.DOLocalMoveX(borderRight.transform.localPosition.x + scaleValue, animationTime);
    }

    public static void BorderScaleX(float scaleValue, float animationTime)
    {
        BorderScaleLeft(scaleValue, animationTime);
        BorderScaleRight(scaleValue, animationTime);
    }

    public static void BorderScaleTop(float scaleValue, float animationTime)
    {
        borderTop.transform.DOLocalMoveY(borderTop.transform.localPosition.y + scaleValue, animationTime);
    }

    public static void BorderScaleBottom(float scaleValue, float animationTime)
    {
        borderBottom.transform.DOLocalMoveY(borderBottom.transform.localPosition.y - scaleValue, animationTime);
    }

    public static void BorderScaleY(float scaleValue, float animationTime)
    {
        BorderScaleTop(scaleValue, animationTime);
        BorderScaleBottom(scaleValue, animationTime);
    }

    public static void BorderScaleAll(float scaleValue, float animationTime)
    {
        BorderScaleX(scaleValue, animationTime);
        BorderScaleY(scaleValue, animationTime);
    }

    public static void ResetBorders()
    {
        borderLeft.transform.DOMove(new Vector3(-9f, 0.0f, 1.0f), 1.0f);
        borderRight.transform.DOMove(new Vector3(9f, 0.0f, 1.0f), 1.0f);
        borderTop.transform.DOMove(new Vector3(0.0f, 9f, 1.0f), 1.0f);
        borderBottom.transform.DOMove(new Vector3(0.0f, -9f, 1.0f), 1.0f);
    }

    public static void RotateBorders(float angle, float animationTime)
    {
        borders.transform.DORotate(new Vector3(0.0f, 0.0f, angle), animationTime);
    }

    public static GameObject CreateLaser(float posX, float posY, float laserWidth, float laserHeight, float angle)
    {
        GameObject laserClone = Instantiate(laser, new Vector3(posX, posY, 1.0f), Quaternion.Euler(0.0f, 0.0f, 90.0f - angle));

        laserClone.transform.localScale = new Vector3(laserWidth, laserHeight, 1.0f);

        return laserClone;
    }

    public static void RotateLaser(GameObject laser, float angle, float duration)
    {
        laser.transform.DORotate(new Vector3(0.0f, 0.0f, 90.0f - laser.transform.rotation.z + angle), duration);
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

    public static void PlayerScale(float scaleValue, float animationTime)
    {
        player.transform.DOScale(new Vector3(player.transform.localScale.x + scaleValue, player.transform.localScale.y + scaleValue, 1.0f), animationTime);
    }

    public static void UnloadAllScenesExcept(string sceneName)
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

    public static void GameWon()
    {
        DOTween.KillAll();
        SceneManager.LoadScene("WinMenu");
    }
}
