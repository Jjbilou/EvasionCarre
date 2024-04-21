using System.Collections;
using UnityEngine;
using TMPro;

public class LevelTuto : MonoBehaviour
{
    [SerializeField] GameObject canvas;

    TMP_Text text;

    public bool clear = false;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.Init();
        canvas.SetActive(true);
        text = canvas.GetComponentInChildren<TMP_Text>();
        GameObject.Find("Player").GetComponent<PlayerCollision>().level = StartCoroutine(Launch());
    }

    IEnumerator Launch()
    {
        GameObject bullet;
        GameObject laser;
        GameObject laser2;
        GameObject laser3;

        yield return new WaitForSeconds (1.0f);

        text.text = "Welcome to your new playground... Hell!";

        yield return new WaitForSeconds (5.0f);

        text.text = "You don't seem very skilled. I'm going to teach you how to play";

        yield return new WaitForSeconds (5.0f);

        text.text = "First, the balls, they kill you instantly so avoid touching them";
        bullet = GameEvents.CreateBullet(0.0f, 0.0f, 1.0f, 180.0f, 500.0f, 4);

        yield return new WaitForSeconds (7.0f);

        Destroy(bullet);
        text.text = "Some disappear after 1, 2 or 3 bounces";

        yield return new WaitForSeconds (2.0f);

        GameEvents.CreateBullet(0.0f, 0.0f, 1.0f, 180.0f, 500.0f, 3);

        yield return new WaitForSeconds (7.0f);

        text.text = "There are also lasers, same deal, if you touch them you die so don't be stupid and step back";
        laser = GameEvents.CreateLaser(GameEvents.GetMiddleX(), GameEvents.GetMiddleY(), 2.0f, 2.0f, 0.0f);
        GameEvents.MoveLaser(laser, 0.0f, -5.0f, 5.0f);

        yield return new WaitForSeconds (7.0f);

        text.text = "They can move in all directions and even rotate so be careful";
        GameEvents.MoveLaser(laser, 0.0f, 2.0f, 5.0f);

        yield return new WaitForSeconds (5.0f);

        GameEvents.RotateLaser(laser, 180.0f, 5.0f);

        yield return new WaitForSeconds (7.0f);

        Destroy(laser);
        text.text = "Move away from the edges, when they turn red you can't touch them anymore";

        yield return new WaitForSeconds (3.0f);

        GameEvents.EnableDeadlyBorders();

        yield return new WaitForSeconds (3.0f);

        text.text = "Come to the middle of the square, the edges can also shrink";

        yield return new WaitForSeconds (2.0f);
        
        GameEvents.DisableDeadlyBorders();
        GameEvents.CloseBorderAll(8.0f, 3.0f);

        yield return new WaitForSeconds (6f);

        text.text = "And expand";
        GameEvents.CloseBorderAll(-8.0f, 3.0f);

        yield return new WaitForSeconds (6.0f);

        text.text = "You can also be pulled towards one side. More or less strongly";
        GameEvents.PlayerAttraction(0.0f, 10.0f, 5.0f);
        
        yield return new WaitForSeconds (5.0f);

        GameEvents.PlayerAttraction(180.0f, 20.0f, 5.0f);

        yield return new WaitForSeconds (5.0f);

        text.text = "Your size can also change";
        GameEvents.PlayerScale(4.0f, 2.0f);

        yield return new WaitForSeconds (3.0f);

        GameEvents.PlayerScale(-4.0f, 2.0f);

        yield return new WaitForSeconds (3.0f);

        text.text = "In short, all this to say that you're not likely to survive here... Shall we do a little test?";

        yield return new WaitForSeconds (5.0f);

        text.text = "Good luck";

        yield return new WaitForSeconds (2.0f);

        text.enabled = false;
        clear = true;
        laser2 = GameEvents.CreateLaser(0.0f, 0.0f, 2.0f, 3.0f, 0.0f);
        laser3 = GameEvents.CreateLaser(0.0f, 0.0f, 2.0f, 3.0f, 90.0f);
        GameEvents.RotateLaser(laser2, 360.0f, 10.0f);
        GameEvents.RotateLaser(laser3, 360.0f, 10.0f);
        for (int i = 0; i < 20; i++)
            {
                GameEvents.CreateBullet(0.0f, 0.0f, 1.0f, 90.0f - i * 18.0f, 350.0f, 4);
                GameEvents.CreateBullet(0.0f, 0.0f, 1.0f, 90.0f + i * 18.0f, 350.0f, 4);
                yield return new WaitForSeconds(0.05f);
            }

        yield return new WaitForSeconds (10.0f);
    
        GameEvents.GameWon();
    }
}

