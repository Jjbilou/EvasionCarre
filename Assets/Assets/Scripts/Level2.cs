using System.Collections;
using UnityEngine;

public class Level2 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.Init("Level2");
        StartCoroutine(Launch());
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

        // GameEvents.RotateBorders(30.0f, 2.0f);

        yield return new WaitForSeconds(2.0f);

        GameEvents.BorderLeftScale(2.0f, 2.0f);
        GameEvents.BorderRightScale(-2.0f, 2.0f);
        GameEvents.BorderTopScale(-2.0f, 2.0f);
        GameEvents.BorderBottomScale(2.0f, 2.0f);

        yield return new WaitForSeconds(2.0f);

        GameEvents.GameWon();
    }
}
