using System.Collections;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.Init();
        GameObject.Find("Player").GetComponent<PlayerCollision>().level = StartCoroutine(Launch());
    }

    IEnumerator Launch()
    {
        Transform[] lasers;
        Transform laserClone;
        Transform laserClone2;

        GameObject bullet;
        GameObject bullet2;
        GameObject bullet3;
        GameObject bullet4;

        yield return new WaitForSeconds(2.0f);

        laserClone = GameEvents.CreateLaser(GameEvents.GetLeftX(), GameEvents.GetTopY(), 3.0f, 5.7f, 0.0f);
        laserClone2 = GameEvents.CreateLaser(GameEvents.GetRightX(), GameEvents.GetTopY(), 3.0f, 5.7f, 0.0f);
        GameEvents.RotateLaser(laserClone, -90.0f, 0.5f);
        GameEvents.RotateLaser(laserClone2, 90.0f, 0.5f);

        yield return new WaitForSeconds(0.1f);

        GameEvents.PlayerAttraction(90.0f, 500.0f, 0.15f);

        yield return new WaitForSeconds(0.15f);

        GameEvents.CreateBullet(0.0f, 0.0f, 1.0f, -90.0f, 500.0f, 1);

        yield return new WaitForSeconds(0.25f);

        Destroy(laserClone.gameObject);
        Destroy(laserClone2.gameObject);

        bullet = GameEvents.CreateBullet(0.0f, 0.0f, 1.0f, 45.0f, 500.0f, 4);
        bullet2 = GameEvents.CreateBullet(0.0f, 0.0f, 1.0f, -45.0f, 500.0f, 4);
        bullet3 = GameEvents.CreateBullet(0.0f, 0.0f, 1.0f, 135.0f, 500.0f, 4);
        bullet4 = GameEvents.CreateBullet(0.0f, 0.0f, 1.0f, -135.0f, 500.0f, 4);

        yield return new WaitForSeconds(1.0f);

        GameEvents.CloseBorderTop(5.0f, 1.0f);
        GameEvents.CloseBorderLeft(2.0f, 0.5f);
        GameEvents.CloseBorderBottom(2.0f, 0.5f);

        yield return new WaitForSeconds(0.5f);

        GameEvents.PlayerScale(2.0f, 0.5f);

        yield return new WaitForSeconds(0.5f);

        laserClone = GameEvents.CreateLaser(GameEvents.GetMiddleX(), GameEvents.GetMiddleY(), 3.0f, 4.0f, 90.0f);
        GameEvents.RotateLaser(laserClone, -180.0f, 5.0f);

        yield return new WaitForSeconds(2.0f);

        GameEvents.PlayerScale(0.5f, 1.0f);

        yield return new WaitForSeconds(3.0f);

        Destroy(laserClone.gameObject);
        Destroy(bullet);
        Destroy(bullet2);
        Destroy(bullet3);
        Destroy(bullet4);
        GameEvents.CloseBorderTop(-5.0f, 0.5f);
        GameEvents.CloseBorderLeft(-2.0f, 0.5f);
        GameEvents.CloseBorderBottom(-2.0f, 0.5f);

        yield return new WaitForSeconds(1.0f); //10.5'

        GameEvents.EnableDeadlyBorders();
        GameEvents.PlayerAttraction(0.0f, 300.0f, 5.0f);

        for (int i = -8; i < 9; i++)
        {
            if (i != 6 && i != 7)
            {
                GameEvents.CreateBullet(GameEvents.GetLeftX() + 1.0f, i, 1.0f, 0.0f, 350.0f, 1);
            }
        }

        yield return new WaitForSeconds(1.0f);

        for (int i = -8; i < 9; i++)
        {
            if (i != 1 && i != 2)
            {
                GameEvents.CreateBullet(GameEvents.GetLeftX() + 1.0f, i, 1.0f, 0.0f, 350.0f, 1);
            }
        }

        yield return new WaitForSeconds(1.0f);

        for (int i = -8; i < 9; i++)
        {
            if (i != -4 && i != -3)
            {
                GameEvents.CreateBullet(GameEvents.GetLeftX() + 1.0f, i, 1.0f, 0.0f, 350.0f, 1);
            }
        }

        yield return new WaitForSeconds(1.0f);

        for (int i = -8; i < 9; i++)
        {
            if (i != 7 && i != 8)
            {
                GameEvents.CreateBullet(GameEvents.GetLeftX() + 1.0f, i, 1.0f, 0.0f, 350.0f, 1);
            }
        }

        yield return new WaitForSeconds(3.0f);

        GameEvents.CloseBorderAll(5.0f, 1.0f);

        yield return new WaitForSeconds(1.0f);

        GameEvents.MoveBorders(5.0f, 5.0f, 2.0f);

        yield return new WaitForSeconds(2.0f);

        GameEvents.MoveBorders(-10.0f, -10.0f, 2.0f);

        yield return new WaitForSeconds(2.0f); //21.5'

        GameEvents.ResetBorders(2.0f);

        yield return new WaitForSeconds(2.0f);

        GameEvents.DisableDeadlyBorders();
        for (int i = 0; i < 20; i++)
        {
            GameEvents.CreateBullet(0.0f, 0.0f, 1.0f, 90.0f - i * 18.0f, 350.0f, 3);
            yield return new WaitForSeconds(0.25f);
        }

        GameEvents.CreateBullet(-8.0f, 8.0f, 1.0f, -30.0f, 550.0f, 3);
        laserClone = GameEvents.CreateLaser(9.0f, 0.0f, 3.0f, 4.0f, 90.0f);
        GameEvents.MoveLaser(laserClone, -9.0f, 0.0f, 3.0f);

        yield return new WaitForSeconds(4.0f); //32.5'

        Destroy(laserClone.gameObject);

        yield return new WaitForSeconds(3.0f);

        lasers = new Transform[12];
        for (int i = 0; i < 6; i++)
        {
            lasers[i] = GameEvents.CreateLaser(0.0f, 0.0f, 3.0f, 4.0f, 180.0f - i * 30);
            GameEvents.ScaleLaser(lasers[i], 0.0f, -8.0f, 2.5f);
            GameEvents.RotateLaser(lasers[i], 180.0f, 5.0f);
        }

        yield return new WaitForSeconds(2.5f);

        for (int i = 0; i < 6; i++)
        {
            GameEvents.ScaleLaser(lasers[i], 0.0f, 8.0f, 2.5f);
        }

        yield return new WaitForSeconds(3.0f); // 41'

        for (int i = 0; i < 6; i++)
        {
            Destroy(lasers[i].gameObject);
        }

        yield return new WaitForSeconds(2.0f);

        GameEvents.GameWon();
    }
}
