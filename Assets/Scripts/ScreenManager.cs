using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    private string _url;

    private VideoPlayer _videoPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        try
        {
            _videoPlayer.source = VideoSource.Url;
        }
        catch
        {
            Debug.Log("VideoPlayer source was unable to be set to URL");
            Application.Quit(); // Exit the application if the video player source cannot be set
        }
        try // try to set the video player URL to the selected movie
        {
            _url = "file://" + MovieGrabber.Instance.moviePath;
            _videoPlayer.url = _url;
        }
        catch
        {
            Debug.Log("VideoPlayer URL was unable to be set to the movie path");
            Application.Quit(); // Exit the application if the video player URL cannot be set
        }

        // do some final setup for the video player
        _videoPlayer.Prepare();
        _videoPlayer.controlledAudioTrackCount = 1;
        _videoPlayer.EnableAudioTrack(0, true);
        _videoPlayer.SetTargetAudioSource(0, GetComponent<AudioSource>());
        _videoPlayer.Stop();
    }

    // Here we expose all of the basic video player functions to outside scripts
    public void Play()
    {
        _videoPlayer.Play();
    }

    public void Pause()
    {
        _videoPlayer.Pause();
    }

    public void Restart()
    {
        _videoPlayer.Stop();
        _videoPlayer.Play();
    }

    public void Stop()
    {
        _videoPlayer.Stop();
    }

    public void Rewind()
    {
        _videoPlayer.time -= 10;
    }

    public void Forward()
    {
        _videoPlayer.time += 10;
    }

    public void ExitMovie()
    {
        SceneManager.LoadScene("Title");
    }
}
