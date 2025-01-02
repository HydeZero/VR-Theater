using Google.XR.Cardboard;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;

public class ButtonManager : MonoBehaviour
{

    private MenuManager _menuManager;

    public string buttonType;

    private ScreenManager _screenManager;

    private InputAction _interactAction;

    private bool _isActive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _interactAction = InputSystem.actions.FindAction("Interact");
        _menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
        _screenManager = GameObject.Find("Screen").GetComponent<ScreenManager>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ButtonHandler());
    }

    IEnumerator ButtonHandler()
    {
        if (_isActive)
        {
            if (_interactAction.WasPressedThisFrame() || OnPointerClick())
            {
                if (buttonType == "Play")
                {
                    _screenManager.Play();
                    buttonType = "Pause";
                }
                else if (buttonType == "Pause")
                {
                    _screenManager.Pause();
                    buttonType = "Play";
                }
                else if (buttonType == "Stop")
                {
                    _screenManager.Stop();
                }
                else if (buttonType == "Fast Forward")
                {
                    _screenManager.Forward();
                }
                else if (buttonType == "Rewind")
                {
                    _screenManager.Rewind();
                }
                else if (buttonType == "Recenter")
                {
                    yield return new WaitForSecondsRealtime(3); // give the user enough time to situate themselves before recentering
                    Api.Recenter();
                }
            }
        }
        yield return null;
    }

    public void OnPointerEnter()
    {
        _isActive = true;
    }

    public void OnPointerExit()
    {
        _isActive = false;
    }

    bool OnPointerClick()
    {
        return true; // basically tell the function that called this that "the button was clicked"
    }
}
