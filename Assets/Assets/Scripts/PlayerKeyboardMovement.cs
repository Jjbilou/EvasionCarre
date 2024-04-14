using UnityEngine;

public class PlayerKeyboardMovement : MonoBehaviour
{
    [SerializeField] float speed;

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f);
        movement.Normalize();

        transform.position += speed * Time.deltaTime * movement;
    }
}
