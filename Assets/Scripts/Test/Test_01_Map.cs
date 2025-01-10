using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_01_Map : TestBase
{
#if UNITY_EDITOR    

    private void Start()
    {
        
    }

    private Vector2 moveInput;

    private void Update()
    {
        // MoveAction이 활성화되고 canceled 상태가 아닐 때만 움직임 처리
        if (!playerInputActions.Move.MoveAction.triggered) // canceled 상태 확인
        {
            // 이동 입력을 계속 읽고 처리
            moveInput = playerInputActions.Move.MoveAction.ReadValue<Vector2>();

            // 방향에 따라 처리
            if (moveInput.x < 0)
            {
                Debug.Log("왼쪽");
            }
            else if (moveInput.x > 0)
            {
                Debug.Log("오른쪽");
            }
        }
    }

    protected override void OnTestMove(InputAction.CallbackContext context)
    {
        /*Debug.Log("move");

        // Vector2로 입력값을 받고
        Vector2 moveDirection = context.ReadValue<Vector2>();

        // X축 값을 사용하여 왼쪽/오른쪽 화살표 입력을 구분
        if (moveDirection.x < 0)
        {
            Debug.Log("왼쪽");
        }
        else if (moveDirection.x > 0)
        {
            Debug.Log("오른쪽");
        }*/
    }

#endif
}
