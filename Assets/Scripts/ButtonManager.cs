using Google.XR.Cardboard;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;

public class ButtonManager : MonoBehaviour
{

    private MenuManager menuManager;

    public string buttonType;

    public ScreenManager screenManager;

    InputAction interactAction;

    bool isActive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");
        menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
        screenManager = GameObject.Find("Screen").GetComponent<ScreenManager>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ButtonHandler());
    }

    IEnumerator ButtonHandler()
    {
        if (isActive)
        {
            if (interactAction.WasPressedThisFrame())
            {
                if (buttonType == "Play")
                {
                    screenManager.Play();
                    buttonType = "Pause";
                }
                else if (buttonType == "Pause")
                {
                    screenManager.Pause();
                    buttonType = "Play";
                }
                else if (buttonType == "Stop")
                {
                    screenManager.Stop();
                }
                else if (buttonType == "Fast Forward")
                {
                    screenManager.Forward();
                }
                else if (buttonType == "Rewind")
                {
                    screenManager.Rewind();
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
        isActive = true;
    }

    public void OnPointerExit()
    {
        isActive = false;
    }
}
