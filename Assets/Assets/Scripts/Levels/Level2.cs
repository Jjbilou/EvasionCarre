using System.Collections;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.Init("Level2");
        GameObject.Find("Player").GetComponent<PlayerCollision>().level = StartCoroutine(Launch());
    }

    IEnumerator Launch()
    {
        GameObject[] lasers;
        GameObject laserClone;
        GameObject laserClone2;

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

        Destroy(laserClone);
        Destroy(laserClone2);

        bullet = GameEvents.CreateBullet(0.0f, 0.0f, 1.0f, 45.0f, 500.0f, 4);
        bullet2 = GameEvents.CreateBullet(0.0f, 0.0f, 1.0f, -45.0f, 500.0f, 4);
        bullet3 = GameEvents.CreateBullet(0.0f, 0.0f, 1.0f, 135.0f, 500.0f, 4);
        bullet4 = GameEvents.CreateBullet(0.0f, 0.0f, 1.0f, -135.0f, 500.0f, 4);

        yield return new WaitForSeconds(1.0f);

        GameEvents.BorderScaleTop(-5, 1.0f);
        GameEvents.BorderScaleLeft(-2.0f, 0.5f);
        GameEvents.BorderScaleBottom(-2.0f, 0.5f);

        yield return new WaitForSeconds(0.5f);

        GameEvents.PlayerScale(1.0f, 0.5f);

        yield return new WaitForSeconds(0.5f);

        laserClone = GameEvents.CreateLaser(GameEvents.GetMiddleX(), GameEvents.GetMiddleY(), 3.0f, 4.0f, 90.0f);
        GameEvents.RotateLaser(laserClone, -180.0f, 5.0f);

        yield return new WaitForSeconds(2.0f);

        GameEvents.PlayerScale(-1.0f, 1.0f);

        yield return new WaitForSeconds(3.0f);

        Destroy(laserClone);
        Destroy(bullet);
        Destroy(bullet2);
        Destroy(bullet3);
        Destroy(bullet4);
        GameEvents.BorderScaleTop(5, 0.5f);
        GameEvents.BorderScaleLeft(2.0f, 0.5f);
        GameEvents.BorderScaleBottom(2.0f, 0.5f);

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

        yield return new WaitForSeconds(2.0f);

        GameEvents.BorderScaleLeft(-5.0f, 1.0f);
        GameEvents.BorderScaleRight(-5.0f, 1.0f);
        GameEvents.BorderScaleTop(-5.0f, 1.0f);
        GameEvents.BorderScaleBottom(-5.0f, 1.0f);

        yield return new WaitForSeconds(1.0f);

        GameEvents.BorderScaleLeft(-5.0f, 2.0f);
        GameEvents.BorderScaleRight(5.0f, 2.0f);
        GameEvents.BorderScaleTop(5.0f, 2.0f);
        GameEvents.BorderScaleBottom(-5.0f, 2.0f);

        yield return new WaitForSeconds(2.0f);

        GameEvents.BorderScaleLeft(10.0f, 2.0f);
        GameEvents.BorderScaleRight(-10.0f, 2.0f);
        GameEvents.BorderScaleTop(-10.0f, 2.0f);
        GameEvents.BorderScaleBottom(10.0f, 2.0f);

        yield return new WaitForSeconds(2.0f); //20.5'

        GameEvents.BorderScaleRight(10.0f, 2.0f);
        GameEvents.BorderScaleTop(10.0f, 2.0f);

        yield return new WaitForSeconds(2.0f);

        GameEvents.DisableDeadlyBorders();
        for (int i = 0; i < 20; i++)
        {
            GameEvents.CreateBullet(0.0f, 0.0f, 1.0f, 90.0f - i * 18.0f, 350.0f, 3);
            yield return new WaitForSeconds(0.25f);
        }

        GameEvents.CreateBullet(-8.0f, 8.0f, 1.0f, -30.0f, 550.0f, 3);
        laserClone = GameEvents.CreateLaser(GameEvents.GetRightX(), 0.0f, 3.0f, 4.0f, 90.0f);
        GameEvents.MoveLaser(laserClone, 0.0f, 0.0f, 3.0f);

        yield return new WaitForSeconds(4.0f); //31.5'

        Destroy(laserClone);

        yield return new WaitForSeconds(3.0f);

        lasers = new GameObject[12];
        for (int i = 0; i < 12; i++)
        {
            lasers[i] = GameEvents.CreateLaser(0.0f, 0.0f, 3.0f, 4.0f, 180.0f - i * 36);
            GameEvents.ScaleLaser(lasers[i], 0.0f, -8.0f, 2.5f);
            GameEvents.RotateLaser(lasers[i], 180.0f, 5.0f);
        }

        yield return new WaitForSeconds(2.5f);

        for (int i = 0; i < 12; i++)
        {
            GameEvents.ScaleLaser(lasers[i], 0.0f, 8.0f, 2.5f);
        }

        yield return new WaitForSeconds(3.0f);

        for (int i = 0; i < 12; i++)
        {
            Destroy(lasers[i]);
        }

        yield return new WaitForSeconds(2.0f);

        GameEvents.GameWon();
    }
}