using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float angle;
    public float speed;
    public int level;

    Rigidbody2D bullet;
    SpriteRenderer bulletRenderer;
    Vector3 movement;

    Color level1Color;
    Color level2Color;
    Color level3Color;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Collider2D>().enabled = true;
        GetComponent<Animator>().enabled = true;
        bullet = GetComponent<Rigidbody2D>();
        bulletRenderer = GetComponent<SpriteRenderer>();

        level1Color = new Color(0.25f, 0.25f, 0.25f);
        level2Color = new Color(0.5f, 0.5f, 0.5f);
        level3Color = new Color(0.75f, 0.75f, 0.75f);

        angle = Mathf.PI * angle / 180.0f;
        movement = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        switch (level)
        {
            case 1:
                bulletRenderer.color = level1Color;
                break;
            case 2:
                bulletRenderer.color = level2Color;
                break;
            case 3:
                bulletRenderer.color = level3Color;
                break;
            case 4:
                bulletRenderer.color = new Color(1, 1, 1);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        bullet.velocity = speed * Time.deltaTime * movement;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HorizontalBorder"))
        {
            BounceOrDestroy();

            movement = new Vector2(movement.x, -movement.y);
        }

        if (collision.gameObject.CompareTag("VerticalBorder"))
        {
            BounceOrDestroy();

            movement = new Vector2(-movement.x, movement.y);
        }
    }

    void BounceOrDestroy()
    {
        if (bulletRenderer.color == level1Color)
        {
            Destroy(gameObject);
        }
        else if (bulletRenderer.color == level2Color)
        {
            bulletRenderer.color = level1Color;
        }
        else if (bulletRenderer.color == level3Color)
        {
            bulletRenderer.color = level2Color;
        }
    }
}