using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool active;

    TMP_Text text;
    float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        active = true;
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            time += Time.deltaTime;
            int minutes = (int)Mathf.Floor(time / 60.0f);
            int seconds = (int)Mathf.Floor(time % 60.0f);
            string display = (minutes < 10 ? '0' + minutes.ToString() : minutes.ToString()) + ':' + (seconds < 10 ? '0' + seconds.ToString() : seconds.ToString());
            text.SetText(display);
        }
        else
        {
            if (PlayerPrefs.GetFloat("bestTime") < time)
            {
                PlayerPrefs.SetFloat("bestTime", time);
            }
        }
    }
}
