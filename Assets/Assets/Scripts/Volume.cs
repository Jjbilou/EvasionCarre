using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1.0f);
        }

        slider = GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat("volume");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("volume", slider.value);
    }
}
