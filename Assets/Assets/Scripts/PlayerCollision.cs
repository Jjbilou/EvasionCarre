using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] ParticleSystem dieParticleSystem;

    Rigidbody2D player;
    AudioSource deathSound;
    PlayerMouseMovement mouseScript;
    PlayerKeyboardMovement keyboardScript;
    Timer timer;

    public Coroutine level;
    public float attractingTime;
    public Vector2 attractMovement;

    bool isColliding;
    GameObject collidingObject;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
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

    void LateUpdate()
    {
        if (attractingTime > 0.0f)
        {
            player.velocity += attractMovement * Time.deltaTime;
            attractingTime -= Time.deltaTime;
        }

        if (isColliding)
        {
            if (collidingObject.CompareTag("Danger"))
        {
            GameLost();
        }

        if (collidingObject.CompareTag("HorizontalBorder") || collidingObject.CompareTag("VerticalBorder"))
        {
            if (collidingObject.transform.parent.CompareTag("Danger"))
            {
                GameLost();
            }
        }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isColliding = true;
        collidingObject = collision.gameObject;
    }

    void OnCollisionExit2D()
    {
        isColliding = false;
    }

    void GameLost()
    {
        attractingTime = 0.0f;
        player.velocity = Vector2.zero;
        player.angularVelocity = 0.0f;
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

        if (PlayerPrefs.GetString("level") == "LevelTuto")
        {
            if (GameObject.Find("Level").GetComponent<LevelTuto>().clear)
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
