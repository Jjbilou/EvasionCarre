using System.Collections;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.Init();
        GameObject.Find("Player").GetComponent<PlayerCollision>().level = StartCoroutine(Launch());
    }

    IEnumerator Launch()
    {
        Transform laserClone;

        GameEvents.MoveBorders(3.0f, 0.0f, 2.0f);
        GameEvents.RotateBorders(45.0f, 2.0f);

        yield return new WaitForSeconds(3.0f);

        GameEvents.MoveBorders(-3.0f, 3.0f, 2.0f);
        GameEvents.RotateBorders(45.0f, 2.0f);

        yield return new WaitForSeconds(2.0f);

        GameEvents.ResetBorders(1.0f);

        yield return new WaitForSeconds(2.0f);

        GameEvents.PlayerAttraction(90.0f, 500.0f, 2.0f);
        GameEvents.PlayerScale(2.0f, 1.0f);

        yield return new WaitForSeconds(2.0f);

        GameEvents.PlayerScale(0.5f, 1.0f);

        yield return new WaitForSeconds(2.0f);

        GameEvents.EnableDeadlyBorders();

        yield return new WaitForSeconds(1.0f);

        laserClone = GameEvents.CreateLaser(-9.0f, 9.0f, 3.0f, 5.3f, 0.0f);
        GameEvents.RotateLaser(laserClone, 180.0f, 2.0f);
        GameEvents.MoveLaser(laserClone, 18.0f, 0.0f, 2.0f);

        yield return new WaitForSeconds(2.0f);

        Destroy(laserClone.gameObject);
        GameEvents.DisableDeadlyBorders();
        GameEvents.CreateBullet(7.0f, 0.0f, 1.0f, 135.0f, 750.0f, 3);
        GameEvents.CreateBullet(7.0f, 0.0f, 1.0f, -135.0f, 750.0f, 2);
        laserClone = GameEvents.CreateLaser(GameEvents.GetMiddleX(), GameEvents.GetMiddleY(), 3.0f, 3.0f, 0.0f);
        GameEvents.RotateLaser(laserClone, -900.0f, 5.0f);

        yield return new WaitForSeconds(2.0f);

        GameEvents.CloseBorderRight(2.0f, 1.0f);
        GameEvents.CloseBorderTop(2.0f, 1.0f);
        GameEvents.MoveLaser(laserClone, -1.0f, -1.0f, 2.0f);

        yield return new WaitForSeconds(3.0f);

        GameEvents.GameWon();
    }
}
