using System.Collections;
using UnityEngine;

public class Level3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.Init();
        GameObject.Find("Player").GetComponent<PlayerCollision>().level = StartCoroutine(Launch());
    }

    IEnumerator Launch()
    {
        yield return new WaitForSeconds(2.0f);

        Transform laser;
        Transform laser2;
        Transform laser3;
        Transform laser4;
        Transform laser5;
        Transform laser6;
        Transform red1;
        Transform red2;
        Transform red3;
        Transform red4;
        Transform red5;
        Transform red6;

        laser = GameEvents.CreateLaser(-3.0f, 9.0f, 2.0f, 3.0f, 0.0f);
        GameEvents.MoveLaser(laser, 0.0f, -18.0f, 1.0f);

        yield return new WaitForSeconds(0.5f);

        laser2 = GameEvents.CreateLaser(-9.0f, -3.0f, 2.0f, 3.0f, 90.0f);
        GameEvents.MoveLaser(laser2, 18.0f, 0.0f, 1.0f);

        yield return new WaitForSeconds(0.5f);

        laser3 = GameEvents.CreateLaser(3.0f, -9.0f, 2.0f, 3.0f, 0.0f);
        GameEvents.MoveLaser(laser, 4.0f, 9.0f, 1.0f);
        GameEvents.MoveLaser(laser2, -9.0f, 2.0f, 1.0f);
        GameEvents.MoveLaser(laser3, 0.0f, 18.0f, 2.0f);

        yield return new WaitForSeconds(2.0f);

        laser4 = GameEvents.CreateLaser(0.0f, -9.0f, 2.0f, 3.0f, 0.0f);
        GameEvents.MoveLaser(laser, 8.0f, 0.0f, 1.0f);
        GameEvents.MoveLaser(laser4, -12.0f, 9.0f, 1.0f);

        yield return new WaitForSeconds(0.8f);

        GameEvents.MoveLaser(laser3, -3.0f, -9.0f, 1.0f);

        yield return new WaitForSeconds(1.0f);

        GameEvents.MoveLaser(laser, -9.0f, 0.0f, 1.0f);
        GameEvents.MoveLaser(laser2, 0.0f, 1.0f, 1.0f);
        GameEvents.MoveLaser(laser4, 12.0f, 0.0f, 1.0f);

        yield return new WaitForSeconds(1.0f);

        GameEvents.ScaleLaser(laser3, 0.0f, 1.0f, 1.0f);
        GameEvents.ScaleLaser(laser4, 0.0f, 1.0f, 1.0f);
        GameEvents.RotateLaser(laser3, 720.0f, 20.0f);
        GameEvents.RotateLaser(laser4, 720.0f, 20.0f);

        for (int i = 0; i < 2; i++)
        {
            GameEvents.MoveLaser(laser, 0.0f, 3.0f, 1.0f);

            yield return new WaitForSeconds(1.0f);

            GameEvents.MoveLaser(laser2, -3.0f, 0.0f, 1.0f);

            yield return new WaitForSeconds(1.0f);

            GameEvents.MoveLaser(laser, 0.0f, -6.0f, 1.0f);

            yield return new WaitForSeconds(1.5f);

            GameEvents.MoveLaser(laser2, 6.0f, 0.0f, 1.0f);

            yield return new WaitForSeconds(1.5f);
        }

        GameEvents.ScaleLaser(laser3, 0.0f, -1.0f, 1.0f);
        GameEvents.ScaleLaser(laser4, 0.0f, -1.0f, 1.0f);

        yield return new WaitForSeconds(1.0f);

        GameEvents.MoveLaser(laser, 0.0f, 0.0f, 1.0f);
        GameEvents.MoveLaser(laser2, 0.0f, 0.0f, 1.0f);
        GameEvents.RotateLaser(laser4, 90.0f, 1.0f);

        yield return new WaitForSeconds(1.0f);

        GameEvents.MoveLaser(laser, -18.0f, -6.0f, 2.0f);
        GameEvents.MoveLaser(laser2, -6.0f, -18.0f, 2.0f);
        GameEvents.MoveLaser(laser3, -18.0f, 0.0f, 2.0f);
        GameEvents.MoveLaser(laser4, 0.0f, -18.0f, 2.0f);
        laser5 = GameEvents.CreateLaser(-18.0f, 6.0f, 2.0f, 3.0f, 0.0f);
        laser6 = GameEvents.CreateLaser(6.0f, -18.0f, 2.0f, 3.0f, 90.0f);

        yield return new WaitForSeconds(2.0f);

        red1 = GameEvents.CreateRedLine(-18.0f, -6.0f, 0.0f);
        red2 = GameEvents.CreateRedLine(-6.0f, -18.0f, 90.0f);
        red3 = GameEvents.CreateRedLine(-18.0f, 0.0f, 0.0f);
        red4 = GameEvents.CreateRedLine(0.0f, -18.0f, 90.0f);
        red5 = GameEvents.CreateRedLine(-18.0f, 6.0f, 0.0f);
        red6 = GameEvents.CreateRedLine(6.0f, -18.0f, 90.0f);

        yield return new WaitForSeconds(0.2f);

        GameEvents.MoveRedLine(red1, 18.0f, 0.0f, 0.2f);

        yield return new WaitForSeconds(0.2f);

        GameEvents.MoveRedLine(red2, 0.0f, 18.0f, 0.2f);
        Destroy(red1.gameObject);

        yield return new WaitForSeconds(0.2f);

        GameEvents.MoveRedLine(red3, 18.0f, 0.0f, 0.2f);
        Destroy(red2.gameObject);

        yield return new WaitForSeconds(0.2f);

        GameEvents.MoveRedLine(red4, 0.0f, 18.0f, 0.2f);
        Destroy(red3.gameObject);

        yield return new WaitForSeconds(0.2f);

        GameEvents.MoveRedLine(red5, 18.0f, 0.0f, 0.2f);
        Destroy(red4.gameObject);

        yield return new WaitForSeconds(0.2f);

        GameEvents.MoveRedLine(red6, 0.0f, 18.0f, 0.2f);
        Destroy(red5.gameObject);

        yield return new WaitForSeconds(0.2f);

        Destroy(red6.gameObject);
        GameEvents.MoveLaser(laser, 18.0f, 0.0f, 0.2f);

        yield return new WaitForSeconds(0.2f);

        GameEvents.MoveLaser(laser2, 0.0f, 18.0f, 0.2f);

        yield return new WaitForSeconds(0.2f);

        GameEvents.MoveLaser(laser3, 18.0f, 0.0f, 0.2f);

        yield return new WaitForSeconds(0.2f);

        GameEvents.MoveLaser(laser4, 0.0f, 18.0f, 0.2f);

        yield return new WaitForSeconds(0.2f);

        GameEvents.MoveLaser(laser5, 18.0f, 0.0f, 0.2f);

        yield return new WaitForSeconds(0.2f);

        GameEvents.MoveLaser(laser6, 0.0f, 18.0f, 0.2f);

        yield return new WaitForSeconds(0.2f);

        GameEvents.EnableDeadlyBorders();
        GameEvents.CloseBorderLeft(16.0f, 2.0f);
        GameEvents.CloseBorderBottom(16.0f, 2.0f);

        yield return new WaitForSeconds(3.0f);

        GameEvents.DisableDeadlyBorders();

        yield return new WaitForSeconds(1.0f);

        GameEvents.GameWon();
    }
}

