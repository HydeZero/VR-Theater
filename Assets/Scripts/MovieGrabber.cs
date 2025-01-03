using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovieGrabber : MonoBehaviour
{
    public static MovieGrabber Instance;

    public string moviePath; // The path to the movie file

    private void Awake()
    {
        // Make sure the MovieGrabber always stays even when moving scenes. We need this to memorize the file path and play the movie when we enter VR mode.
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void SavePathAndSwitchScene(string path)
    {
        moviePath = path;
        SceneManager.LoadScene("VR-Theater"); // Switch to the VR scene after movie has been selected
    }

    // Ask the user to select an MP4 file to play
    public void AskForFile()
    {
        NativeFilePicker.PickFile(SavePathAndSwitchScene);
    }
}
