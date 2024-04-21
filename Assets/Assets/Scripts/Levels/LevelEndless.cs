using System.Collections;
using UnityEngine;

public class LevelEndless : MonoBehaviour
{
    [SerializeField] GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.Init();
        canvas.SetActive(true);
        GameObject.Find("Player").GetComponent<PlayerCollision>().level = StartCoroutine(Launch());
    }

    IEnumerator Launch()
    {
        yield return new WaitForSeconds(2.0f);

        while (true)
        {
            switch (Random.Range(0, 3))
            {
                case 0:

                    GameEvents.EnableDeadlyBorders();

                    int occur0 = Random.Range(1, 6);
                    for (int j = 0; j < occur0; j++)
                    {
                        GameEvents.PlayerAttraction(0.0f, 6.0f, 1.0f);
                        int hole = Random.Range(-8, 8);
                        for (int i = -8; i < 9; i++)
                        {
                            if (i != hole && i != hole + 1)
                            {
                                GameEvents.CreateBullet(GameEvents.GetLeftX() + 1.0f, i, 1.0f, 0.0f, 350.0f, 1);
                            }
                        }

                        yield return new WaitForSeconds(1.0f);
                    }

                    yield return new WaitForSeconds(1.5f);

                    GameEvents.DisableDeadlyBorders();

                    break;
                case 1:

                    GameEvents.EnableDeadlyBorders();
                    float boxReduction = Random.Range(-6.0f, -1.0f);

                    GameEvents.BorderScaleLeft(boxReduction, 1.0f);
                    GameEvents.BorderScaleRight(boxReduction, 1.0f);
                    GameEvents.BorderScaleTop(boxReduction, 1.0f);
                    GameEvents.BorderScaleBottom(boxReduction, 1.0f);

                    yield return new WaitForSeconds(1.0f);

                    int occur1 = Random.Range(1, 4);
                    for (int i = 0; i < occur1; i++)
                    {
                        float movementX = Random.Range(3.0f, 5.0f) * (Random.value < 0.5 ? -1 : 1);
                        float movementY = Random.Range(3.0f, 5.0f) * (Random.value < 0.5 ? -1 : 1);

                        GameEvents.BorderScaleLeft(-movementX, 1.0f);
                        GameEvents.BorderScaleRight(movementX, 1.0f);
                        GameEvents.BorderScaleTop(movementY, 1.0f);
                        GameEvents.BorderScaleBottom(-movementY, 1.0f);

                        yield return new WaitForSeconds(1.0f);
                    }

                    GameEvents.DisableDeadlyBorders();
                    GameEvents.ResetBorders(1.0f);

                    yield return new WaitForSeconds(2.0f);

                    break;
                case 2:

                    for (int i = 0; i < 20; i++)
                    {
                        GameEvents.CreateBullet(0.0f, 0.0f, 1.0f, 90.0f - i * 18.0f, 350f, 3);
                        yield return new WaitForSeconds(0.25f);
                    }

                    GameObject laserClone;
                    switch (Random.Range(0, 3))
                    {
                        default:
                            GameEvents.CreateBullet(-8.0f, 8.0f, 1.0f, -30.0f, Random.Range(500.0f, 750.0f), 3);
                            laserClone = GameEvents.CreateLaser(GameEvents.GetRightX(), 0.0f, 3f, 4f, 90.0f);
                            break;

                        case 0:
                            GameEvents.CreateBullet(8.0f, 8.0f, 1.0f, -150.0f, Random.Range(10.0f, 750.0f), 3);
                            laserClone = GameEvents.CreateLaser(0.0f, GameEvents.GetTopY(), 3f, 4f, 0.0f);
                            break;

                        case 1:
                            GameEvents.CreateBullet(8.0f, -8.0f, 1.0f, 150.0f, Random.Range(10.0f, 750.0f), 3);
                            laserClone = GameEvents.CreateLaser(GameEvents.GetLeftX(), 0.0f, 3f, 4f, 90.0f);
                            break;

                        case 2:
                            GameEvents.CreateBullet(-8.0f, -8.0f, 1.0f, 30.0f, Random.Range(10.0f, 750.0f), 3);
                            laserClone = GameEvents.CreateLaser(0.0f, GameEvents.GetBottomY(), 3f, 4f, 0.0f);
                            break;
                    }

                    GameEvents.MoveLaser(laserClone, 0.0f, 0.0f, 3.0f);

                    yield return new WaitForSeconds(4.0f);

                    Destroy(laserClone);

                    break;
            }
        }
    }
}
