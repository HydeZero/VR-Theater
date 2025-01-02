using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    private string url;

    private VideoPlayer videoPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        try
        {
            videoPlayer.source = VideoSource.Url;
        }
        catch
        {
            Debug.Log("VideoPlayer source was unable to be set to URL");
            Application.Quit(); // Exit the application if the video player source cannot be set
        }
        try // try to set the video player URL to the selected movie
        {
            url = "file://" + MovieGrabber.Instance.moviePath;
            videoPlayer.url = url;
        }
        catch
        {
            Debug.Log("VideoPlayer URL was unable to be set to the movie path");
            Application.Quit(); // Exit the application if the video player URL cannot be set
        }

        // do some final setup for the video player
        videoPlayer.Prepare();
        videoPlayer.controlledAudioTrackCount = 1;
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, GetComponent<AudioSource>());
        videoPlayer.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Here we expose all of the basic video player functions to outside scripts
    public void Play()
    {
        videoPlayer.Play();
    }

    public void Pause()
    {
        videoPlayer.Pause();
    }

    public void Restart()
    {
        videoPlayer.Stop();
        videoPlayer.Play();
    }

    public void Stop()
    {
        videoPlayer.Stop();
    }

    public void Rewind()
    {
        videoPlayer.time -= 10;
    }

    public void Forward()
    {
        videoPlayer.time += 10;
    }

    public void ExitMovie()
    {
        SceneManager.LoadScene("Title");
    }
}
