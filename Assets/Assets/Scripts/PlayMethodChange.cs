using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMethodChange : MonoBehaviour
{
    public GameObject player;

    PlayerMouseMovement mouseMovement;
    PlayerKeyboardMovement keyboardMovement;

    public void ActivateMouse()
    {
        mouseMovement.enabled = true;
        keyboardMovement.enabled = false;
    }

    public void ActivateKeyboard()
    {
        mouseMovement.enabled = false;
        keyboardMovement.enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        mouseMovement = player.GetComponent<PlayerMouseMovement>();
        keyboardMovement = player.GetComponent<PlayerKeyboardMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
