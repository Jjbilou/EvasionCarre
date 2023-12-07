using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMethodChange : MonoBehaviour
{
    public GameObject player;

    public void ActivateMouse()
    {
        player.GetComponent<PlayerMouseMovement>().enabled = true;
        player.GetComponent<PlayerKeyboardMovement>().enabled = false;
    }

    public void ActivateKeyboard()
    {
        player.GetComponent<PlayerMouseMovement>().enabled = false;
        player.GetComponent<PlayerKeyboardMovement>().enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
