using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMethodColors : MonoBehaviour
{
    PlayMethodChange script;
    Image backgroundImage;
    PlayerMouseMovement mouseScript;

    // Start is called before the first frame update
    void Start()
    {
        script = transform.parent.GetComponent<PlayMethodChange>();
        backgroundImage = GetComponent<Image>();
        mouseScript = transform.parent.GetComponent<PlayMethodChange>().player.GetComponent<PlayerMouseMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        backgroundImage.color = mouseScript.enabled ? (name == "Mouse" ? Color.green : Color.white) : (name == "Keyboard" ? Color.green : Color.white);
    }
}
