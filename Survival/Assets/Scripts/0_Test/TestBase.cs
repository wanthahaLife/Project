using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestBase : MonoBehaviour
{
    PlayerInputActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Test1.performed += OnTest1;
        inputActions.Player.Test2.performed += OnTest2;
        inputActions.Player.Test3.performed += OnTest3;
        inputActions.Player.Test4.performed += OnTest4;
        inputActions.Player.Test5.performed += OnTest5;
    }

    private void OnDisable()
    {
        inputActions.Player.Test5.performed -= OnTest5;
        inputActions.Player.Test4.performed -= OnTest4;
        inputActions.Player.Test3.performed -= OnTest3;
        inputActions.Player.Test2.performed -= OnTest2;
        inputActions.Player.Test1.performed -= OnTest1;
        inputActions.Player.Disable();
    }

    protected virtual void OnTest5(InputAction.CallbackContext context)
    {
    }

    protected virtual void OnTest4(InputAction.CallbackContext context)
    {
    }

    protected virtual void OnTest3(InputAction.CallbackContext context)
    {
    }

    protected virtual void OnTest2(InputAction.CallbackContext context)
    {
    }

    protected virtual void OnTest1(InputAction.CallbackContext context)
    {
    }
}
