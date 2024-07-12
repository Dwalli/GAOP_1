using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPerson : MonoBehaviour
{
    public InputAction playerActions;
    private CharacterController controller;
    private Vector2 moveDirection;
    public float speed = 9;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void OnEnable() {
        playerActions.Enable();
    }

    private void OnDisable() {
        playerActions.Disable();
    }

    void movePlayer(){
        moveDirection = playerActions.ReadValue<Vector2>();
        Vector3 move = new Vector3(moveDirection.x, 9f, moveDirection.y);
        controller.Move(move * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
