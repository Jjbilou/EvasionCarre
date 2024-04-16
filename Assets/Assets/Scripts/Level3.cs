using System.Collections;
using UnityEngine;

public class Level3 : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject laser;
    [SerializeField]
    GameObject redLine;

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
        DOTween.defaultEaseType = Ease.Linear;
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
=======
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.Init("Level3");
        GameObject.Find("Player").GetComponent<PlayerCollision>().level = StartCoroutine(Launch());
>>>>>>> d1fccf2791d79c2dbb647e12db673fbe89f8c380
    }

    IEnumerator Launch()
    {
        yield return new WaitForSeconds (2.0f);

        GameObject laser;
        GameObject laser2;
        GameObject laser3;
        GameObject laser4;
        // GameObject laser5;
        // GameObject laser6;

        laser = GameEvents.CreateLaser(-3.0f, 9.0f, 2.0f, 3.0f, 0.0f);
        GameEvents.MoveLaser(laser,-3, -9, 1.0f);
        

        yield return new WaitForSeconds (0.5f);

        laser2 = GameEvents.CreateLaser(-9.0f, -3.0f, 2.0f, 3.0f, 90.0f);
        GameEvents.MoveLaser(laser2, 9.0f, -3.0f, 1.0f);

        yield return new WaitForSeconds (0.5f);

        laser3 = GameEvents.CreateLaser(3.0f, -9.0f, 2.0f, 3.0f, 0.0f);
        GameEvents.MoveLaser(laser3, 3.0f, 9.0f, 2.0f);
        GameEvents.MoveLaser(laser, 1.0f, 0.0f, 1.0f);   
        GameEvents.MoveLaser(laser2, 0.0f, -1.0f, 1.0f);

        yield return new WaitForSeconds (2.0f);

        laser4 = GameEvents.CreateLaser(0.0f, -9.0f, 2.0f, 3.0f, 0.0f);
        GameEvents.MoveLaser(laser4, -12.0f, 0.0f, 1.0f);
        GameEvents.MoveLaser(laser, 9.0f, 0.0f, 1.0f);
    
        yield return new WaitForSeconds (0.8f);

        GameEvents.MoveLaser(laser3, 0.0f, 0.0f, 1.0f);

        yield return new WaitForSeconds (1.0f);

        GameEvents.MoveLaser(laser, 0.0f, 0.0f, 1.0f);
        GameEvents.MoveLaser(laser2, 0.0f, 0.0f, 1.0f);
        GameEvents.MoveLaser(laser4, 0.0f, 0.0f, 1.0f);

        yield return new WaitForSeconds (1.0f);

<<<<<<< HEAD
        ScaleLaser(laser3, 0, 1, 1f);
        ScaleLaser(laser4, 0, 1, 1f);
        RotateLaser(laser3, 720, 10f);
        RotateLaser(laser4, 720, 10f);
=======
        GameEvents.ScaleLaser(laser3, 0.0f, 1.0f, 1.0f);
        GameEvents.ScaleLaser(laser4, 0.0f, 1.0f, 1.0f);
        GameEvents.RotateLaser(laser3, 720.0f, 20.0f);
        GameEvents.RotateLaser(laser4, 720.0f, 20.0f);
>>>>>>> d1fccf2791d79c2dbb647e12db673fbe89f8c380

        for (int i = 0; i < 2; i++)
        {
            GameEvents.MoveLaser(laser2, 0.0f, 3.0f, 1.0f);

            yield return new WaitForSeconds (1f);

            GameEvents.MoveLaser(laser, -3.0f, 0.0f, 1.0f);

            yield return new WaitForSeconds (1f);

            GameEvents.MoveLaser(laser2, 0.0f, -3.0f, 1.0f);

            yield return new WaitForSeconds (1.5f);

            GameEvents.MoveLaser(laser, 3.0f, 0.0f, 1.0f);

            yield return new WaitForSeconds (1.5f);
        }

<<<<<<< HEAD
        ScaleLaser(laser3, 0, -1, 1f);
        ScaleLaser(laser4, 0, -1, 1f);
        yield return new WaitForSeconds (1f);

        MoveLaser(laser, 0, 0, 1f);
        MoveLaser(laser, 0, 0, 1f);
        RotateLaser(laser4, 90, 1f);
=======
        yield return new WaitForSeconds (5.0f);

        /*laser5 = CreateLaser(-1.0f, 8.0f, 2.0f, 2.5f, 0.0f);
        MoveLaser(laser5, 0.0f, -9.0f, 4.0f);
        laser6 = CreateLaser(-1.0f, 8.0f, 2.0f, 2.5f, 0.0f);
        MoveLaser(laser6, 0.0f, -9.0f, 4.0f);*/
>>>>>>> d1fccf2791d79c2dbb647e12db673fbe89f8c380

        yield return new WaitForSeconds (1f);
    
        MoveLaser(laser, -18, -6, 2f);
        MoveLaser(laser2, -6, -18, 2f);
        MoveLaser(laser3, -18, 0, 2f);
        MoveLaser(laser4, 0, -18, 2f);
        laser5 = CreateLaser(-18, 6, 2f, 3f, 0f);
        laser6 = CreateLaser(6, -18, 2f, 3f, 90f);

        yield return new WaitForSeconds (2f);

<<<<<<< HEAD
        GameObject red1 = CreateRedLine(-18, -6, 0);
        GameObject red2 = CreateRedLine(-6, -18, 90);
        GameObject red3 = CreateRedLine(-18, -0, 0);
        GameObject red4 = CreateRedLine(0, -18, 90);
        GameObject red5 = CreateRedLine(-18, 6, 0);
        GameObject red6 = CreateRedLine(6, -18, 90);
=======
        yield return new WaitForSeconds (3.0f);
>>>>>>> d1fccf2791d79c2dbb647e12db673fbe89f8c380

        yield return new WaitForSeconds (0.2f);

        MoveRedLine(red1, 0, -6, 0.2f);

        yield return new WaitForSeconds (0.2f);
        
        MoveRedLine(red2, -6, 0, 0.2f);
        Destroy(red1);

        yield return new WaitForSeconds (0.2f);

        MoveRedLine(red3, 0, -0, 0.2f);
        Destroy(red2);

        yield return new WaitForSeconds (0.2f);

        MoveRedLine(red4, 0, 0, 0.2f);
        Destroy(red3);

        yield return new WaitForSeconds (0.2f);

        MoveRedLine(red5, 0, 6, 0.2f);
        Destroy(red4);

        yield return new WaitForSeconds (0.2f);

        MoveRedLine(red6, 6, 0, 0.2f);
        Destroy(red5);

        yield return new WaitForSeconds (0.2f);

        Destroy(red6);
        MoveLaser(laser, 0, -6, 0.2f);

        yield return new WaitForSeconds (0.2f);

        MoveLaser(laser2, -6, 0, 0.2f);  

        yield return new WaitForSeconds (0.2f);

        MoveLaser(laser3, 0, -0, 0.2f);

        yield return new WaitForSeconds (0.2f);

        MoveLaser(laser4, 0, 0, 0.2f);

        yield return new WaitForSeconds (0.2f);

        MoveLaser(laser5, 0, 6, 0.2f);

        yield return new WaitForSeconds (0.2f);

        MoveLaser(laser6, 6, 0, 0.2f);

        yield return new WaitForSeconds (0.2f);

        BorderLeftScale(-16, 2);
        BorderBottomScale(-16, 2);
        EnableDeadlyBorders();

        yield return new WaitForSeconds(3f);

        DisableDeadlyBorders();

        yield return new WaitForSeconds(1f);
        

<<<<<<< HEAD
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
        GameObject laserClone = Instantiate(laser, new Vector3(posX, posY, 1f), Quaternion.Euler(0f, 0f, angle - 90f));
        Laser cloneScript = laserClone.GetComponent<Laser>();
        
        laserClone.transform.localScale = new Vector3(laserWidth, laserHeight, 1f);
        cloneScript.enabled = true;

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

    void ScaleLaser(GameObject laser, float width, float height, float duration)
    {
        laser.transform.DOScale(new Vector3(laser.transform.localScale.x + width, laser.transform.localScale.y + height, 1f), duration);
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

    GameObject CreateRedLine(float posX, float posY, float angle)
    {
        GameObject redLineClone = Instantiate(redLine, new Vector3(posX, posY, 1f), Quaternion.Euler(0f, 0f, angle - 90f));        
        return redLineClone;
    }

    void MoveRedLine(GameObject redLine, float posX, float posY, float duration)
    {
        redLine.transform.DOMove(new Vector3(posX, posY, 1f), duration);
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
=======
        GameEvents.GameWon();
>>>>>>> d1fccf2791d79c2dbb647e12db673fbe89f8c380
    }
}

