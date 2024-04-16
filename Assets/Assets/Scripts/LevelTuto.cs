using System.Collections;
using UnityEngine;
using TMPro;

public class LevelTuto : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject laser;
    [SerializeField] TMP_Text Txt1;
    [SerializeField] TMP_Text Txt2;
    [SerializeField] TMP_Text Txt3;
    [SerializeField] TMP_Text Txt4;
    [SerializeField] TMP_Text Txt5;
    [SerializeField] TMP_Text Txt6;
    [SerializeField] TMP_Text Txt7;
    [SerializeField] TMP_Text Txt8;
    [SerializeField] TMP_Text Txt9;
    [SerializeField] TMP_Text Txt10;
    [SerializeField] TMP_Text Txt11;
    [SerializeField] TMP_Text Txt12;
    [SerializeField] TMP_Text Txt13;

    public bool clear = false;


    // Start is called before the first frame update
    void Start()
    {
        GameEvents.Init("LevelTuto");
        Txt1.enabled = false;
        Txt2.enabled = false;
        Txt3.enabled = false;
        Txt4.enabled = false;
        Txt5.enabled = false;
        Txt6.enabled = false;
        Txt7.enabled = false;
        Txt8.enabled = false;
        Txt9.enabled = false;
        Txt10.enabled = false;
        Txt11.enabled = false;
        Txt12.enabled = false;
        Txt13.enabled = false;
        GameObject.Find("Player").GetComponent<PlayerCollision>().level = StartCoroutine(Launch());
    }

    IEnumerator Launch()
    {
        GameObject bullet;
        GameObject laser;
        GameObject laser2;
        GameObject laser3;

        yield return new WaitForSeconds (1.0f);

        Txt1.enabled = true;

        yield return new WaitForSeconds (5f);

        Txt1.enabled = false;
        Txt2.enabled = true;

        yield return new WaitForSeconds (5f);

        Txt2.enabled = false;
        Txt3.enabled = true;
        bullet = GameEvents.CreateBullet(0.0f, 0.0f, 1.0f, 180.0f, 10.0f, 4);

        yield return new WaitForSeconds (7f);

        Destroy(bullet);
        Txt3.enabled = false;
        Txt4.enabled = true;

        yield return new WaitForSeconds (2.0f);

        GameEvents.CreateBullet(0.0f, 0.0f, 1.0f, 180.0f, 10.0f, 3);

        yield return new WaitForSeconds (7f);

        Txt4.enabled = false;
        Txt5.enabled = true;
        laser = GameEvents.CreateLaser(GameEvents.GetMiddleX(), GameEvents.GetMiddleY(), 2.0f, 2.0f, 0.0f);
        GameEvents.MoveLaser(laser, 0, -5, 5);

        yield return new WaitForSeconds (7f);

        Txt5.enabled = false;
        Txt6.enabled = true;
        GameEvents.MoveLaser(laser, 0, 2, 5);

        yield return new WaitForSeconds (5f);

        GameEvents.RotateLaser(laser, 180.0f, 5f);

        yield return new WaitForSeconds (7f);

        Destroy(laser);
        Txt6.enabled = false;
        Txt7.enabled = true;

        yield return new WaitForSeconds (3f);

        GameEvents.EnableDeadlyBorders();

        yield return new WaitForSeconds (3f);

        Txt7.enabled = false;
        Txt8.enabled = true;

        yield return new WaitForSeconds (2.0f);
        
        GameEvents.DisableDeadlyBorders();
        GameEvents.BorderScaleLeft(-8f, 3);
        GameEvents.BorderScaleRight(-8f, 3);
        GameEvents.BorderScaleTop(-8f, 3);
        GameEvents.BorderScaleBottom(-8f, 3);

        yield return new WaitForSeconds (6f);

        Txt8.enabled = false;
        Txt9.enabled = true;
        GameEvents.BorderScaleLeft(8f, 3);
        GameEvents.BorderScaleRight(8f, 3);
        GameEvents.BorderScaleTop(8f, 3);
        GameEvents.BorderScaleBottom(8f, 3);

        yield return new WaitForSeconds (6f);

        Txt9.enabled = false;
        Txt10.enabled = true;
        GameEvents.PlayerAttraction(0.0f, 10.0f, 5f);
        
        yield return new WaitForSeconds (5f);

        GameEvents.PlayerAttraction(180.0f, 20.0f, 5f);

        yield return new WaitForSeconds (5f);

        Txt10.enabled = false;
        Txt11.enabled = true;
        GameEvents.PlayerScale(4f, 2.0f);

        yield return new WaitForSeconds (3f);

        GameEvents.PlayerScale(-4f, 2.0f);

        yield return new WaitForSeconds (3f);

        Txt11.enabled = false;
        Txt12.enabled = true;

        yield return new WaitForSeconds (5f);

        Txt12.enabled = false;
        Txt13.enabled = true;

        yield return new WaitForSeconds (2.0f);

        Txt13.enabled = false;
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

