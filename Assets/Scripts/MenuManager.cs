using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MenuManager : MonoBehaviour
{
    public bool isMenuOpen = false;

    InputAction menuAction;

    public GameObject FullMenu;

    public GameObject player;

    private Vector3 _offset = new Vector3(0, -1, 2.5f);

    public VideoPlayer _videoPlayer;

    public TextMeshPro currentMinutes;

    public TextMeshPro currentSeconds;

    public TextMeshPro totalMinutes;

    public TextMeshPro totalSeconds;

    public PlayheadMover playheadMover;

    private void Start()
    {
        menuAction = InputSystem.actions.FindAction("Menu");
        _videoPlayer = GameObject.Find("Screen").GetComponent<VideoPlayer>();
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        // Get player rotation as vector
        Vector3 parentAngle = player.transform.eulerAngles;

        // Calculate the offset Position, relatively to player rotation values
        Vector3 rotatedOffset = Quaternion.Euler(parentAngle) * _offset;

        // Calculate the finalPosition of the rotatedOffset, relatively to player position in world
        Vector3 finalPosition = player.transform.position + rotatedOffset;

        if (!isMenuOpen)
        {
            if (menuAction.WasPressedThisFrame())
            {
                isMenuOpen = true;
                SetTotalTimeUI(); // get the time UI every time the menu is opened
            }
        }
        else if (isMenuOpen)
        {
            // Set menu position to calculated finalPosition
            FullMenu.transform.position = finalPosition;

            // Set menu rotation to player rotation
            FullMenu.transform.rotation = player.transform.rotation;
            if (menuAction.WasPressedThisFrame())
            {
                CloseMenu();
            }
        }

        // time UI stuff
        if (_videoPlayer.isPlaying)
        {
            SetCurrentTimeUI();
            playheadMover.MovePlayhead(CalculatePlayedFraction());
        }
    }

    public void CloseMenu()
    {
        // Set menu position to calculated finalPosition
        FullMenu.transform.position = new Vector3(200,200,0);

        // Set menu rotation to player one
        FullMenu.transform.rotation = new Quaternion(0,0,0,0);
        isMenuOpen = false;
    }

    void SetCurrentTimeUI()
    {
        string minutes = Mathf.Floor((int) _videoPlayer.time / 60).ToString("00");
        string seconds = ((int)_videoPlayer.time % 60).ToString("00");

        currentMinutes.text = minutes;
        currentSeconds.text = seconds;
    }

    public void SetTotalTimeUI()
    {
        // Get frame count and frame rate from the VideoPlayer. 
        ulong frameCount = _videoPlayer.frameCount;
        double frameRate = _videoPlayer.frameRate;

        // Calculate the length in seconds. 
        double lengthInSeconds = frameCount / frameRate;

        string minutes = Mathf.Floor((int)lengthInSeconds / 60).ToString("00");
        string seconds = ((int)lengthInSeconds % 60).ToString("00");

        totalMinutes.text = minutes;
        totalSeconds.text = seconds;
    }

    double CalculatePlayedFraction()
    {
        double fraction = (double) _videoPlayer.frame / (double) _videoPlayer.clip.frameCount;
        return fraction;
    }
}
