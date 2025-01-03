using UnityEngine;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
using TMPro;
using System.Collections;

public class ChairManager : MonoBehaviour
{
    public GameObject player;

    private InputAction _sitAction;

    public bool _isActive;

    private CapsuleCollider playerCollider;

    private Rigidbody playerRb;

    public bool _isSitting = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        playerCollider = player.GetComponent<CapsuleCollider>();
        playerRb = player.GetComponent<Rigidbody>();
        _sitAction = InputSystem.actions.FindAction("Sit");
    }

    public void OnPointerEnter()
    {
        _isActive = true;
    }

    public void OnPointerExit()
    {
        _isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SeatDetector());
    }

    IEnumerator SeatDetector()
    {
        if (_isActive)
        {
            Debug.Log("Entered IsActive statement");
            if (_sitAction.WasPressedThisFrame() && !_isSitting)
            {
                Debug.Log("Pressed Sit");
                EnterSeat();
                yield return new WaitForSecondsRealtime(1); // make sure the next frame doesn't detect the same input and send the player flying off the chair
            }
        }
        if (_sitAction.WasPressedThisFrame() && _isSitting)
        {
            Debug.Log("Pressed exit");
            ExitSeat();
        }
        yield return null;
    }

    void EnterSeat()
    {
        _isSitting = true;
        playerRb.isKinematic = true;
        playerCollider.enabled = false;
        player.transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y+.5f, transform.position.z-0.45f), new Quaternion(0, 0, 0, 0));
        Variables.ActiveScene.Set("PlayerCanMove", false);
    }

    void ExitSeat()
    {
        _isSitting = false;
        Variables.ActiveScene.Set("PlayerCanMove", true);
        player.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2); // leave the seat
        playerRb.isKinematic = false;
        playerCollider.enabled = true;
    }
}
