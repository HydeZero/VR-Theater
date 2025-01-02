using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float _speed = 5;
    private float _turnSpeed = 45;
    public bool playerCanMove = true;
    InputAction _moveAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
    }

    // FixedUpdate is called once per physics update
    void FixedUpdate()
    {
    }
    
    //OnInputSystemEventVector2 OnVector2(InputValue input)
    //{
    //    // ????
    //}

}
