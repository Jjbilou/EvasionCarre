using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        if (sceneName == "Game")
        {
            SceneManager.LoadScene("Game");
        }
        else if (sceneName.Contains("Level") && sceneName != "LevelChoose")
        {
            PlayerPrefs.SetString("level", sceneName);
            SceneManager.LoadScene("Game");
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
