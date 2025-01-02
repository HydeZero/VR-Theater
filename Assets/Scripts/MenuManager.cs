using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    bool isMenuOpen = false;

    InputAction interactAction;

    public GameObject FullMenu;

    public GameObject player;

    private Vector3 offset = new Vector3(0, -1, 1.5f);

    private void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        // Get player rotation as vector
        Vector3 parentAngle = player.transform.eulerAngles;

        // Calculate the offset Position, relatively to player rotation values
        Vector3 rotatedOffset = Quaternion.Euler(parentAngle) * offset;

        // Calculate the finalPosition of the rotatedOffset, relatively to player position in world
        Vector3 finalPosition = player.transform.position + rotatedOffset;

        // Set menu position to calculated finalPosition
        FullMenu.transform.position = finalPosition;

        // Set menu rotation to player one
        FullMenu.transform.rotation = player.transform.rotation;
        if (!isMenuOpen)
        {
            if (interactAction.WasPressedThisFrame())
            {
                isMenuOpen = true;
                FullMenu.SetActive(true);
            }
        }
    }

    public void CloseMenu()
    {
        FullMenu.SetActive(false);
        isMenuOpen = false;
    }
}
