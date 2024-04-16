using System.Collections;
using UnityEngine;

public class Level3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.Init("Level3");
        GameObject.Find("Player").GetComponent<PlayerCollision>().level = StartCoroutine(Launch());
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

        GameEvents.ScaleLaser(laser3, 0.0f, 1.0f, 1.0f);
        GameEvents.ScaleLaser(laser4, 0.0f, 1.0f, 1.0f);
        GameEvents.RotateLaser(laser3, 720.0f, 20.0f);
        GameEvents.RotateLaser(laser4, 720.0f, 20.0f);

        for (int i = 0; i < 2; i++)
        {
            GameEvents.MoveLaser(laser2, 0.0f, 3.0f, 1.0f);

            yield return new WaitForSeconds (1.5f);

            GameEvents.MoveLaser(laser, -3.0f, 0.0f, 1.0f);

            yield return new WaitForSeconds (1.5f);

            GameEvents.MoveLaser(laser2, 0.0f, -3.0f, 1.0f);

            yield return new WaitForSeconds (1.5f);

            GameEvents.MoveLaser(laser, 3.0f, 0.0f, 1.0f);

            yield return new WaitForSeconds (1.5f);
        }

        yield return new WaitForSeconds (5.0f);

        /*laser5 = CreateLaser(-1.0f, 8.0f, 2.0f, 2.5f, 0.0f);
        MoveLaser(laser5, 0.0f, -9.0f, 4.0f);
        laser6 = CreateLaser(-1.0f, 8.0f, 2.0f, 2.5f, 0.0f);
        MoveLaser(laser6, 0.0f, -9.0f, 4.0f);*/



        yield return new WaitForSeconds (3.0f);


        GameEvents.GameWon();
    }
}

