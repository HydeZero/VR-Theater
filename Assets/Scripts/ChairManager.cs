using UnityEngine;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class ChairManager : MonoBehaviour
{
    public GameObject player;

    private InputAction _interactAction;

    private bool _isActive;

    private CapsuleCollider playerCollider;

    private Rigidbody playerRb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        playerCollider = player.GetComponent<CapsuleCollider>();
        playerRb = player.GetComponent<Rigidbody>();
        _interactAction = InputSystem.actions.FindAction("Interact");
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
        if (_isActive)
            if (_interactAction.WasPressedThisFrame() && (bool)Variables.ActiveScene.Get("PlayerCanMove"))
            {
                EnterSeat();
            } else
            {
                ExitSeat();
            }
    }

    void EnterSeat()
    {
        playerRb.useGravity = false;
        playerCollider.enabled = false;
        player.transform.position= new Vector3(transform.position.x, transform.position.y, transform.position.z);
        player.transform.rotation = new Quaternion(0, 0, 0, 0); // how do quaternions even work idk
        Variables.ActiveScene.Set("PlayerCanMove", false);
    }

    void ExitSeat()
    {
        Variables.ActiveScene.Set("PlayerCanMove", true);
        player.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f); // leave the seat
        playerRb.useGravity = true;
        playerCollider.enabled = true;
    }

    void OnPointerClick()
    {
        EnterSeat(); // dual compatibility for the win
    }
}
