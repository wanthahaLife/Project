using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class A_TestPool : TestBase
{
    private void Start()
    {
       // Debug.Log(transform.childCount);
    }
    protected override void OnTest1(InputAction.CallbackContext context)
    {
        //MonsterFactory.Instance.GetObject();
    }
}
