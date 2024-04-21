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
        yield return new WaitForSeconds (2.0f);

        GameObject laser;
        GameObject laser2;
        GameObject laser3;
        GameObject laser4;
        GameObject laser5;
        GameObject laser6;

        laser = GameEvents.CreateLaser(-3.0f, 9.0f, 2.0f, 3.0f, 0.0f);
        GameEvents.MoveLaser(laser,-3.0f, -9.0f, 1.0f);
        

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

        GameEvents.ScaleLaser(laser3, 0.0f, 1.0f, 1.0f);
        GameEvents.ScaleLaser(laser4, 0.0f, 1.0f, 1.0f);
        GameEvents.RotateLaser(laser3, 720.0f, 20.0f);
        GameEvents.RotateLaser(laser4, 720.0f, 20.0f);

        for (int i = 0; i < 2; i++)
        {
            GameEvents.MoveLaser(laser2, 0.0f, 3.0f, 1.0f);

            yield return new WaitForSeconds (1.0f);

            GameEvents.MoveLaser(laser, -3.0f, 0.0f, 1.0f);

            yield return new WaitForSeconds (1.0f);

            GameEvents.MoveLaser(laser2, 0.0f, -3.0f, 1.0f);

            yield return new WaitForSeconds (1.5f);

            GameEvents.MoveLaser(laser, 3.0f, 0.0f, 1.0f);

            yield return new WaitForSeconds (1.5f);
        }

        GameEvents.ScaleLaser(laser3, 0.0f, -1.0f, 1.0f);
        GameEvents.ScaleLaser(laser4, 0.0f, -1.0f, 1.0f);

        yield return new WaitForSeconds (1.0f);

        GameEvents.MoveLaser(laser, 0.0f, 0.0f, 1.0f);
        GameEvents.MoveLaser(laser, 0.0f, 0.0f, 1.0f);
        GameEvents.RotateLaser(laser4, 90.0f, 1.0f);

        yield return new WaitForSeconds (1.0f);
    
        GameEvents.MoveLaser(laser, -18.0f, -6.0f, 2.0f);
        GameEvents.MoveLaser(laser2, -6.0f, -18.0f, 2.0f);
        GameEvents.MoveLaser(laser3, -18.0f, 0.0f, 2.0f);
        GameEvents.MoveLaser(laser4, 0.0f, -18.0f, 2.0f);
        laser5 = GameEvents.CreateLaser(-18.0f, 6.0f, 2.0f, 3.0f, 0.0f);
        laser6 = GameEvents.CreateLaser(6.0f, -18.0f, 2.0f, 3.0f, 90.0f);

        yield return new WaitForSeconds (2.0f);

        GameObject red1 = GameEvents.CreateRedLine(-18.0f, -6.0f, 0.0f);
        GameObject red2 = GameEvents.CreateRedLine(-6.0f, -18.0f, 90.0f);
        GameObject red3 = GameEvents.CreateRedLine(-18.0f, -0.0f, 0.0f);
        GameObject red4 = GameEvents.CreateRedLine(0.0f, -18.0f, 90.0f);
        GameObject red5 = GameEvents.CreateRedLine(-18.0f, 6.0f, 0.0f);
        GameObject red6 = GameEvents.CreateRedLine(6.0f, -18.0f, 90.0f);

        yield return new WaitForSeconds (0.2f);

        GameEvents.MoveRedLine(red1, 0.0f, -6.0f, 0.2f);

        yield return new WaitForSeconds (0.2f);
        
        GameEvents.MoveRedLine(red2, -6.0f, 0.0f, 0.2f);
        Destroy(red1);

        yield return new WaitForSeconds (0.2f);

        GameEvents.MoveRedLine(red3, 0.0f, -0.0f, 0.2f);
        Destroy(red2);

        yield return new WaitForSeconds (0.2f);

        GameEvents.MoveRedLine(red4, 0.0f, 0.0f, 0.2f);
        Destroy(red3);

        yield return new WaitForSeconds (0.2f);

        GameEvents.MoveRedLine(red5, 0.0f, 6.0f, 0.2f);
        Destroy(red4);

        yield return new WaitForSeconds (0.2f);

        GameEvents.MoveRedLine(red6, 6.0f, 0.0f, 0.2f);
        Destroy(red5);

        yield return new WaitForSeconds (0.2f);

        Destroy(red6);
        GameEvents.MoveLaser(laser, 0.0f, -6.0f, 0.2f);

        yield return new WaitForSeconds (0.2f);

        GameEvents.MoveLaser(laser2, -6.0f, 0.0f, 0.2f);  

        yield return new WaitForSeconds (0.2f);

        GameEvents.MoveLaser(laser3, 0.0f, -0.0f, 0.2f);

        yield return new WaitForSeconds (0.2f);

        GameEvents.MoveLaser(laser4, 0.0f, 0.0f, 0.2f);

        yield return new WaitForSeconds (0.2f);

        GameEvents.MoveLaser(laser5, 0.0f, 6.0f, 0.2f);

        yield return new WaitForSeconds (0.2f);

        GameEvents.MoveLaser(laser6, 6.0f, 0.0f, 0.2f);

        yield return new WaitForSeconds (0.2f);

        GameEvents.CloseBorderLeft(16.0f, 2.0f);
        GameEvents.CloseBorderBottom(16.0f, 2.0f);
        GameEvents.EnableDeadlyBorders();

        yield return new WaitForSeconds(3.0f);

        GameEvents.DisableDeadlyBorders();

        yield return new WaitForSeconds(1.0f);
        
        GameEvents.GameWon();
    }
}

