using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMouseMovement : MonoBehaviour
{
    [SerializeField]
    float speed;
    
    private Vector2 ratio;

    // Start is called before the first frame update
    void Start()
    {
        Camera gameCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
        float cameraHeight = 2f * gameCamera.orthographicSize;
        float cameraWidth = cameraHeight * gameCamera.aspect;

        ratio = new Vector2(cameraWidth / Screen.width, cameraHeight / Screen.height); //ratio between camera size and pixels number
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = ((Vector2)Input.mousePosition - new Vector2(Screen.width / 2, Screen.height / 2)) * ratio;
        Vector2 playerPosition = (Vector2)transform.position;

        if (Vector2.Distance(mousePosition, playerPosition) > 0.1f)
        {
            Vector3 movement = new Vector3(mousePosition.x - playerPosition.x, mousePosition.y - playerPosition.y, 0);
            movement.Normalize();

            transform.position += movement * Time.deltaTime * speed;
        }
    }
}
