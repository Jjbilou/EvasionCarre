using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMethodChange : MonoBehaviour
{
    public void ActivateMouse()
    {
        PlayerPrefs.SetString("movement", "mouse");
    }

    public void ActivateKeyboard()
    {
        PlayerPrefs.SetString("movement", "keyboard");
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
