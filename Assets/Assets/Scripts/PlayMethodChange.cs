using UnityEngine;

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
}
