using System.Collections;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.Init("Level1");
        GameObject.Find("Player").GetComponent<PlayerCollision>().level = StartCoroutine(Launch());
    }

    IEnumerator Launch()
    {
        GameObject laserClone;

        yield return new WaitForSeconds(2.0f);

        GameEvents.PlayerAttraction(90.0f, 10.0f, 2.0f);
        GameEvents.PlayerScale(1.0f, 1.0f);

        yield return new WaitForSeconds(2.0f);

        GameEvents.PlayerScale(-1.0f, 1.0f);

        yield return new WaitForSeconds(2.0f);

        GameEvents.EnableDeadlyBorders();

        yield return new WaitForSeconds(1.0f);

        laserClone = GameEvents.CreateLaser(GameEvents.GetLeftX(), GameEvents.GetTopY(), 3.0f, 5.3f, 0.0f);
        GameEvents.RotateLaser(laserClone, 180.0f, 2.0f);
        GameEvents.MoveLaser(laserClone, GameEvents.GetRightX(), GameEvents.GetTopY(), 2.0f);

        yield return new WaitForSeconds(2.0f);

        Destroy(laserClone);
        GameEvents.DisableDeadlyBorders();
        GameEvents.CreateBullet(7.0f, 0.0f, 1.0f, 135.0f, 750.0f, 3);
        GameEvents.CreateBullet(7.0f, 0.0f, 1.0f, -135.0f, 750.0f, 2);
        laserClone = GameEvents.CreateLaser(GameEvents.GetMiddleX(), GameEvents.GetMiddleY(), 3.0f, 3.0f, 0.0f);
        GameEvents.RotateLaser(laserClone, -900.0f, 5.0f);

        yield return new WaitForSeconds(2.0f);

        GameEvents.BorderScaleRight(-2.0f, 1.0f);
        GameEvents.BorderScaleTop(-2.0f, 1.0f);
        GameEvents.MoveLaser(laserClone, laserClone.transform.position.x - 1.0f, laserClone.transform.position.y - 1.0f, 2.0f);

        yield return new WaitForSeconds(3.0f);

        GameEvents.GameWon();
    }
}
