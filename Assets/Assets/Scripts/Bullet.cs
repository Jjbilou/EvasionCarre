using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float angle;
    public float speed;
    public int level;


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
        bulletRenderer = GetComponent<SpriteRenderer>();
        bulletRenderer.enabled = true;

        level1Color = new Color(0.25f, 0.25f, 0.25f);
        level2Color = new Color(0.5f, 0.5f, 0.5f);
        level3Color = new Color(0.75f, 0.75f, 0.75f);

        angle = Mathf.PI * angle / 180.0f;
        movement = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0.0f);

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
        transform.position += speed * Time.deltaTime * movement;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HorizontalBorder")
        {
            BounceOrDestroy();

            movement = new Vector3(movement.x, movement.y * -1.0f, 0.0f);
        }

        if (collision.tag == "VerticalBorder")
        {
            BounceOrDestroy();

            movement = new Vector3(movement.x * -1.0f, movement.y, 0.0f);
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