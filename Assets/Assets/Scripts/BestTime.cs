using System;
using TMPro;
using UnityEngine;

public class BestTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float time = PlayerPrefs.GetFloat("bestTime");
        string display = (time / 60 < 10 ? '0' + Math.Floor(time / 60).ToString() : Math.Floor(time / 60).ToString()) + ':' + (time % 60 < 10 ? '0' + Math.Floor(time % 60).ToString() : Math.Floor(time % 60).ToString());
        GetComponent<TMP_Text>().SetText(display);
    }
}
