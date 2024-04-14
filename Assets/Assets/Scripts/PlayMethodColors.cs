using UnityEngine;
using UnityEngine.UI;

public class PlayMethodColors : MonoBehaviour
{
    Image backgroundImage;

    // Start is called before the first frame update
    void Start()
    {
        backgroundImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        backgroundImage.color = PlayerPrefs.GetString("movement") == "mouse" ? (name == "Mouse" ? Color.green : Color.white) : (name == "Keyboard" ? Color.green : Color.white);
    }
}
