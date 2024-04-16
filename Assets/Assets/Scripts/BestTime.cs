using TMPro;
using UnityEngine;

public class BestTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("bestTime"))
        {
            float time = PlayerPrefs.GetFloat("bestTime");
            int minutes = (int)Mathf.Floor(time / 60.0f);
            int seconds = (int)Mathf.Floor(time % 60.0f);
            string display = (minutes < 10 ? '0' + minutes.ToString() : minutes.ToString()) + ':' + (seconds < 10 ? '0' + seconds.ToString() : seconds.ToString());
            GetComponent<TMP_Text>().SetText(display);
        }
    }
}
