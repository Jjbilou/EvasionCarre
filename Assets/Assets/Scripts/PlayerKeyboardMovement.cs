using UnityEngine;

public class PlayerKeyboardMovement : MonoBehaviour
{
    [SerializeField] float speed;

    Rigidbody2D player;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movement.Normalize();

        player.velocity = speed * Time.deltaTime * movement;
    }
}
