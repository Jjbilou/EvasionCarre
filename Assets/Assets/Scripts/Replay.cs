using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
    public void Reload()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("level"));
    }
}
