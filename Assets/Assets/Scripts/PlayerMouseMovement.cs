using UnityEngine;

public class PlayerMouseMovement : MonoBehaviour
{
    [SerializeField] float speed;
    
    Rigidbody2D player;
    Vector2 ratio;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        Camera gameCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
        float cameraHeight = 2.0f * gameCamera.orthographicSize;
        float cameraWidth = cameraHeight * gameCamera.aspect;

        ratio = new Vector2(cameraWidth / Screen.width, cameraHeight / Screen.height); //ratio between camera size and pixel number
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = ((Vector2)Input.mousePosition - new Vector2(Screen.width / 2, Screen.height / 2)) * ratio;
        Vector2 playerPosition = (Vector2)transform.position;

        if (Vector2.Distance(mousePosition, playerPosition) > 0.1f)
        {
            Vector2 movement = new(mousePosition.x - playerPosition.x, mousePosition.y - playerPosition.y);
            movement.Normalize();

            player.velocity = speed * Time.deltaTime * movement;
        }
        else
        {
            player.velocity = Vector2.zero;
        }
    }
}
