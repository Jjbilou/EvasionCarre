using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("Music").Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 0.6f);
        }
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = PlayerPrefs.GetFloat("volume");
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName.Contains("Level") && sceneName != "LevelChoose")
        {
            Destroy(gameObject);
        }
    }
}
