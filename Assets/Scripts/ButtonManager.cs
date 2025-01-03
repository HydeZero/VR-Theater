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

    private Light _screeningLight;

    public Material play;

    public Material pause;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _interactAction = InputSystem.actions.FindAction("Interact");
        _menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
        _screenManager = GameObject.Find("Screen").GetComponent<ScreenManager>();
        _screeningLight = GameObject.Find("ScreeningLight").GetComponent<Light>();
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
            if (_interactAction.WasPressedThisFrame())
            {
                if (buttonType == "Play")
                {
                    _screenManager.Play();
                    StartCoroutine(SlowLightOff());
                    gameObject.GetComponent<MeshRenderer>().material = pause;
                    buttonType = "Pause";
                }
                else if (buttonType == "Pause")
                {
                    _screenManager.Pause();
                    gameObject.GetComponent<MeshRenderer>().material = play;
                    buttonType = "Play";
                }
                else if (buttonType == "Stop")
                {
                    _screenManager.Stop();
                    StartCoroutine(SlowLightOn());
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

    IEnumerator SlowLightOff()
    {
        while (_screeningLight.intensity > 0) {
            _screeningLight.intensity -= 500 * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        _screeningLight.intensity = 0; // set it to prevent any wrong values
    }

    IEnumerator SlowLightOn()
    {
        while (_screeningLight.intensity < 1000)
        {
            _screeningLight.intensity += 500 * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        _screeningLight.intensity = 1000; // set it to prevent any wrong values
    }

    public void OnPointerEnter()
    {
        _isActive = true;
    }

    public void OnPointerExit()
    {
        _isActive = false;
    }
}
