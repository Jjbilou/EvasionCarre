using UnityEngine;
using UnityEngine.UI;

public class PlayMethodChange : MonoBehaviour
{
    [SerializeField] Image mouseBackground;
    [SerializeField] Image keyboardBackground;

    void Start()
    {
        if (!PlayerPrefs.HasKey("movement"))
        {
            PlayerPrefs.SetString("movement", "mouse");
        }

        if (PlayerPrefs.GetString("movement") == "mouse")
        {
            keyboardBackground.color = Color.white;
            mouseBackground.color = Color.green;
        }
        else
        {
            keyboardBackground.color = Color.green;
            mouseBackground.color = Color.white;
        }
    }

    public void ActivateMouse()
    {
        PlayerPrefs.SetString("movement", "mouse");
        keyboardBackground.color = Color.white;
        mouseBackground.color = Color.green;
    }

    public void ActivateKeyboard()
    {
        PlayerPrefs.SetString("movement", "keyboard");
        keyboardBackground.color = Color.green;
        mouseBackground.color = Color.white;
    }
}
