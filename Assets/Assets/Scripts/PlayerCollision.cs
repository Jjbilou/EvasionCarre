using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] ParticleSystem dieParticleSystem;

    AudioSource deathSound;
    PlayerMouseMovement mouseScript;
    PlayerKeyboardMovement keyboardScript;
    Timer timer;

    public Coroutine level;
    public float attractingTime;
    public Vector3 attractMovement;

    // Start is called before the first frame update
    void Start()
    {
        deathSound = GetComponent<AudioSource>();
        mouseScript = GetComponent<PlayerMouseMovement>();
        keyboardScript = GetComponent<PlayerKeyboardMovement>();
        
        if (!PlayerPrefs.HasKey("movement"))
        {
            PlayerPrefs.SetString("movement", "mouse");
        }

        if (PlayerPrefs.GetString("movement") == "mouse")
        {
            mouseScript.enabled = true;
            keyboardScript.enabled = false;
        }
        else
        {
            mouseScript.enabled = false;
            keyboardScript.enabled = true;
        }

        if (SceneManager.GetActiveScene().name == "LevelEndless")
        {
            timer = GameObject.Find("TimerValue").GetComponent<Timer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (attractingTime > 0.0f)
        {
            transform.position += attractMovement * Time.deltaTime;
            attractingTime -= Time.deltaTime;
        }
    }

    // void LateUpdate()
    // {
    //     Vector3 playerPosition = transform.position;
    //     float maxX = borderRight.transform.transform.position.x - borderRight.transform.localScale.x / 2.0f - transform.localScale.x / 2.0f + 0.05f;
    //     float minX = borderLeft.transform.transform.position.x + borderLeft.transform.localScale.x / 2.0f + transform.localScale.x / 2.0f - 0.05f;
    //     float maxY = borderTop.transform.transform.position.y - borderTop.transform.localScale.y / 2.0f - transform.localScale.y / 2.0f + 0.05f;
    //     float minyY = borderBottom.transform.transform.position.y + borderBottom.transform.localScale.y / 2.0f + transform.localScale.y / 2.0f - 0.05f;

    //     if (playerPosition.x > maxX)
    //     {
    //         transform.position = new Vector3(maxX, transform.transform.position.y, 1.0f);
    //     }
    //     if (playerPosition.x < minX)
    //     {
    //         transform.position = new Vector3(minX, transform.transform.position.y, 1.0f);
    //     }
    //     if (playerPosition.y > maxY)
    //     {
    //         transform.position = new Vector3(transform.transform.position.x, maxY, 1.0f);
    //     }
    //     if (playerPosition.y < minyY)
    //     {
    //         transform.position = new Vector3(transform.transform.position.x, minyY, 1.0f);
    //     }
    // }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Danger"))
        {
            GameLost();
        }

        if (collision.CompareTag("HorizontalBorder") || collision.CompareTag("VerticalBorder"))
        {
            if (collision.transform.parent.CompareTag("Danger"))
            {
                GameLost();
            }
            else
            {
                float angle = collision.transform.eulerAngles.z * Mathf.PI / 180.0f;
                float force = 0.3f;

                switch (collision.name)
                {
                    case "Left":
                        transform.position += new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0.0f) * force;
                        break;
                    case "Right":
                        transform.position -= new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0.0f) * force;
                        break;
                    case "Top":
                        transform.position -= new Vector3(-Mathf.Sin(angle), Mathf.Cos(angle), 0.0f) * force;
                        break;
                    case "Bottom":
                        transform.position += new Vector3(-Mathf.Sin(angle), Mathf.Cos(angle), 0.0f) * force;
                        break;
                }
            }
        }
    }

    void GameLost()
    {
        attractingTime = 0.0f;
        StopCoroutine(level);
        DOTween.KillAll();
        if (SceneManager.GetActiveScene().name == "LevelEndless")
        {
            timer.active = false;
        }
        StartCoroutine(DeathAnimation());
    }

    IEnumerator DeathAnimation()
    {
        dieParticleSystem.Play();
        deathSound.Play();
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        keyboardScript.enabled = false;
        mouseScript.enabled = false;

        yield return new WaitForSeconds(2.0f);

        if (SceneManager.GetActiveScene().name == "LevelTuto")
        {
            if (GameObject.Find("Borders").GetComponent<LevelTuto>().clear)
            {
                SceneManager.LoadScene("TutoWin");
            }
            else
            {
                SceneManager.LoadScene("TutoLose");
            }
        }
        else
        {
            SceneManager.LoadScene("LoseMenu");
        }
    }
}
