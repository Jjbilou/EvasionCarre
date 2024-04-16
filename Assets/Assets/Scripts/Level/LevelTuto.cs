using System.Collections;
using UnityEngine;
using TMPro;

public class LevelTuto : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject laser;
    [SerializeField] TMP_Text text;
    public bool clear = false;


    // Start is called before the first frame update
    void Start()
    {
        GameEvents.Init("LevelTuto");
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

        yield return new WaitForSeconds (5f);

        text.text = "You don't seem very skilled. I'm going to teach you how to play";

        yield return new WaitForSeconds (5f);

        text.text = "First, the balls, they kill you instantly so avoid touching them";
        bullet = GameEvents.CreateBullet(0.0f, 0.0f, 1.0f, 180.0f, 10.0f, 4);

        yield return new WaitForSeconds (7f);

        Destroy(bullet);
        text.text = "Some disappear after 1, 2 or 3 bounces";

        yield return new WaitForSeconds (2.0f);

        GameEvents.CreateBullet(0.0f, 0.0f, 1.0f, 180.0f, 10.0f, 3);

        yield return new WaitForSeconds (7f);

        text.text = "There are also lasers, same deal, if you touch them ou die so don't be stupid and step back";
        laser = GameEvents.CreateLaser(GameEvents.GetMiddleX(), GameEvents.GetMiddleY(), 2.0f, 2.0f, 0.0f);
        GameEvents.MoveLaser(laser, 0, -5, 5);

        yield return new WaitForSeconds (7f);

        text.text = "they can move in all directions and even rotate so be careful";
        GameEvents.MoveLaser(laser, 0, 2, 5);

        yield return new WaitForSeconds (5f);

        GameEvents.RotateLaser(laser, 180.0f, 5f);

        yield return new WaitForSeconds (7f);

        Destroy(laser);
        text.text = "Move away from the edges, when they turn red you can't touch them anymore";

        yield return new WaitForSeconds (3f);

        GameEvents.EnableDeadlyBorders();

        yield return new WaitForSeconds (3f);

        text.text = "Come to the middle of the square, the edges can also shrink";

        yield return new WaitForSeconds (2.0f);
        
        GameEvents.DisableDeadlyBorders();
        GameEvents.BorderScaleLeft(-8f, 3);
        GameEvents.BorderScaleRight(-8f, 3);
        GameEvents.BorderScaleTop(-8f, 3);
        GameEvents.BorderScaleBottom(-8f, 3);

        yield return new WaitForSeconds (6f);

        text.text = "And expand";
        GameEvents.BorderScaleLeft(8f, 3);
        GameEvents.BorderScaleRight(8f, 3);
        GameEvents.BorderScaleTop(8f, 3);
        GameEvents.BorderScaleBottom(8f, 3);

        yield return new WaitForSeconds (6f);

        text.text = "You can also be pulled towards one side. Mode or less strongly";
        GameEvents.PlayerAttraction(0.0f, 10.0f, 5f);
        
        yield return new WaitForSeconds (5f);

        GameEvents.PlayerAttraction(180.0f, 20.0f, 5f);

        yield return new WaitForSeconds (5f);

        text.text = "Your size can also change";
        GameEvents.PlayerScale(4f, 2.0f);

        yield return new WaitForSeconds (3f);

        GameEvents.PlayerScale(-4f, 2.0f);

        yield return new WaitForSeconds (3f);

        text.text = "In short, all this to say that you're not likely to survive here... Shall we do a little test ?";

        yield return new WaitForSeconds (5f);

        text.text = "Good luck";

        yield return new WaitForSeconds (2.0f);

        text.enabled = false;
        clear = true;
        laser2 = GameEvents.CreateLaser(0, 0, 2.0f, 3f, 0.0f);
        laser3 = GameEvents.CreateLaser(0, 0, 2.0f, 3f, 90.0f);
        GameEvents.RotateLaser(laser2, 360, 10);
        GameEvents.RotateLaser(laser3, 360, 10);
        for (int i = 0; i < 20; i++)
            {
                GameEvents.CreateBullet(0.0f, 0.0f, 1.0f, 90.0f - i * 18f, 7f, 4);
                GameEvents.CreateBullet(0.0f, 0.0f, 1.0f, 90.0f + i * 18f, 7f, 4);
                yield return new WaitForSeconds(0.05f);
            }

        yield return new WaitForSeconds (10.0f);
    
        GameEvents.GameWon();
    }
}

